namespace ScorchGore.Leved
{
    partial class frmLevelManager
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
            TreeNode treeNode1 = new TreeNode("I.1 Blue Mountains");
            TreeNode treeNode2 = new TreeNode("I. Blue Mountains", new TreeNode[] { treeNode1 });
            TreeNode treeNode3 = new TreeNode("Built-in levels", new TreeNode[] { treeNode2 });
            TreeNode treeNode4 = new TreeNode("dlatikay's levels");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLevelManager));
            tvLevels = new TreeView();
            ilTreeview = new ImageList(components);
            mnuLeved = new MenuStrip();
            mnuTools = new ToolStripMenuItem();
            mnuToolsAddLevel = new ToolStripMenuItem();
            mnuToolsEditLevel = new ToolStripMenuItem();
            mnuToolsPlaytestLevel = new ToolStripMenuItem();
            mnuToolsDeleteLevel = new ToolStripMenuItem();
            mnuToolsLevelProperties = new ToolStripMenuItem();
            mnuLeved.SuspendLayout();
            SuspendLayout();
            // 
            // tvLevels
            // 
            tvLevels.BackColor = SystemColors.Control;
            tvLevels.Dock = DockStyle.Fill;
            tvLevels.FullRowSelect = true;
            tvLevels.HideSelection = false;
            tvLevels.ImageKey = "folder_closed";
            tvLevels.ImageList = ilTreeview;
            tvLevels.LabelEdit = true;
            tvLevels.Location = new Point(0, 0);
            tvLevels.Name = "tvLevels";
            treeNode1.Name = "Node3";
            treeNode1.Text = "I.1 Blue Mountains";
            treeNode2.Name = "Node2";
            treeNode2.Text = "I. Blue Mountains";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Built-in levels";
            treeNode4.Name = "Node1";
            treeNode4.Text = "dlatikay's levels";
            tvLevels.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode4 });
            tvLevels.PathSeparator = "|";
            tvLevels.SelectedImageKey = "folder_open";
            tvLevels.Size = new Size(251, 211);
            tvLevels.TabIndex = 0;
            tvLevels.NodeMouseDoubleClick += tvLevels_NodeMouseDoubleClick;
            // 
            // ilTreeview
            // 
            ilTreeview.ColorDepth = ColorDepth.Depth32Bit;
            ilTreeview.ImageStream = (ImageListStreamer)resources.GetObject("ilTreeview.ImageStream");
            ilTreeview.TransparentColor = Color.Transparent;
            ilTreeview.Images.SetKeyName(0, "a_flower");
            ilTreeview.Images.SetKeyName(1, "folder_closed");
            ilTreeview.Images.SetKeyName(2, "folder_open");
            ilTreeview.Images.SetKeyName(3, "instalment");
            ilTreeview.Images.SetKeyName(4, "map");
            ilTreeview.Images.SetKeyName(5, "mission");
            // 
            // mnuLeved
            // 
            mnuLeved.AccessibleRole = AccessibleRole.MenuBar;
            mnuLeved.Items.AddRange(new ToolStripItem[] { mnuTools });
            mnuLeved.Location = new Point(0, 0);
            mnuLeved.Name = "mnuLeved";
            mnuLeved.Size = new Size(251, 24);
            mnuLeved.TabIndex = 1;
            mnuLeved.Visible = false;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuToolsAddLevel, mnuToolsEditLevel, mnuToolsPlaytestLevel, mnuToolsDeleteLevel, mnuToolsLevelProperties });
            mnuTools.MergeAction = MergeAction.Insert;
            mnuTools.MergeIndex = 2;
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
            mnuToolsEditLevel.Click += mnuToolsEditLevel_Click;
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
            mnuToolsLevelProperties.Name = "mnuToolsLevelProperties";
            mnuToolsLevelProperties.Size = new Size(157, 22);
            mnuToolsLevelProperties.Text = "Level properties";
            // 
            // frmLevelManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 211);
            Controls.Add(tvLevels);
            Controls.Add(mnuLeved);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuLeved;
            Name = "frmLevelManager";
            Text = "Level Manager";
            Load += frmLevelManager_Load;
            mnuLeved.ResumeLayout(false);
            mnuLeved.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tvLevels;
        private ImageList ilTreeview;
        private MenuStrip mnuLeved;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuToolsAddLevel;
        private ToolStripMenuItem mnuToolsEditLevel;
        private ToolStripMenuItem mnuToolsPlaytestLevel;
        private ToolStripMenuItem mnuToolsDeleteLevel;
        private ToolStripMenuItem mnuToolsLevelProperties;
    }
}