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
            TreeNode treeNode2 = new TreeNode("assets");
            ilTreeview = new ImageList(components);
            tvAssets = new TreeView();
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
            ilTreeview.Images.SetKeyName(3, "assets.ico");
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
            treeNode2.Name = "Node1";
            treeNode2.Text = "assets";
            tvAssets.Nodes.AddRange(new TreeNode[] { treeNode2 });
            tvAssets.PathSeparator = "|";
            tvAssets.SelectedImageKey = "folder_open";
            tvAssets.Size = new Size(251, 211);
            tvAssets.TabIndex = 3;
            // 
            // frmAssets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 211);
            Controls.Add(tvAssets);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAssets";
            ShowInTaskbar = false;
            Text = "Asset Manager";
            Load += frmAssets_Load;
            ResumeLayout(false);
        }

        #endregion

        private ImageList ilTreeview;
        private TreeView tvAssets;
    }
}