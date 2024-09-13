namespace ScorchGore.Forms
{
    partial class frmAlreadyFinnish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlreadyFinnish));
            btnHylkaa = new Button();
            lblInfo = new TextBox();
            SuspendLayout();
            // 
            // btnHylkaa
            // 
            btnHylkaa.DialogResult = DialogResult.Cancel;
            btnHylkaa.Location = new Point(12, 278);
            btnHylkaa.Name = "btnHylkaa";
            btnHylkaa.Size = new Size(86, 30);
            btnHylkaa.TabIndex = 0;
            btnHylkaa.Text = "H&ylkää";
            btnHylkaa.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(12, 12);
            lblInfo.Multiline = true;
            lblInfo.Name = "lblInfo";
            lblInfo.ReadOnly = true;
            lblInfo.Size = new Size(383, 260);
            lblInfo.TabIndex = 6;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            lblInfo.TextChanged += lblInfo_TextChanged;
            // 
            // frmAlreadyFinnish
            // 
            AcceptButton = btnHylkaa;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnHylkaa;
            ClientSize = new Size(406, 320);
            Controls.Add(btnHylkaa);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAlreadyFinnish";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Tietyn kielen tarpeeton vaatiminen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHylkaa;
        private TextBox lblInfo;
    }
}