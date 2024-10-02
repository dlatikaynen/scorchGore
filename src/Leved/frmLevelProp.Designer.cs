namespace ScorchGore.Leved
{
    partial class frmLevelProp
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
            ppgTable = new PropertyGrid();
            SuspendLayout();
            // 
            // ppgTable
            // 
            ppgTable.Dock = DockStyle.Fill;
            ppgTable.Location = new Point(0, 0);
            ppgTable.Name = "ppgTable";
            ppgTable.Size = new Size(286, 424);
            ppgTable.TabIndex = 0;
            // 
            // frmLevelProp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 424);
            Controls.Add(ppgTable);
            Name = "frmLevelProp";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Level Properties";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid ppgTable;
    }
}