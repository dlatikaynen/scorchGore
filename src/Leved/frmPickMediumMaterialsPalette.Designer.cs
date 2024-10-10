namespace ScorchGore.Leved
{
    partial class frmPickMediumMaterialsPalette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPickMediumMaterialsPalette));
            TreeNode treeNode5 = new TreeNode("I.1 Blue Mountains");
            TreeNode treeNode6 = new TreeNode("I. Blue Mountains", new TreeNode[] { treeNode5 });
            TreeNode treeNode7 = new TreeNode("Built-in levels", new TreeNode[] { treeNode6 });
            TreeNode treeNode8 = new TreeNode("dlatikay's levels");
            panel1 = new Panel();
            cmdOk = new Button();
            btnCancel = new Button();
            ilTreeview = new ImageList(components);
            tvSets = new TreeView();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmdOk);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 225);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 54);
            panel1.TabIndex = 0;
            // 
            // cmdOk
            // 
            cmdOk.AccessibleRole = AccessibleRole.PushButton;
            cmdOk.DialogResult = DialogResult.OK;
            cmdOk.Location = new Point(12, 13);
            cmdOk.Name = "cmdOk";
            cmdOk.Size = new Size(86, 30);
            cmdOk.TabIndex = 3;
            cmdOk.Text = "&Ok";
            cmdOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AccessibleRole = AccessibleRole.PushButton;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(104, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
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
            treeNode5.Name = "Node3";
            treeNode5.Text = "I.1 Blue Mountains";
            treeNode6.Name = "Node2";
            treeNode6.Text = "I. Blue Mountains";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Built-in levels";
            treeNode8.Name = "Node1";
            treeNode8.Text = "dlatikay's levels";
            tvSets.Nodes.AddRange(new TreeNode[] { treeNode7, treeNode8 });
            tvSets.PathSeparator = "|";
            tvSets.SelectedImageKey = "folder_open";
            tvSets.Size = new Size(276, 225);
            tvSets.TabIndex = 3;
            // 
            // frmPickMediumMaterialsPalette
            // 
            AcceptButton = cmdOk;
            AccessibleRole = AccessibleRole.Dialog;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(276, 279);
            Controls.Add(tvSets);
            Controls.Add(panel1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPickMediumMaterialsPalette";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Palette Selector";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button cmdOk;
        private Button btnCancel;
        private ImageList ilTreeview;
        private TreeView tvSets;
    }
}