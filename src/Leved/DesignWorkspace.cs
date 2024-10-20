using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Buffers.Binary;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace ScorchGore.Leved;

internal static class DesignWorkspace
{
    public static List<MaterialTheme> MaterialThemes = [];
    public static List<Asset> Assets = [];
    public static List<LevelBeschreibung> Levels = [];
    public static List<MissionDef> Missions = [];

    private static bool IsDirty = false;

    private const string WorkspaceFilename = "workspace.sugma";

    // the first nine of that form the usual signature
    private static readonly IReadOnlyList<byte> RgbKey = [
        0x03, 0x4a, 0x4d, 0x4c, 0x05, 0x4c, 0x53, 0x4c,
        0x04, 0xab, 0x74, 0xfe, 0xba, 0xdf, 0xf0, 0x0d,
        0xac, 0xab, 0xca, 0x7b, 0xba, 0xdf, 0xf0, 0x0d,
        0x1e, 0x47, 0x91, 0xc2, 0x05, 0x5e, 0xaa, 0x33
    ];

    private static readonly IReadOnlyList<byte> RgbIV = [
        0xca, 0xfe, 0xac, 0xab, 0xc0, 0xff, 0xef, 0xfe,
        0x00, 0x4a, 0x5c, 0xb9, 0x17, 0xf7, 0x22, 0x0d
    ];

    private static bool IsWorkspaceOpen = false;    

    public static bool HasUnsavedData => IsDirty;

    public static void EnsureDesignWorkspace()
    {
        if (!IsWorkspaceOpen)
        {
            if (!File.Exists(WorkspaceFilename))
            {
                IsWorkspaceOpen = true;
                SaveWorkspace();
            }

            LoadWorkspace();
            IsWorkspaceOpen = true;
        }
    }

    public static void LoadWorkspace()
    {
        using var fis = new FileStream(WorkspaceFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
        var signature = new byte[9];

        fis.ReadExactly(signature, 0, 9);
        if (!signature.SequenceEqual(RgbKey.Take(9)))
        {
            throw new IOException(@$"Invalid signature on ""{WorkspaceFilename}""");
        }

        using var aes = Aes.Create();
        using var enc = aes.CreateDecryptor([.. RgbKey], [.. RgbIV]);
        using var cys = new CryptoStream(fis, enc, CryptoStreamMode.Read);
        using var dec = new GZipStream(cys, CompressionMode.Decompress);
        using var brd = new BinaryReader(dec);

        Missions.Clear();
        Levels.Clear();
        Assets.Clear();
        MaterialThemes.Clear();

        LoadMaterialThemes(brd);
        LoadAssets(brd);
        LoadLevels(brd);
        LoadMissions(brd);

#if DEBUG
        if (MaterialThemes.Count == 0)
        {
            MaterialThemes.Add(new("WOTMSTD", []) { IsBuiltin = true });
        }

        if (Missions.Count == 0 && Levels.Count == 0)
        {
            var levelNr = 1;

            for (var mission = 1; mission <= 7; ++mission)
            {
                Missions.Add(new()
                {
                    IsBuiltin = true,
                    MissionsNummer = mission,
                    NameDe = LevelBeschreibung.MissionsnameBestimmen(mission, "de"),
                    NameEn = LevelBeschreibung.MissionsnameBestimmen(mission, "en"),
                    NameFi = LevelBeschreibung.MissionsnameBestimmen(mission, "fi"),
                    NameUa = LevelBeschreibung.MissionsnameBestimmen(mission, "ua")
                });

                var levelInfo = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
                while (levelInfo.MissionsNummer == mission)
                {
                    levelInfo.IsBuiltin = true;
                    levelInfo.Author = "fso::dlatikay";
                    Levels.Add(levelInfo);

                    ++levelNr;
                    levelInfo = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
                }
            }
        }
#endif
    }

    public static void SetDirty()
    {
        if (!IsDirty)
        {
            IsDirty = true;
        }
    }

    public static void SaveWorkspace()
    {
        if (!IsWorkspaceOpen)
        {
            throw new ArgumentOutOfRangeException(nameof(IsWorkspaceOpen), IsWorkspaceOpen, "no open workspace");
        }

        using var fos = new FileStream(WorkspaceFilename, FileMode.Create, FileAccess.Write, FileShare.Read);

        fos.Write([.. RgbKey], 0, 9);
        
        using var aes = Aes.Create();
        using var enc = aes.CreateEncryptor([.. RgbKey], [.. RgbIV]);
        using var cys = new CryptoStream(fos, enc, CryptoStreamMode.Write);
        using var zip = new GZipStream(cys, CompressionMode.Compress);
        using var bwr = new BinaryWriter(zip);

        WriteEverything(bwr);
        IsDirty = false;

#if DEBUG
        if(Debugger.IsAttached)
        {
            var debugOutputFile = $"{WorkspaceFilename}.txt";

            using var fos_dgb = new FileStream(debugOutputFile, FileMode.Create, FileAccess.Write, FileShare.Read);

            fos_dgb.Write([.. RgbKey], 0, 9);

            using var bwr_dgb = new BinaryWriter(fos_dgb);

            WriteEverything(bwr_dgb);
        }
#endif
    }

    private static void WriteEverything(BinaryWriter bwr)
    {
        SaveMaterialThemes(bwr);
        SaveAssets(bwr);
        SaveLevels(bwr);
        SaveMissions(bwr);
    }

    private static void LoadMaterialThemes(BinaryReader inStream)
    {
        var bnmth = inStream.ReadBytes(2);
        var nmth = BinaryPrimitives.ReadUInt16LittleEndian(bnmth);

        for (var i = 0; i < nmth; ++i)
        {
            LoadMaterialTheme(inStream);
        }
    }

    private static void LoadMaterialTheme(BinaryReader inStream)
    {
        var isBuiltin = inStream.ReadByte() == 0xff;
        var slname = inStream.ReadByte();
        var bname = inStream.ReadBytes(slname);
        var name = Encoding.UTF8.GetString(bname);
        var sets = new List<SetOfMaterials>();

        LoadSetsOfMaterials(inStream, sets);

        var theme = new MaterialTheme(name, sets)
        {
            IsBuiltin = isBuiltin
        };

        MaterialThemes.Add(theme);

        // placeholder for extension propertybag
        _ = inStream.ReadUInt16();
    }

    private static void LoadSetsOfMaterials(BinaryReader inStream, List<SetOfMaterials> sets)
    {
        var bnsom = inStream.ReadBytes(2);
        var nsom = BinaryPrimitives.ReadUInt16LittleEndian(bnsom);

        for (var i = 0; i < nsom; ++i)
        {
            LoadSetOfMaterials(inStream, sets);
        }
    }

    private static void LoadSetOfMaterials(BinaryReader inStream, List<SetOfMaterials> sets)
    {
        var slmedium = inStream.ReadByte();
        var bsmedium = inStream.ReadBytes(slmedium);
        var smedium = Encoding.UTF8.GetString(bsmedium);
        var medium = Enum.Parse<Medium>(smedium);
        var set = new SetOfMaterials(medium, []);
        var bnmat = inStream.ReadBytes(2);
        var nmat = BinaryPrimitives.ReadUInt16LittleEndian(bnmat);

        for (var i = 0; i < nmat; ++i)
        {
            var bslname = inStream.ReadByte();
            var bsname = inStream.ReadBytes(bslname);
            var sname = Encoding.UTF8.GetString(bsname);
            var bcolor = inStream.ReadBytes(4);
            var icolor = BinaryPrimitives.ReadInt32LittleEndian(bcolor);
            var color = Color.FromArgb(icolor);
            var mat = new Material(sname, color);

            set.Materials.Add(mat);

            // placeholder for extension propertybag
            _ = inStream.ReadUInt16();
        }

        sets.Add(set);

        // placeholder for extension propertybag
        _ = inStream.ReadUInt16();
    }

    private static void LoadAssets(BinaryReader inStream)
    {
        var bnass = inStream.ReadBytes(2);
        var nass = BinaryPrimitives.ReadUInt16LittleEndian(bnass);

        for (var i = 0; i < nass; ++i)
        {
            LoadAsset(inStream);
        }
    }

    private static void LoadAsset(BinaryReader inStream)
    {
        var slAssetClass = inStream.ReadByte();
        var bsAssetClass = inStream.ReadBytes(slAssetClass);
        var sAssetClass = Encoding.UTF8.GetString(bsAssetClass);
        var assetClass = Enum.Parse<AssetClass>(sAssetClass);
        var assetId = inStream.ReadBytes(16);
        var isBuiltin = inStream.ReadByte() == 0xff;
        var slAssetName = inStream.ReadByte();
        var bsAssetName = inStream.ReadBytes(slAssetName);
        var assetName = Encoding.UTF8.GetString(bsAssetName);
        var asset = new Asset(assetClass, new(assetId), isBuiltin, assetName);
        var blIcon = inStream.ReadBytes(2);
        var lIcon = BinaryPrimitives.ReadUInt16LittleEndian(blIcon);
        var bIcon = inStream.ReadBytes(lIcon);

        if (bIcon?.Length > 0)
        {
            asset.Icon = bIcon;
        }

        var blThumb = inStream.ReadBytes(2);
        var lThumb = BinaryPrimitives.ReadUInt16LittleEndian(blThumb);
        var bThumb = inStream.ReadBytes(lThumb);

        if (bThumb?.Length > 0)
        {
            asset.Thumb = bThumb;
        }

        Assets.Add(asset);

        // placeholder for extension propertybag
        _ = inStream.ReadUInt16();
    }

    private static void LoadLevels(BinaryReader inStream)
    {
        var bnlvl = inStream.ReadBytes(2);
        var nlvl = BinaryPrimitives.ReadUInt16LittleEndian(bnlvl);

        for (var i = 0; i < nlvl; ++i)
        {
            LoadLevel(inStream);
        }
    }

    private static void LoadLevel(BinaryReader inStream)
    {
        var flags = inStream.ReadByte();
        var builtinFlag = 1 << 4;
        var isBuiltin = (flags & builtinFlag) == builtinFlag;
        var bMissionsNummer = new byte[4];
        var bLevelNummer = new byte[4];
        var bLevelNrInMission = new byte[4];
        var bHeight = new byte[4];
        var bWidth = new byte[4];
        var bZufallszahl = new byte[4];
        var bSpielerPosition1X = new byte[4];
        var bSpielerPosition1Y = new byte[4];
        var bSpielerPosition2X = new byte[4];
        var bSpielerPosition2Y = new byte[4];
        var bColorBackground = new byte[4];

        inStream.Read(bMissionsNummer, 0, 4);
        inStream.Read(bLevelNummer, 0, 4);
        inStream.Read(bLevelNrInMission, 0, 4);
        inStream.Read(bWidth, 0, 4);
        inStream.Read(bHeight, 0, 4);
        inStream.Read(bZufallszahl, 0, 4);
        inStream.Read(bSpielerPosition1X, 0, 4);
        inStream.Read(bSpielerPosition1Y, 0, 4);
        inStream.Read(bSpielerPosition2X, 0, 4);
        inStream.Read(bSpielerPosition2Y, 0, 4);
        inStream.Read(bColorBackground, 0, 4);

        var missionsNummer = BinaryPrimitives.ReadInt32LittleEndian(bMissionsNummer);
        var levelNummer = BinaryPrimitives.ReadInt32LittleEndian(bLevelNummer);
        var levelNummerInMission = BinaryPrimitives.ReadInt32LittleEndian(bLevelNrInMission);
        var width = BinaryPrimitives.ReadUInt32LittleEndian(bWidth);
        var height = BinaryPrimitives.ReadUInt32LittleEndian(bHeight);
        var zufallszahl = BinaryPrimitives.ReadUInt32LittleEndian(bZufallszahl);
        var spielerPosition1X = BinaryPrimitives.ReadInt32LittleEndian(bSpielerPosition1X);
        var spielerPosition1Y = BinaryPrimitives.ReadInt32LittleEndian(bSpielerPosition1Y);
        var spielerPosition2X = BinaryPrimitives.ReadInt32LittleEndian(bSpielerPosition2X);
        var spielerPosition2Y = BinaryPrimitives.ReadInt32LittleEndian(bSpielerPosition2Y);
        var icolorBackground = BinaryPrimitives.ReadInt32LittleEndian(bColorBackground);
        var colorBackground = Color.FromArgb(icolorBackground);
        var slNameEn = inStream.ReadByte();
        var bsNameEn = inStream.ReadBytes(slNameEn);
        var nameEn = Encoding.UTF8.GetString(bsNameEn);
        var slNameDe = inStream.ReadByte();
        var bsNameDe = inStream.ReadBytes(slNameDe);
        var nameDe = Encoding.UTF8.GetString(bsNameDe);
        var slNameFi = inStream.ReadByte();
        var bsNameFi = inStream.ReadBytes(slNameFi);
        var nameFi = Encoding.UTF8.GetString(bsNameFi);
        var slNameUa = inStream.ReadByte();
        var bsNameUa = inStream.ReadBytes(slNameUa);
        var nameUa = Encoding.UTF8.GetString(bsNameUa);
        var slAuthor = inStream.ReadByte();
        var bsAuthor = inStream.ReadBytes(slAuthor);
        var author = Encoding.UTF8.GetString(bsAuthor);
        var slMaterialThemeKey = inStream.ReadByte();
        var bsMaterialThemeKey = inStream.ReadBytes(slMaterialThemeKey);
        var materialThemeKey = Encoding.UTF8.GetString(bsMaterialThemeKey);
        var slBackdropAssetKey = inStream.ReadByte();
        var bsBackdropAssetKey = inStream.ReadBytes(slBackdropAssetKey);
        var backdropAssetKey = Encoding.UTF8.GetString(bsBackdropAssetKey);
        var slBeschreibungsSkript = inStream.ReadByte();
        var bsBeschreibungsSkript = inStream.ReadBytes(slBeschreibungsSkript);
        var beschreibungsSkript = Encoding.UTF8.GetString(bsBeschreibungsSkript);
        var lvl = new LevelBeschreibung
        {
            IsBuiltin = isBuiltin,
            MissionsNummer = missionsNummer,
            LevelNummer = levelNummer,
            LevelNummerInMission = levelNummerInMission,
            Width = width,
            Height = height,
            ColorBackground = colorBackground,
            Zufallszahl = zufallszahl,
            SpielerPosition1 = new(spielerPosition1X, spielerPosition1Y),
            SpielerPosition2 = new(spielerPosition2X, spielerPosition2Y),
            NameEn = nameEn,
            NameDe = nameDe,
            NameFi = nameFi,
            NameUa = nameUa,
            Author = author,
            MaterialThemeKey = materialThemeKey,
            BackdropAssetKey = backdropAssetKey,
        };

        lvl.SetScriptSource(beschreibungsSkript);

        // load asset placements
        var nPlacements = inStream.ReadUInt16();
        for (int i = 0; i < nPlacements; ++i)
        {
            var slAssetKey = inStream.ReadByte();
            var bAssetKey = inStream.ReadBytes(slAssetKey);
            var assetKey = Encoding.UTF8.GetString(bAssetKey);
            var locationX = inStream.ReadInt32();
            var locationY = inStream.ReadInt32();
            var orientRtl = inStream.ReadByte() == 0xff;
            var placement = new AssetPlacement
            {
                AssetKey = assetKey,
                Location = new Point(locationX, locationY),
                OrientedRtl = orientRtl
            };

            // placements have sets of properties grouped by data type
            var nParamsUInt = inStream.ReadUInt16();
            var nParamsInt = inStream.ReadUInt16();
            var nParamsFlags = inStream.ReadUInt16();
            var nParamsString = inStream.ReadUInt16();

            for (var j = 0; j < nParamsUInt; ++j)
            {
                var blKey = inStream.ReadByte();
                var bKey = new byte[blKey];

                inStream.Read(bKey, 0, blKey);

                var key = Encoding.UTF8.GetString(bKey);
                var value = inStream.ReadUInt32();

                placement.ParamsUInt.Add(key, value);
            }

            for (var j = 0; j < nParamsInt; ++j)
            {
                var blKey = inStream.ReadByte();
                var bKey = new byte[blKey];

                inStream.Read(bKey, 0, blKey);

                var key = Encoding.UTF8.GetString(bKey);
                var value = inStream.ReadInt32();

                placement.ParamsInt.Add(key, value);
            }

            for (var j = 0; j < nParamsFlags; ++j)
            {
                var blKey = inStream.ReadByte();
                var bKey = new byte[blKey];

                inStream.Read(bKey, 0, blKey);

                var key = Encoding.UTF8.GetString(bKey);
                var value = inStream.ReadByte() == 0xff;

                placement.ParamsFlags.Add(key, value);
            }

            for (var j = 0; j < nParamsString; ++j)
            {
                var blKey = inStream.ReadByte();
                var bKey = new byte[blKey];

                inStream.Read(bKey, 0, blKey);

                var key = Encoding.UTF8.GetString(bKey);
                var blValue = inStream.ReadByte();
                var bValue = new byte[blValue];

                inStream.Read(bValue, 0, blValue);

                var value = Encoding.UTF8.GetString(bValue);

                placement.ParamsString.Add(key, value);
            }

            lvl.AssetPlacement.Add(placement);

            // placeholder for extension propertybag
            _ = inStream.ReadUInt16();
        }

        Levels.Add(lvl);
    
        // placeholder for extension propertybag
        _ = inStream.ReadUInt16();
    }

    private static void LoadMissions(BinaryReader inStream)
    {
        var bnmis = inStream.ReadBytes(2);
        var nmis = BinaryPrimitives.ReadUInt16LittleEndian(bnmis);

        for (var i = 0; i < nmis; ++i)
        {
            LoadMission(inStream);
        }
    }

    private static void LoadMission(BinaryReader inStream)
    {
        var flags = inStream.ReadByte();
        var builtinFlag = 1 << 4;
        var isBuiltin = (flags & builtinFlag) == builtinFlag;
        var bMissionsNummer = new byte[4];

        inStream.Read(bMissionsNummer, 0, 4);

        var missionsNummer = BinaryPrimitives.ReadInt32LittleEndian(bMissionsNummer);
        var slNameEn = inStream.ReadByte();
        var bsNameEn = inStream.ReadBytes(slNameEn);
        var nameEn = Encoding.UTF8.GetString(bsNameEn);
        var slNameDe = inStream.ReadByte();
        var bsNameDe = inStream.ReadBytes(slNameDe);
        var nameDe = Encoding.UTF8.GetString(bsNameDe);
        var slNameFi = inStream.ReadByte();
        var bsNameFi = inStream.ReadBytes(slNameFi);
        var nameFi = Encoding.UTF8.GetString(bsNameFi);
        var slNameUa = inStream.ReadByte();
        var bsNameUa = inStream.ReadBytes(slNameUa);
        var nameUa = Encoding.UTF8.GetString(bsNameUa);
        var mission = new MissionDef
        {
            IsBuiltin = isBuiltin,
            MissionsNummer = missionsNummer,
            NameEn = nameEn,
            NameDe = nameDe,
            NameFi = nameFi,
            NameUa = nameUa
        };

        Missions.Add(mission);

        // placeholder for extension propertybag
        _ = inStream.ReadUInt16();
    }

    private static void SaveMaterialThemes(BinaryWriter oStream)
    {
        var bnmth = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnmth, (ushort)MaterialThemes.Count);
        oStream.Write(bnmth, 0, 2);

        foreach (var theme in MaterialThemes)
        {
            SaveMaterialTheme(theme, oStream);
        }
    }

    private static void SaveMaterialTheme(MaterialTheme theme, BinaryWriter oStream)
    {
        var bname = Encoding.UTF8.GetBytes(theme.Name);
        var slname = (byte)bname.Length;
        var bPropertyCount = new byte[2];

        oStream.Write((byte)(theme.IsBuiltin ? 0xff : 0));
        oStream.Write(slname);
        oStream.Write(bname, 0, slname);

        SaveSetsOfMaterials(theme, oStream);

        /* placeholder for extension propertybag */
        BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
        oStream.Write(bPropertyCount, 0, 2);
    }

    private static void SaveSetsOfMaterials(MaterialTheme theme, BinaryWriter oStream)
    {
        var bnsom = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnsom, (ushort)theme.SetsOfMaterials.Count);
        oStream.Write(bnsom, 0, 2);

        foreach (var set in theme.SetsOfMaterials)
        {
            SaveSetOfMaterials(set, oStream);
        }
    }

    private static void SaveSetOfMaterials(SetOfMaterials set, BinaryWriter oStream)
    {
        var smedium = set.Medium.ToString();
        var bmedium = Encoding.UTF8.GetBytes(smedium);
        var slmedium = (byte)bmedium.Length;
        var bPropertyCount = new byte[2];

        oStream.Write(slmedium);
        oStream.Write(bmedium, 0, slmedium);

        var bnmat = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnmat, (ushort)set.Materials.Count);
        oStream.Write(bnmat, 0, 2);

        foreach (var mat in set.Materials)
        {
            var bname = Encoding.UTF8.GetBytes(mat.Name);
            var slname = (byte)bname.Length;

            oStream.Write(slname);
            oStream.Write(bname, 0, slname);

            var icolor = mat.Color.ToArgb();
            var bicolor = new byte[4];

            BinaryPrimitives.WriteInt32LittleEndian(bicolor, icolor);
            oStream.Write(bicolor, 0, 4);

            /* placeholder for extension propertybag */
            BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
            oStream.Write(bPropertyCount, 0, 2);
        }

        /* placeholder for extension propertybag */
        BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
        oStream.Write(bPropertyCount, 0, 2);
    }

    private static void SaveAssets(BinaryWriter oStream)
    {
        var bnass = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnass, (ushort)Assets.Count);
        oStream.Write(bnass, 0, 2);

        foreach (var ass in Assets)
        {
            SaveAsset(ass, oStream);
        }
    }

    private static void SaveAsset(Asset ass, BinaryWriter oStream)
    {
        var sAssetClass = ass.Class.ToString();
        var bAssetClass = Encoding.UTF8.GetBytes(sAssetClass);
        var slAssetClass = (byte)bAssetClass.Length;

        oStream.Write(slAssetClass);
        oStream.Write(bAssetClass, 0, slAssetClass);
        oStream.Write(ass.Id.ToByteArray(), 0, 16);
        oStream.Write((byte)(ass.IsBuiltin ? 0xff : 0));

        var bname = Encoding.UTF8.GetBytes(ass.Name);
        var slname = (byte)bname.Length;

        oStream.Write(slname);
        oStream.Write(bname, 0, slname);

        var blIcon = new byte[2];
        var blThumb = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(blIcon, (ushort)ass.Icon.Length);
        BinaryPrimitives.WriteUInt16LittleEndian(blThumb, (ushort)ass.Thumb.Length);

        oStream.Write(blIcon, 0, 2);

        if (ass.Icon.Length != 0)
        {
            oStream.Write(ass.Icon, 0, ass.Icon.Length);
        }

        oStream.Write(blThumb, 0, 2);

        if (ass.Thumb.Length != 0)
        {
            oStream.Write(ass.Thumb, 0, ass.Thumb.Length);
        }

        /* placeholder for extension propertybag */
        var bPropertyCount = new byte[2];
        BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
        oStream.Write(bPropertyCount, 0, 2);
    }

    private static void SaveLevels(BinaryWriter oStream)
    {
        var bnlvl = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnlvl, (ushort)Levels.Count);
        oStream.Write(bnlvl, 0, 2);

        foreach (var level in Levels)
        {
            SaveLevel(level, oStream);
        }
    }

    private static void SaveLevel(LevelBeschreibung level, BinaryWriter oStream)
    {
        var bIsBuiltin = (byte)((level.IsBuiltin ? 1 : 0) << 4);
        var bMissionsNummer = new byte[4];
        var bLevelNummer = new byte[4];
        var bLevelNummerInMission = new byte[4];

        BinaryPrimitives.WriteInt32LittleEndian(bMissionsNummer, level.MissionsNummer);
        BinaryPrimitives.WriteInt32LittleEndian(bLevelNummer, level.LevelNummer);
        BinaryPrimitives.WriteInt32LittleEndian(bLevelNummerInMission, level.LevelNummerInMission);

        oStream.Write(bIsBuiltin);
        oStream.Write(bMissionsNummer, 0, 4);
        oStream.Write(bLevelNummer, 0, 4);
        oStream.Write(bLevelNummerInMission, 0, 4);

        var bWidth = new byte[4];
        var bHeight = new byte[4];
        var bBergZufallszahl = new byte[4];

        BinaryPrimitives.WriteUInt32LittleEndian(bWidth, level.Width);
        BinaryPrimitives.WriteUInt32LittleEndian(bHeight, level.Height);
        BinaryPrimitives.WriteUInt32LittleEndian(bBergZufallszahl, level.Zufallszahl);

        oStream.Write(bWidth, 0, 4);
        oStream.Write(bHeight, 0, 4);
        oStream.Write(bBergZufallszahl, 0, 4);

        var bSpielerPosition1X = new byte[4];
        var bSpielerPosition1Y = new byte[4];
        var bSpielerPosition2X = new byte[4];
        var bSpielerPosition2Y = new byte[4];

        BinaryPrimitives.WriteInt32LittleEndian(bSpielerPosition1X, level.SpielerPosition1.X);
        BinaryPrimitives.WriteInt32LittleEndian(bSpielerPosition1Y, level.SpielerPosition1.Y);
        BinaryPrimitives.WriteInt32LittleEndian(bSpielerPosition2X, level.SpielerPosition2.X);
        BinaryPrimitives.WriteInt32LittleEndian(bSpielerPosition2Y, level.SpielerPosition2.Y);

        oStream.Write(bSpielerPosition1X, 0, 4);
        oStream.Write(bSpielerPosition1Y, 0, 4);
        oStream.Write(bSpielerPosition2X, 0, 4);
        oStream.Write(bSpielerPosition2Y, 0, 4);

        var icolor = level.ColorBackground.ToArgb();
        var bicolor = new byte[4];

        BinaryPrimitives.WriteInt32LittleEndian(bicolor, icolor);
        oStream.Write(bicolor, 0, 4);

        var bNameEn = Encoding.UTF8.GetBytes(level.NameEn);
        var slNameEn = (byte)bNameEn.Length;
        var bNameDe = Encoding.UTF8.GetBytes(level.NameDe);
        var slNameDe = (byte)bNameDe.Length;
        var bNameFi = Encoding.UTF8.GetBytes(level.NameFi);
        var slNameFi = (byte)bNameFi.Length;
        var bNameUa = Encoding.UTF8.GetBytes(level.NameUa);
        var slNameUa = (byte)bNameUa.Length;
        var bAuthor = Encoding.UTF8.GetBytes(level.Author);
        var slAuthor = (byte)bAuthor.Length;
        var bMaterialThemeKey = Encoding.UTF8.GetBytes(level.MaterialThemeKey);
        var slMaterialThemeKey = (byte)bMaterialThemeKey.Length;
        var bBackdropAssetKey = Encoding.UTF8.GetBytes(level.BackdropAssetKey);
        var slBackdropAssetKey = (byte)bBackdropAssetKey.Length;
        var bBeschreibungsSkript = Encoding.UTF8.GetBytes(level.BeschreibungsSkript.Source);
        var slBeschreibungsSkript = (byte)bBeschreibungsSkript.Length;

        oStream.Write(slNameEn);
        oStream.Write(bNameEn, 0, slNameEn);
        oStream.Write(slNameDe);
        oStream.Write(bNameDe, 0, slNameDe);
        oStream.Write(slNameFi);
        oStream.Write(bNameFi, 0, slNameFi);
        oStream.Write(slNameUa);
        oStream.Write(bNameUa, 0, slNameUa);
        oStream.Write(slAuthor);
        oStream.Write(bAuthor, 0, slAuthor);
        oStream.Write(slMaterialThemeKey);
        oStream.Write(bMaterialThemeKey, 0, slMaterialThemeKey);
        oStream.Write(slBackdropAssetKey);
        oStream.Write(bBackdropAssetKey, 0, slBackdropAssetKey);
        oStream.Write(slBeschreibungsSkript);
        oStream.Write(bBeschreibungsSkript, 0, slBeschreibungsSkript);

        var bPlacementCount = new byte[2];
        var bPropertyCount = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bPlacementCount, (ushort)level.AssetPlacement.Count);
        oStream.Write(bPlacementCount, 0, 2);
        foreach(var placement in level.AssetPlacement)
        {
            var bAssetKey = Encoding.UTF8.GetBytes(placement.AssetKey);
            var slAssetKey = (byte)bAssetKey.Length;

            oStream.Write(slAssetKey);
            oStream.Write(bAssetKey, 0, slAssetKey);

            var bLocationX = new byte[4];
            var bLocationY = new byte[4];

            BinaryPrimitives.WriteInt32LittleEndian(bLocationX, placement.Location.X);
            BinaryPrimitives.WriteInt32LittleEndian(bLocationY, placement.Location.Y);

            oStream.Write(bLocationX, 0, 4);
            oStream.Write(bLocationY, 0, 4);
            oStream.Write((byte)(placement.OrientedRtl ? 0xff : 0));

            /* every placements has multiple (typed) property bags */
            var bnParamsUInt = new byte[2];
            var bnParamsInt = new byte[2];
            var bnParamsFlags = new byte[2];
            var bnParamsString = new byte[2];

            BinaryPrimitives.WriteUInt16LittleEndian(bnParamsUInt, (ushort)placement.ParamsUInt.Count);
            BinaryPrimitives.WriteUInt16LittleEndian(bnParamsInt, (ushort)placement.ParamsInt.Count);
            BinaryPrimitives.WriteUInt16LittleEndian(bnParamsFlags, (ushort)placement.ParamsFlags.Count);
            BinaryPrimitives.WriteUInt16LittleEndian(bnParamsString, (ushort)placement.ParamsString.Count);

            oStream.Write(bnParamsUInt, 0, 2);
            oStream.Write(bnParamsInt, 0, 2);
            oStream.Write(bnParamsFlags, 0, 2);
            oStream.Write(bnParamsString, 0, 2);

            foreach(var key in placement.ParamsUInt.Keys)
            {
                var bKey = Encoding.UTF8.GetBytes(key);
                var bValue = new byte[4];

                oStream.Write((byte)bKey.Length);
                oStream.Write(bKey, 0, bKey.Length);

                BinaryPrimitives.WriteUInt32LittleEndian(bValue, placement.ParamsUInt[key]);
                oStream.Write(bValue, 0, 4);
            }

            foreach (var key in placement.ParamsInt.Keys)
            {
                var bKey = Encoding.UTF8.GetBytes(key);
                var bValue = new byte[4];

                oStream.Write((byte)bKey.Length);
                oStream.Write(bKey, 0, bKey.Length);

                BinaryPrimitives.WriteInt32LittleEndian(bValue, placement.ParamsInt[key]);
                oStream.Write(bValue, 0, 4);
            }

            foreach (var key in placement.ParamsFlags.Keys)
            {
                var bKey = Encoding.UTF8.GetBytes(key);

                oStream.Write((byte)bKey.Length);
                oStream.Write(bKey, 0, bKey.Length);
                oStream.Write((byte)(placement.ParamsFlags[key] ? 0xff : 0));
            }

            foreach (var key in placement.ParamsString.Keys)
            {
                var bKey = Encoding.UTF8.GetBytes(key);
                var bValue = Encoding.UTF8.GetBytes(placement.ParamsString[key]);

                oStream.Write((byte)bKey.Length);
                oStream.Write(bKey, 0, bKey.Length);
                oStream.Write((byte)bValue.Length);
                oStream.Write(bValue, 0, bValue.Length);
            }

            /* placeholder for extension propertybag */
            BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
            oStream.Write(bPropertyCount, 0, 2);
        }

        /* placeholder for extension propertybag */
        BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
        oStream.Write(bPropertyCount, 0, 2);
    }

    private static void SaveMissions(BinaryWriter oStream)
    {
        var bnlvl = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnlvl, (ushort)Missions.Count);
        oStream.Write(bnlvl, 0, 2);

        foreach (var mission in Missions)
        {
            SaveMission(mission, oStream);
        }
    }

    private static void SaveMission(MissionDef mission, BinaryWriter oStream)
    {
        var bIsBuiltin = (byte)((mission.IsBuiltin ? 1 : 0) << 4);
        var bMissionsNummer = new byte[4];

        BinaryPrimitives.WriteInt32LittleEndian(bMissionsNummer, mission.MissionsNummer);
        oStream.Write(bIsBuiltin);
        oStream.Write(bMissionsNummer, 0, 4);

        var bNameEn = Encoding.UTF8.GetBytes(mission.NameEn);
        var slNameEn = (byte)bNameEn.Length;
        var bNameDe = Encoding.UTF8.GetBytes(mission.NameDe);
        var slNameDe = (byte)bNameDe.Length;
        var bNameFi = Encoding.UTF8.GetBytes(mission.NameFi);
        var slNameFi = (byte)bNameFi.Length;
        var bNameUa = Encoding.UTF8.GetBytes(mission.NameUa);
        var slNameUa = (byte)bNameUa.Length;

        oStream.Write(slNameEn);
        oStream.Write(bNameEn, 0, slNameEn);
        oStream.Write(slNameDe);
        oStream.Write(bNameDe, 0, slNameDe);
        oStream.Write(slNameFi);
        oStream.Write(bNameFi, 0, slNameFi);
        oStream.Write(slNameUa);
        oStream.Write(bNameUa, 0, slNameUa);

        /* placeholder for extension propertybag */
        var bPropertyCount = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bPropertyCount, 0);
        oStream.Write(bPropertyCount, 0, 2);
    }
}
