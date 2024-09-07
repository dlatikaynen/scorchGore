namespace ScorchGore.Forms
{
    partial class frmJoinGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJoinGame));
            label1 = new Label();
            txtToken = new TextBox();
            btnPaste = new Button();
            btnCancel = new Button();
            pgbWaitJoin = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter the &token that you received:";
            // 
            // txtToken
            // 
            txtToken.Font = new Font("Courier New", 9F, FontStyle.Bold);
            txtToken.HideSelection = false;
            txtToken.Location = new Point(12, 27);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(294, 21);
            txtToken.TabIndex = 0;
            txtToken.TextAlign = HorizontalAlignment.Center;
            txtToken.WordWrap = false;
            txtToken.TextChanged += txtToken_TextChanged;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(12, 54);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(90, 25);
            btnPaste.TabIndex = 2;
            btnPaste.Text = "&Paste";
            btnPaste.UseVisualStyleBackColor = true;
            btnPaste.Click += btnPaste_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pgbWaitJoin
            // 
            pgbWaitJoin.ForeColor = Color.Orchid;
            pgbWaitJoin.Location = new Point(12, 107);
            pgbWaitJoin.MarqueeAnimationSpeed = 11;
            pgbWaitJoin.Name = "pgbWaitJoin";
            pgbWaitJoin.RightToLeft = RightToLeft.Yes;
            pgbWaitJoin.RightToLeftLayout = true;
            pgbWaitJoin.Size = new Size(292, 67);
            pgbWaitJoin.Style = ProgressBarStyle.Continuous;
            pgbWaitJoin.TabIndex = 6;
            // 
            // frmJoinGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(318, 221);
            Controls.Add(pgbWaitJoin);
            Controls.Add(btnCancel);
            Controls.Add(btnPaste);
            Controls.Add(txtToken);
            Controls.Add(label1);
            DoubleBuffered = true;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmJoinGame";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Join an online game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtToken;
        private Button btnPaste;
        private Button btnCancel;
        private ProgressBar pgbWaitJoin;
    }
}