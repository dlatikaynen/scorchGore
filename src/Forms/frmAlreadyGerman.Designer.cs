namespace ScorchGore.Forms
{
    partial class frmAlreadyGerman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlreadyGerman));
            btnCancel = new Button();
            lblInfo = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&Verstanden";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(12, 12);
            lblInfo.Multiline = true;
            lblInfo.Name = "lblInfo";
            lblInfo.ReadOnly = true;
            lblInfo.Size = new Size(409, 132);
            lblInfo.TabIndex = 2;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // frmAlreadyGerman
            // 
            AcceptButton = btnCancel;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnCancel;
            ClientSize = new Size(433, 188);
            Controls.Add(btnCancel);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAlreadyGerman";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Alter, deutscher wirds nicht, vong Sprache her";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private TextBox lblInfo;
    }
}