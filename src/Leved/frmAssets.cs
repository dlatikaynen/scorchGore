﻿using ScorchGore.Classes;
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
        _ = customAssets.Nodes.AddTranslatableNode(key: "69.csg", µ: 85); // CSG
        _ = customAssets.Nodes.AddTranslatableNode(key: "69.prefab", µ: 84); // Prefabs
        _ = customAssets.Nodes.AddTranslatableNode(key: "69.bkdr", µ: 87); // Backdrops
        _ = customAssets.Nodes.AddTranslatableNode(key: "69.moo", µ: 88); // Moosic
        _ = customAssets.Nodes.AddTranslatableNode(key: "69.sfx", µ: 83); // Sfx

        builtInAssets.Expand();
        foreach(var asset in DesignWorkspace.Assets)
        {
            switch(asset.Class)
            {
                case AssetClass.Backdrop:
                    var bkdrNode = bkdr.Nodes.Add(key: $"{bkdr.Name}.{asset.Id:D}", text: asset.Name);

                    if (asset.Icon.Length != 0)
                    {
                        using var bIcon = new MemoryStream(asset.Icon);
                        var icon = Image.FromStream(bIcon);
                        var iconKey = $"{asset.Id:D}";

                        ilTreeview.Images.Add(iconKey, icon);
                        bkdrNode.ImageKey = iconKey;
                        bkdrNode.SelectedImageKey = iconKey;
                    }

                    break;
            }
        }

        Xlat.RegisterForTranslation(frmAssets_TranslationChanged);
    }

    private void frmAssets_TranslationChanged(object sender, Xlat.TranslationChangedEventArgs e)
    {
        Text = Xlat.µ(86); // Asset Manager
        Xlat.TranslateTreeview(tvAssets);
    }

    private void mnuAssetAddBackdrop_Click(object sender, EventArgs e)
    {
        var folder = tvAssets.SelectedNode;
        
        if (folder == null)
        {
            return;
        }

        var keyParts = folder.Name.Split('.');
        var destKey = $"{keyParts[0]}.bkdr";
        var destNode = tvAssets.Nodes.Find(destKey, true).SingleOrDefault();

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
            Title = "kjk"
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
                    var asset = new Classes.Asset(Classes.AssetClass.Backdrop, assetId, assetName);
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

                    var assetNode = destNode.Nodes.Add(key: $"{keyParts[0]}.bkdr.{assetId}", text: assetName);

                    assetNode.ImageKey = $"{assetId:D}";
                    assetNode.SelectedImageKey = assetNode.ImageKey;

                    DesignWorkspace.Assets.Add(asset);
                    assetNode.EnsureVisible();
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
