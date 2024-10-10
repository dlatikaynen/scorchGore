using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Buffers.Binary;
using System.Text;

namespace ScorchGore.Leved;

internal static class DesignWorkspace
{
    public static List<MaterialTheme> MaterialThemes = [];
    public static List<object> Prefabs = [];
    public static List<LevelBeschreibung> Levels = [];

    private const string WorkspaceFilename = "workspace.sugma";

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
        using var inStream = new FileStream(WorkspaceFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

        LoadMaterialThemes(inStream);
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

        using var oStream = new FileStream(WorkspaceFilename, FileMode.Create, FileAccess.Write, FileShare.Read);

        SaveMaterialThemes(oStream);
        SavePrefabs(oStream);
    }

    private static void LoadMaterialThemes(Stream inStream)
    {
        var bnmth = new byte[2];

        inStream.ReadExactly(bnmth, 0, 2);

        var nmth = BinaryPrimitives.ReadUInt16LittleEndian(bnmth);

        for (var i = 0; i < nmth; ++i)
        {
            LoadMaterialTheme(inStream);
        }
    }

    private static void LoadMaterialTheme(Stream inStream)
    {
        var slname = inStream.ReadByte();
        var bsname = new byte[slname];

        inStream.ReadExactly(bsname, 0, slname);

        var name = Encoding.UTF8.GetString(bsname);
        var sets = new List<SetOfMaterials>();

        LoadSetsOfMaterials(inStream, sets);

        var theme = new MaterialTheme(name, sets);

        MaterialThemes.Add(theme);
    }

    private static void LoadSetsOfMaterials(Stream inStream, List<SetOfMaterials> sets)
    {
        var bnsom = new byte[2];

        inStream.ReadExactly(bnsom, 0, 2);

        var nsom = BinaryPrimitives.ReadUInt16LittleEndian(bnsom);

        for (var i = 0; i < nsom; ++i)
        {
            LoadSetOfMaterials(inStream, sets);
        }
    }

    private static void LoadSetOfMaterials(Stream inStream, List<SetOfMaterials> sets)
    {
        var slmedium = inStream.ReadByte();
        var bsmedium = new byte[slmedium];

        inStream.ReadExactly(bsmedium, 0, slmedium);

        var smedium = Encoding.UTF8.GetString(bsmedium);
        var medium = Enum.Parse<Medium>(smedium);
        var set = new SetOfMaterials(medium, []);

        var bnmat = new byte[2];

        inStream.ReadExactly(bnmat, 0, 2);

        var nmat = BinaryPrimitives.ReadUInt16LittleEndian(bnmat);

        for (var i = 0; i < nmat; ++i)
        {
            var bslname = inStream.ReadByte();
            var bsname = new byte[bslname];

            inStream.ReadExactly(bsname, 0, bslname);

            var sname = Encoding.UTF8.GetString(bsname);
            var bcolor = new byte[4];

            inStream.ReadExactly(bcolor, 0, 4);

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

    private static void SaveMaterialThemes(Stream oStream)
    {
        var bnmth = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnmth, (ushort)MaterialThemes.Count);
        oStream.Write(bnmth, 0, 2);

        foreach (var theme in MaterialThemes)
        {
            SaveMaterialTheme(theme, oStream);
        }
    }

    private static void SaveMaterialTheme(MaterialTheme theme, Stream oStream)
    {
        var bname = Encoding.UTF8.GetBytes(theme.Name);
        var slname = (byte)bname.Length;

        oStream.WriteByte(slname);
        oStream.Write(bname, 0, slname);

        SaveSetsOfMaterials(theme, oStream);
    }

    private static void SaveSetsOfMaterials(MaterialTheme theme, Stream oStream)
    {
        var bnsom = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnsom, (ushort)theme.SetsOfMaterials.Count);
        oStream.Write(bnsom, 0, 2);

        foreach (var set in theme.SetsOfMaterials)
        {
            SaveSetOfMaterials(set, oStream);
        }
    }

    private static void SaveSetOfMaterials(SetOfMaterials set, Stream oStream)
    {
        var smedium = set.Medium.ToString();
        var bmedium = Encoding.UTF8.GetBytes(smedium);
        var slmedium = (byte)bmedium.Length;

        oStream.WriteByte(slmedium);
        oStream.Write(bmedium, 0, slmedium);

        var bnmat = new byte[2];

        BinaryPrimitives.WriteUInt16LittleEndian(bnmat, (ushort)set.Materials.Count);
        oStream.Write(bnmat, 0, 2);

        foreach (var mat in set.Materials)
        {
            var bname = Encoding.UTF8.GetBytes(mat.Name);
            var slname = (byte)bname.Length;

            oStream.WriteByte(slname);
            oStream.Write(bname, 0, slname);

            var icolor = mat.Color.ToArgb();
            var bicolor = new byte[4];

            BinaryPrimitives.WriteInt32LittleEndian(bicolor, icolor);
            oStream.Write(bicolor, 0, 4);
        }
    }

    private static void SavePrefabs(Stream oStream)
    {

    }

    private static void SavePrefab(Stream oStream)
    {

    }
}
