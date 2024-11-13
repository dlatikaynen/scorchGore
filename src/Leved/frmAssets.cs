using ScorchGore.Classes;
using ScorchGore.Constants;
using ScorchGore.Extensions;
using System.Drawing.Imaging;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmAssets : Form
{
    public frmAssets()
    {
        InitializeComponent();
    }

    private void frmAssets_Load(object sender, EventArgs e)
    {
        tvAssets.Nodes.Clear();
        DesignWorkspace.EnsureDesignWorkspace();

        var builtInAssets = tvAssets.Nodes.AddTranslatableNode(key: "1", µ: 81); // Built-in assets
        var csg = builtInAssets.Nodes.AddTranslatableNode(key: "1.csg", µ: 85); // CSG
        var prefab = builtInAssets.Nodes.AddTranslatableNode(key: "1.prefab", µ: 84); // Prefabs
        var bkdr = builtInAssets.Nodes.AddTranslatableNode(key: "1.bkdr", µ: 87); // Backdrops
        var moo = builtInAssets.Nodes.AddTranslatableNode(key: "1.moo", µ: 88); // Moosic
        var sfx = builtInAssets.Nodes.AddTranslatableNode(key: "1.sfx", µ: 83); // Sfx
        var customAssets = tvAssets.Nodes.AddTranslatableNode(key: "69", µ: 82); // My assets
        var csg_custom = customAssets.Nodes.AddTranslatableNode(key: "69.csg", µ: 85); // CSG
        var prefab_custom = customAssets.Nodes.AddTranslatableNode(key: "69.prefab", µ: 84); // Prefabs
        var bkdr_custom = customAssets.Nodes.AddTranslatableNode(key: "69.bkdr", µ: 87); // Backdrops
        var moo_custom = customAssets.Nodes.AddTranslatableNode(key: "69.moo", µ: 88); // Moosic
        var sfx_custom = customAssets.Nodes.AddTranslatableNode(key: "69.sfx", µ: 83); // Sfx

        builtInAssets.Expand();
        foreach (var asset in DesignWorkspace.Assets)
        {
            switch(asset.Class)
            {
                case AssetClass.Csg:
                    {
                        var container = asset.IsBuiltin ? csg : csg_custom;

                        AddAssetToTree(container, asset);
                    }

                    break;

                case AssetClass.Backdrop:
                    {
                        var container = asset.IsBuiltin ? bkdr : bkdr_custom;

                        AddAssetToTree(container, asset);
                    }

                    break;

                case AssetClass.Prefab:
                    {
                        var container = asset.IsBuiltin ? prefab : prefab_custom;

                        AddAssetToTree(container, asset);
                    }

                    break;
            }
        }

        Xlat.RegisterForTranslation(frmAssets_TranslationChanged);
    }

    private void AddAssetToTree(TreeNode container, Asset asset)
    {
        var bkdrNode = container.Nodes.Add(key: $"{container.Name}.{asset.Id:D}", text: asset.Name);

        if (asset.Icon.Length != 0)
        {
            using var bIcon = new MemoryStream(asset.Icon);
            var icon = Image.FromStream(bIcon);
            var iconKey = $"{asset.Id:D}";

            ilTreeview.Images.Add(iconKey, icon);
            bkdrNode.ImageKey = iconKey;
            bkdrNode.SelectedImageKey = iconKey;
        }
        else
        {
            var icon = "asset";

            if (asset.Class == AssetClass.Sfx)
            {
                icon = "sfx";
            }
            else if (asset.Class == AssetClass.Moosic)
            {
                icon = "music";
            }

            bkdrNode.ImageKey = icon;
            bkdrNode.SelectedImageKey = icon;
        }
    }

    private void frmAssets_TranslationChanged(object sender, Xlat.TranslationChangedEventArgs e)
    {
        Text = Xlat.µ(86); // Asset Manager
        Xlat.TranslateTreeview(tvAssets);
    }

    private void mnuAssetAddCsg_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetAddBackdrop_Click(object sender, EventArgs e)
    {
        AddImageAsset("bkdr", Xlat.µ(110), AssetClass.Backdrop); // Import level backdrop picture
    }

    private void mnuAssetAddPrefab_Click(object sender, EventArgs e)
    {
        AddImageAsset("prefab", Xlat.µ(121), AssetClass.Prefab); // Import prefab asset picture
    }

    private void mnuAssetAddSoundEffect_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetAddMusic_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetView_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetEdit_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetPlace_Click(object sender, EventArgs e)
    {

    }

    private void mnuAssetDelete_Click(object sender, EventArgs e)
    {
        var node = tvAssets.SelectedNode;

        if (node == null)
        {
            return;
        }

        var keyParts = node.Name.Split('.');

        if (keyParts.Length != 3)
        {
            return;
        }

        var folderKey = keyParts[1];
        var assetId = Guid.Parse(keyParts[2]);
        var asset = DesignWorkspace.Assets.Single(a => a.Id == assetId);

        // where is it used?
        var usages = new List<(int levelNr, int missionNr, string levelName, int countUsed)>();
        foreach (var level in DesignWorkspace.Levels)
        {
            var countUsed = level.AssetPlacement.Count(p => p.AssetKey == asset.Name);

            if (countUsed > 0)
            {
                usages.Add((level.LevelNummer, level.MissionsNummer, level.LevelName, countUsed));
            }
        }

        var proceed = usages.Count == 0;
        if (usages.Count > 0)
        {
            using var confirm = new frmConfirmDeleteUsedAsset();

            confirm.Prepare(usages.Select(u =>
            {
                return $"{u.missionNr}/{u.levelNr}: {u.countUsed}x ({u.levelName})";
            }).ToArray(), asset.Class, asset.Name);

            var result = confirm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                proceed = true;
            }
        }

        if (proceed)
        {
            DesignWorkspace.Assets.Remove(asset);
            DesignWorkspace.SetDirty();
            tvAssets.Nodes.Remove(node);

            var localLump = $@".\{assetId:D}.lump";

            try
            {
                if (File.Exists(localLump))
                {
                    File.Delete(localLump);
                }
            }
            catch { }
        }
    }

    private void AddImageAsset(string folderKey, string ofdTitle, AssetClass assetClass)
    {
        var folder = tvAssets.SelectedNode;

        if (folder == null)
        {
            return;
        }

        var keyParts = folder.Name.Split('.');
        var destKey = $"{keyParts[0]}.{folderKey}";
        var destNode = tvAssets.Nodes.Find(destKey, true).SingleOrDefault();
        var isBuiltin = keyParts[0] == "1";

        if(destNode == null)
        {
            return;
        }

        using var ofd = new OpenFileDialog()
        {
            CheckPathExists = true,
            AddExtension = true,
            AddToRecent = true,
            AutoUpgradeEnabled = true,
            ClientGuid = InfrastructureConstants.OfdBackdropPngGuid,
            DefaultExt = "png",
            DereferenceLinks = true,
            Filter = "PNG (*.png)|*.png",
            FilterIndex = 0,
            Multiselect = true,
            ReadOnlyChecked = true,
            ShowPreview = true,
            SupportMultiDottedExtensions = true,
            ValidateNames = true,
            Title = ofdTitle
        };

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            var originalCur = Cursor.Current;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (var file in ofd.FileNames)
                {
                    using var pic = Image.FromFile(file);

                    if (pic == null)
                    {
                        continue;
                    }

                    // extract the icon and the thumbnail
                    using var icon = pic.GetThumbnailImage(16, 16, callback: null, callbackData: IntPtr.Zero);

                    if (icon == null)
                    {
                        continue;
                    }

                    using var thumb = pic.GetThumbnailImage(64, 64, callback: null, callbackData: IntPtr.Zero);

                    if (thumb == null)
                    {
                        continue;
                    }

                    var assetId = Guid.NewGuid();
                    var assetName = UniqueAssetNameFromFile(Path.GetFileNameWithoutExtension(file));
                    var asset = new Asset(assetClass, assetId, isBuiltin, assetName);
                    var imported = $"{assetId:D}.lump";

                    if (Path.GetFileName(file) != imported)
                    {
                        File.Copy(file, $@".\{imported}", overwrite: false);
                    }

                    ilTreeview.Images.Add($"{assetId:D}", icon);

                    using var iconStream = new MemoryStream();

                    icon.Save(iconStream, ImageFormat.Png);
                    if (iconStream.CanSeek)
                    {
                        iconStream.Seek(0, SeekOrigin.Begin);
                    }

                    asset.Icon = iconStream.ToArray();

                    using var thumbStream = new MemoryStream();

                    thumb.Save(thumbStream, ImageFormat.Png);
                    if (thumbStream.CanSeek)
                    {
                        thumbStream.Seek(0, SeekOrigin.Begin);
                    }

                    asset.Thumb = thumbStream.ToArray();

                    var assetNode = destNode.Nodes.Add(key: $"{keyParts[0]}.{folderKey}.{assetId}", text: assetName);

                    assetNode.ImageKey = $"{assetId:D}";
                    assetNode.SelectedImageKey = assetNode.ImageKey;

                    DesignWorkspace.Assets.Add(asset);
                    DesignWorkspace.SetDirty();
                    assetNode.EnsureVisible();
                    tvAssets.SelectedNode = assetNode;
                }
            }
            finally
            {
                Cursor.Current = originalCur;
            }
        }
    }

    private static string UniqueAssetNameFromFile(string file)
    {
        return file.ToUpperInvariant();
    }
}
