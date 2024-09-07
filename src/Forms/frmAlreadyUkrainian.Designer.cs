namespace ScorchGore.Forms
{
    partial class frmAlreadyUkrainian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlreadyUkrainian));
            btnCancel = new Button();
            lblInfo = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ImeMode = ImeMode.NoControl;
            btnCancel.Location = new Point(12, 98);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "За&крити";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(12, 12);
            lblInfo.Multiline = true;
            lblInfo.Name = "lblInfo";
            lblInfo.ReadOnly = true;
            lblInfo.Size = new Size(306, 80);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Ми зробили все можливе. Нашому маленькому діаспорному дилетанту-українцю не стане краще, якщо кілька разів натиснути на вибір мови.\r\n";
            // 
            // frmAlreadyUkrainian
            // 
            AcceptButton = btnCancel;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnCancel;
            ClientSize = new Size(329, 139);
            Controls.Add(btnCancel);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(41, 19, 41, 19);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAlreadyUkrainian";
            ShowInTaskbar = false;
            Text = "Вже рідна мова";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private TextBox lblInfo;
    }
}