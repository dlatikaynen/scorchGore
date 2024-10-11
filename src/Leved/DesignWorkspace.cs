using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Buffers.Binary;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace ScorchGore.Leved;

internal static class DesignWorkspace
{
    public static List<MaterialTheme> MaterialThemes = [];
    public static List<object> Prefabs = [];
    public static List<LevelBeschreibung> Levels = [];

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

        LoadMaterialThemes(brd);
        LoadPrefabs();

        if (MaterialThemes.Count == 0)
        {
            MaterialThemes.Add(new("WOTMSTD", []));
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

        SaveMaterialThemes(bwr);
        SavePrefabs(bwr);
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
        var slname = inStream.ReadByte();
        var bname = inStream.ReadBytes(slname);
        var name = Encoding.UTF8.GetString(bname);
        var sets = new List<SetOfMaterials>();

        LoadSetsOfMaterials(inStream, sets);

        var theme = new MaterialTheme(name, sets);

        MaterialThemes.Add(theme);
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
        }

        sets.Add(set);
    }

    private static void LoadPrefabs()
    {

    }

    private static void LoadPrefab()
    {

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

        oStream.Write(slname);
        oStream.Write(bname, 0, slname);

        SaveSetsOfMaterials(theme, oStream);
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
        }
    }

    private static void SavePrefabs(BinaryWriter oStream)
    {

    }

    private static void SavePrefab(BinaryWriter oStream)
    {

    }
}
