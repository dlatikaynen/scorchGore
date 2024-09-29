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
            TreeNode treeNode5 = new TreeNode("I.1 Blue Mountains");
            TreeNode treeNode6 = new TreeNode("I. Blue Mountains", new TreeNode[] { treeNode5 });
            TreeNode treeNode7 = new TreeNode("Built-in levels", new TreeNode[] { treeNode6 });
            TreeNode treeNode8 = new TreeNode("dlatikay's levels");
            tvLevels = new TreeView();
            SuspendLayout();
            // 
            // tvLevels
            // 
            tvLevels.Dock = DockStyle.Fill;
            tvLevels.FullRowSelect = true;
            tvLevels.HideSelection = false;
            tvLevels.LabelEdit = true;
            tvLevels.Location = new Point(0, 0);
            tvLevels.Name = "tvLevels";
            treeNode5.Name = "Node3";
            treeNode5.Text = "I.1 Blue Mountains";
            treeNode6.Name = "Node2";
            treeNode6.Text = "I. Blue Mountains";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Built-in levels";
            treeNode8.Name = "Node1";
            treeNode8.Text = "dlatikay's levels";
            tvLevels.Nodes.AddRange(new TreeNode[] { treeNode7, treeNode8 });
            tvLevels.PathSeparator = "|";
            tvLevels.Size = new Size(251, 211);
            tvLevels.TabIndex = 0;
            tvLevels.NodeMouseDoubleClick += tvLevels_NodeMouseDoubleClick;
            // 
            // frmLevelManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 211);
            Controls.Add(tvLevels);
            Name = "frmLevelManager";
            Text = "Level Manager";
            Load += frmLevelManager_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvLevels;
    }
}