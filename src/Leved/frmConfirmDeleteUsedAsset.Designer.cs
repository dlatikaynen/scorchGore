namespace ScorchGore.Leved
{
    partial class frmConfirmDeleteUsedAsset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmDeleteUsedAsset));
            cmdOk = new Button();
            btnCancel = new Button();
            this.lblPrompt = new Label();
            lblUsages = new Label();
            lstUsages = new ListBox();
            SuspendLayout();
            // 
            // cmdOk
            // 
            cmdOk.DialogResult = DialogResult.OK;
            cmdOk.Location = new Point(12, 218);
            cmdOk.Name = "cmdOk";
            cmdOk.Size = new Size(86, 30);
            cmdOk.TabIndex = 1;
            cmdOk.Text = "&Yes";
            cmdOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(104, 218);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new Point(11, 190);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new Size(147, 15);
            this.lblPrompt.TabIndex = 4;
            this.lblPrompt.Text = "Proceed to delete anyway?";
            // 
            // lblUsages
            // 
            lblUsages.AutoSize = true;
            lblUsages.Location = new Point(12, 9);
            lblUsages.Name = "lblUsages";
            lblUsages.Size = new Size(146, 15);
            lblUsages.TabIndex = 7;
            lblUsages.Text = "The \"{0}\" {1} asset it in use:";
            // 
            // lstUsages
            // 
            lstUsages.FormattingEnabled = true;
            lstUsages.ItemHeight = 15;
            lstUsages.Location = new Point(12, 31);
            lstUsages.Name = "lstUsages";
            lstUsages.Size = new Size(265, 139);
            lstUsages.TabIndex = 2;
            // 
            // frmConfirmDeleteUsedAsset
            // 
            AcceptButton = cmdOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(289, 260);
            Controls.Add(lstUsages);
            Controls.Add(lblUsages);
            Controls.Add(cmdOk);
            Controls.Add(btnCancel);
            Controls.Add(this.lblPrompt);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfirmDeleteUsedAsset";
            ShowInTaskbar = false;
            Text = "Delete used asset";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdOk;
        private Button btnCancel;
        private Label lblPrompt;
        private Label lblUsages;
        private ListBox lstUsages;
    }
}