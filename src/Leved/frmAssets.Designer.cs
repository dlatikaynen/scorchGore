namespace ScorchGore.Leved
{
    partial class frmAssets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssets));
            TreeNode treeNode1 = new TreeNode("assets");
            ilTreeview = new ImageList(components);
            tvAssets = new TreeView();
            mnuAssets = new MenuStrip();
            mnuTools = new ToolStripMenuItem();
            mnuAssetAddCsg = new ToolStripMenuItem();
            mnuAssetAddPrefab = new ToolStripMenuItem();
            mnuAssetAddBackdrop = new ToolStripMenuItem();
            mnuAssetsAddSoundEffect = new ToolStripMenuItem();
            mnuAssetAddMusic = new ToolStripMenuItem();
            mnuAssetSeparator = new ToolStripSeparator();
            mnuAssetView = new ToolStripMenuItem();
            mnuAssetEdit = new ToolStripMenuItem();
            mnuAssetDelete = new ToolStripMenuItem();
            mnuAssets.SuspendLayout();
            SuspendLayout();
            // 
            // ilTreeview
            // 
            ilTreeview.ColorDepth = ColorDepth.Depth32Bit;
            ilTreeview.ImageStream = (ImageListStreamer)resources.GetObject("ilTreeview.ImageStream");
            ilTreeview.TransparentColor = Color.Transparent;
            ilTreeview.Images.SetKeyName(0, "folder_closed");
            ilTreeview.Images.SetKeyName(1, "folder_open");
            ilTreeview.Images.SetKeyName(2, "instalment");
            ilTreeview.Images.SetKeyName(3, "asset");
            // 
            // tvAssets
            // 
            tvAssets.BackColor = SystemColors.Control;
            tvAssets.Dock = DockStyle.Fill;
            tvAssets.FullRowSelect = true;
            tvAssets.HideSelection = false;
            tvAssets.ImageKey = "folder_closed";
            tvAssets.ImageList = ilTreeview;
            tvAssets.LabelEdit = true;
            tvAssets.Location = new Point(0, 0);
            tvAssets.Name = "tvAssets";
            treeNode1.Name = "Node1";
            treeNode1.Text = "assets";
            tvAssets.Nodes.AddRange(new TreeNode[] { treeNode1 });
            tvAssets.PathSeparator = "|";
            tvAssets.SelectedImageKey = "folder_open";
            tvAssets.Size = new Size(251, 211);
            tvAssets.TabIndex = 3;
            // 
            // mnuAssets
            // 
            mnuAssets.AccessibleRole = AccessibleRole.MenuBar;
            mnuAssets.Items.AddRange(new ToolStripItem[] { mnuTools });
            mnuAssets.Location = new Point(0, 0);
            mnuAssets.Name = "mnuAssets";
            mnuAssets.Size = new Size(251, 24);
            mnuAssets.TabIndex = 4;
            mnuAssets.Visible = false;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuAssetAddCsg, mnuAssetAddPrefab, mnuAssetAddBackdrop, mnuAssetsAddSoundEffect, mnuAssetAddMusic, mnuAssetSeparator, mnuAssetView, mnuAssetEdit, mnuAssetDelete });
            mnuTools.MergeAction = MergeAction.Insert;
            mnuTools.MergeIndex = 3;
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(55, 20);
            mnuTools.Text = "&Design";
            // 
            // mnuAssetAddCsg
            // 
            mnuAssetAddCsg.Name = "mnuAssetAddCsg";
            mnuAssetAddCsg.Size = new Size(174, 22);
            mnuAssetAddCsg.Text = "Add CSG...";
            // 
            // mnuAssetAddPrefab
            // 
            mnuAssetAddPrefab.Name = "mnuAssetAddPrefab";
            mnuAssetAddPrefab.Size = new Size(174, 22);
            mnuAssetAddPrefab.Text = "Add prefab...";
            // 
            // mnuAssetAddBackdrop
            // 
            mnuAssetAddBackdrop.Name = "mnuAssetAddBackdrop";
            mnuAssetAddBackdrop.Size = new Size(174, 22);
            mnuAssetAddBackdrop.Text = "Add backdrop...";
            mnuAssetAddBackdrop.Click += mnuAssetAddBackdrop_Click;
            // 
            // mnuAssetsAddSoundEffect
            // 
            mnuAssetsAddSoundEffect.Name = "mnuAssetsAddSoundEffect";
            mnuAssetsAddSoundEffect.Size = new Size(174, 22);
            mnuAssetsAddSoundEffect.Text = "Add sound effect...";
            // 
            // mnuAssetAddMusic
            // 
            mnuAssetAddMusic.Name = "mnuAssetAddMusic";
            mnuAssetAddMusic.Size = new Size(174, 22);
            mnuAssetAddMusic.Text = "Add music...";
            // 
            // mnuAssetSeparator
            // 
            mnuAssetSeparator.Name = "mnuAssetSeparator";
            mnuAssetSeparator.Size = new Size(171, 6);
            // 
            // mnuAssetView
            // 
            mnuAssetView.Name = "mnuAssetView";
            mnuAssetView.Size = new Size(174, 22);
            mnuAssetView.Text = "&View...";
            // 
            // mnuAssetEdit
            // 
            mnuAssetEdit.Image = Properties.Resources.properties;
            mnuAssetEdit.Name = "mnuAssetEdit";
            mnuAssetEdit.Size = new Size(174, 22);
            mnuAssetEdit.Text = "&Edit...";
            // 
            // mnuAssetDelete
            // 
            mnuAssetDelete.Name = "mnuAssetDelete";
            mnuAssetDelete.Size = new Size(174, 22);
            mnuAssetDelete.Text = "&Delete";
            // 
            // frmAssets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 211);
            Controls.Add(mnuAssets);
            Controls.Add(tvAssets);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAssets";
            ShowInTaskbar = false;
            Text = "Asset Manager";
            Load += frmAssets_Load;
            mnuAssets.ResumeLayout(false);
            mnuAssets.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList ilTreeview;
        private TreeView tvAssets;
        private MenuStrip mnuAssets;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuAssetsAddSoundEffect;
        private ToolStripMenuItem mnuAssetAddMusic;
        private ToolStripMenuItem mnuAssetAddPrefab;
        private ToolStripMenuItem mnuAssetDelete;
        private ToolStripMenuItem mnuAssetEdit;
        private ToolStripMenuItem mnuAssetAddCsg;
        private ToolStripMenuItem mnuAssetAddBackdrop;
        private ToolStripSeparator mnuAssetSeparator;
        private ToolStripMenuItem mnuAssetView;
    }
}