namespace ScorchGore.Forms
{
    partial class frmInitiateGame
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
            label1 = new Label();
            lblToken = new TextBox();
            btnCopy = new Button();
            btnCancel = new Button();
            label2 = new Label();
            pgbWaitJoin = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(201, 15);
            label1.TabIndex = 0;
            label1.Text = "Forward this &token to your opponent";
            // 
            // lblToken
            // 
            lblToken.Font = new Font("Courier New", 9F, FontStyle.Bold);
            lblToken.HideSelection = false;
            lblToken.Location = new Point(12, 27);
            lblToken.Name = "lblToken";
            lblToken.ReadOnly = true;
            lblToken.Size = new Size(294, 21);
            lblToken.TabIndex = 0;
            lblToken.TextAlign = HorizontalAlignment.Center;
            lblToken.WordWrap = false;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(12, 54);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(90, 25);
            btnCopy.TabIndex = 2;
            btnCopy.Text = "Cop&y";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 222);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(294, 50);
            label2.TabIndex = 5;
            label2.Text = "On the other end, open the File > Join Game menu, and paste the token there.";
            label2.UseMnemonic = false;
            // 
            // pgbWaitJoin
            // 
            pgbWaitJoin.Enabled = false;
            pgbWaitJoin.ForeColor = Color.Orchid;
            pgbWaitJoin.Location = new Point(12, 149);
            pgbWaitJoin.MarqueeAnimationSpeed = 11;
            pgbWaitJoin.Name = "pgbWaitJoin";
            pgbWaitJoin.RightToLeft = RightToLeft.Yes;
            pgbWaitJoin.RightToLeftLayout = true;
            pgbWaitJoin.Size = new Size(292, 67);
            pgbWaitJoin.Style = ProgressBarStyle.Marquee;
            pgbWaitJoin.TabIndex = 6;
            pgbWaitJoin.Value = 10;
            // 
            // frmInitiateGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(318, 264);
            Controls.Add(pgbWaitJoin);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnCopy);
            Controls.Add(lblToken);
            Controls.Add(label1);
            DoubleBuffered = true;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInitiateGame";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Initiate a new online game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox lblToken;
        private Button btnCopy;
        private Button btnCancel;
        private Label label2;
        private ProgressBar pgbWaitJoin;
    }
}