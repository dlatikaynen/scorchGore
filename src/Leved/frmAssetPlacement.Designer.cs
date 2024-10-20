namespace ScorchGore.Forms
{
    partial class frmAssetPlacement
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
            TreeNode treeNode1 = new TreeNode("placement");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssetPlacement));
            scMaterials = new SplitContainer();
            tvPlacement = new TreeView();
            ilTreeview = new ImageList(components);
            lblHint = new Label();
            mnuAssetPlacement = new MenuStrip();
            mnuTools = new ToolStripMenuItem();
            mnuToolsAddLevel = new ToolStripMenuItem();
            mnuToolsEditLevel = new ToolStripMenuItem();
            mnuToolsPlaytestLevel = new ToolStripMenuItem();
            mnuToolsDeleteLevel = new ToolStripMenuItem();
            mnuToolsLevelProperties = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)scMaterials).BeginInit();
            scMaterials.Panel1.SuspendLayout();
            scMaterials.Panel2.SuspendLayout();
            scMaterials.SuspendLayout();
            mnuAssetPlacement.SuspendLayout();
            SuspendLayout();
            // 
            // scMaterials
            // 
            scMaterials.Dock = DockStyle.Fill;
            scMaterials.IsSplitterFixed = true;
            scMaterials.Location = new Point(0, 0);
            scMaterials.Name = "scMaterials";
            scMaterials.Orientation = Orientation.Horizontal;
            // 
            // scMaterials.Panel1
            // 
            scMaterials.Panel1.Controls.Add(tvPlacement);
            // 
            // scMaterials.Panel2
            // 
            scMaterials.Panel2.Controls.Add(lblHint);
            scMaterials.Size = new Size(275, 390);
            scMaterials.SplitterDistance = 277;
            scMaterials.TabIndex = 4;
            // 
            // tvPlacement
            // 
            tvPlacement.BackColor = SystemColors.Control;
            tvPlacement.Dock = DockStyle.Fill;
            tvPlacement.FullRowSelect = true;
            tvPlacement.HideSelection = false;
            tvPlacement.ImageIndex = 0;
            tvPlacement.ImageList = ilTreeview;
            tvPlacement.LabelEdit = true;
            tvPlacement.Location = new Point(0, 0);
            tvPlacement.Name = "tvPlacement";
            treeNode1.Name = "Node";
            treeNode1.Text = "placement";
            tvPlacement.Nodes.AddRange(new TreeNode[] { treeNode1 });
            tvPlacement.PathSeparator = "|";
            tvPlacement.SelectedImageIndex = 0;
            tvPlacement.Size = new Size(275, 277);
            tvPlacement.TabIndex = 2;
            // 
            // ilTreeview
            // 
            ilTreeview.ColorDepth = ColorDepth.Depth32Bit;
            ilTreeview.ImageStream = (ImageListStreamer)resources.GetObject("ilTreeview.ImageStream");
            ilTreeview.TransparentColor = Color.Transparent;
            ilTreeview.Images.SetKeyName(0, "mat");
            ilTreeview.Images.SetKeyName(1, "level");
            ilTreeview.Images.SetKeyName(2, "asset");
            // 
            // lblHint
            // 
            lblHint.BorderStyle = BorderStyle.Fixed3D;
            lblHint.Dock = DockStyle.Fill;
            lblHint.Location = new Point(0, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(275, 109);
            lblHint.TabIndex = 3;
            lblHint.Text = "Assets are placed";
            lblHint.UseMnemonic = false;
            // 
            // mnuAssetPlacement
            // 
            mnuAssetPlacement.AccessibleRole = AccessibleRole.MenuBar;
            mnuAssetPlacement.Items.AddRange(new ToolStripItem[] { mnuTools });
            mnuAssetPlacement.Location = new Point(12, 183);
            mnuAssetPlacement.Name = "mnuAssetPlacement";
            mnuAssetPlacement.Size = new Size(251, 24);
            mnuAssetPlacement.TabIndex = 6;
            mnuAssetPlacement.Visible = false;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuToolsAddLevel, mnuToolsEditLevel, mnuToolsPlaytestLevel, mnuToolsDeleteLevel, mnuToolsLevelProperties });
            mnuTools.MergeAction = MergeAction.Insert;
            mnuTools.MergeIndex = 3;
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(55, 20);
            mnuTools.Text = "&Design";
            // 
            // mnuToolsAddLevel
            // 
            mnuToolsAddLevel.Name = "mnuToolsAddLevel";
            mnuToolsAddLevel.Size = new Size(157, 22);
            mnuToolsAddLevel.Text = "Add level";
            // 
            // mnuToolsEditLevel
            // 
            mnuToolsEditLevel.Name = "mnuToolsEditLevel";
            mnuToolsEditLevel.Size = new Size(157, 22);
            mnuToolsEditLevel.Text = "Edit level";
            // 
            // mnuToolsPlaytestLevel
            // 
            mnuToolsPlaytestLevel.Name = "mnuToolsPlaytestLevel";
            mnuToolsPlaytestLevel.Size = new Size(157, 22);
            mnuToolsPlaytestLevel.Text = "Playtest level";
            // 
            // mnuToolsDeleteLevel
            // 
            mnuToolsDeleteLevel.Name = "mnuToolsDeleteLevel";
            mnuToolsDeleteLevel.Size = new Size(157, 22);
            mnuToolsDeleteLevel.Text = "Delete level";
            // 
            // mnuToolsLevelProperties
            // 
            mnuToolsLevelProperties.Image = Properties.Resources.properties;
            mnuToolsLevelProperties.Name = "mnuToolsLevelProperties";
            mnuToolsLevelProperties.Size = new Size(157, 22);
            mnuToolsLevelProperties.Text = "Level properties";
            // 
            // frmAssetPlacement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 390);
            Controls.Add(mnuAssetPlacement);
            Controls.Add(scMaterials);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAssetPlacement";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Asset Placement";
            FormClosing += frmAssetPlacement_FormClosing;
            scMaterials.Panel1.ResumeLayout(false);
            scMaterials.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMaterials).EndInit();
            scMaterials.ResumeLayout(false);
            mnuAssetPlacement.ResumeLayout(false);
            mnuAssetPlacement.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer scMaterials;
        private TreeView tvPlacement;
        private Label lblHint;
        private MenuStrip mnuAssetPlacement;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuToolsAddLevel;
        private ToolStripMenuItem mnuToolsEditLevel;
        private ToolStripMenuItem mnuToolsPlaytestLevel;
        private ToolStripMenuItem mnuToolsDeleteLevel;
        private ToolStripMenuItem mnuToolsLevelProperties;
        private ImageList ilTreeview;
    }
}