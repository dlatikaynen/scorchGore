namespace ScorchGore.Leved
{
    partial class frmMaterials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterials));
            TreeNode treeNode2 = new TreeNode("themes");
            ilTreeview = new ImageList(components);
            scMaterials = new SplitContainer();
            tvSets = new TreeView();
            lblHint = new Label();
            mnuMaterialThemes = new MenuStrip();
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
            mnuMaterialThemes.SuspendLayout();
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
            ilTreeview.Images.SetKeyName(3, "mat");
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
            scMaterials.Panel1.Controls.Add(tvSets);
            // 
            // scMaterials.Panel2
            // 
            scMaterials.Panel2.Controls.Add(lblHint);
            scMaterials.Size = new Size(251, 211);
            scMaterials.SplitterDistance = 150;
            scMaterials.TabIndex = 3;
            // 
            // tvSets
            // 
            tvSets.BackColor = SystemColors.Control;
            tvSets.Dock = DockStyle.Fill;
            tvSets.FullRowSelect = true;
            tvSets.HideSelection = false;
            tvSets.ImageKey = "folder_closed";
            tvSets.ImageList = ilTreeview;
            tvSets.LabelEdit = true;
            tvSets.Location = new Point(0, 0);
            tvSets.Name = "tvSets";
            treeNode2.Name = "Node1";
            treeNode2.Text = "themes";
            tvSets.Nodes.AddRange(new TreeNode[] { treeNode2 });
            tvSets.PathSeparator = "|";
            tvSets.SelectedImageKey = "folder_open";
            tvSets.Size = new Size(251, 150);
            tvSets.TabIndex = 2;
            tvSets.NodeMouseDoubleClick += tvSets_NodeMouseDoubleClick;
            // 
            // lblHint
            // 
            lblHint.BorderStyle = BorderStyle.Fixed3D;
            lblHint.Dock = DockStyle.Fill;
            lblHint.Location = new Point(0, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(251, 57);
            lblHint.TabIndex = 3;
            lblHint.Text = "Every material theme defines a palette for each type of material. Multiple levels can use the same set of materials.";
            lblHint.UseMnemonic = false;
            // 
            // mnuMaterialThemes
            // 
            mnuMaterialThemes.AccessibleRole = AccessibleRole.MenuBar;
            mnuMaterialThemes.Items.AddRange(new ToolStripItem[] { mnuTools });
            mnuMaterialThemes.Location = new Point(0, 93);
            mnuMaterialThemes.Name = "mnuMaterialThemes";
            mnuMaterialThemes.Size = new Size(251, 24);
            mnuMaterialThemes.TabIndex = 5;
            mnuMaterialThemes.Visible = false;
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
            // frmMaterials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 211);
            Controls.Add(mnuMaterialThemes);
            Controls.Add(scMaterials);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMaterials";
            Text = "Material Themes";
            Load += frmMaterials_Load;
            scMaterials.Panel1.ResumeLayout(false);
            scMaterials.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMaterials).EndInit();
            scMaterials.ResumeLayout(false);
            mnuMaterialThemes.ResumeLayout(false);
            mnuMaterialThemes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList ilTreeview;
        private SplitContainer scMaterials;
        private TreeView tvSets;
        private Label lblHint;
        private MenuStrip mnuMaterialThemes;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuToolsAddLevel;
        private ToolStripMenuItem mnuToolsEditLevel;
        private ToolStripMenuItem mnuToolsPlaytestLevel;
        private ToolStripMenuItem mnuToolsDeleteLevel;
        private ToolStripMenuItem mnuToolsLevelProperties;
    }
}