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
            lblEnterToken = new Label();
            txtToken = new TextBox();
            btnPaste = new Button();
            btnCancel = new Button();
            pgbWaitJoin = new ProgressBar();
            lblWithWell = new Label();
            lblSSP = new Label();
            optWell = new RadioButton();
            optPaper = new RadioButton();
            optStone = new RadioButton();
            optScissors = new RadioButton();
            SuspendLayout();
            // 
            // lblEnterToken
            // 
            lblEnterToken.AutoSize = true;
            lblEnterToken.Location = new Point(12, 157);
            lblEnterToken.Name = "lblEnterToken";
            lblEnterToken.Size = new Size(270, 15);
            lblEnterToken.TabIndex = 0;
            lblEnterToken.Text = "Enter the &token you received from the other party:";
            // 
            // txtToken
            // 
            txtToken.Font = new Font("Courier New", 9F, FontStyle.Bold);
            txtToken.HideSelection = false;
            txtToken.Location = new Point(15, 175);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(294, 21);
            txtToken.TabIndex = 0;
            txtToken.TextAlign = HorizontalAlignment.Center;
            txtToken.WordWrap = false;
            txtToken.TextChanged += txtToken_TextChanged;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(15, 202);
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
            btnCancel.Location = new Point(12, 328);
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
            pgbWaitJoin.Location = new Point(15, 255);
            pgbWaitJoin.MarqueeAnimationSpeed = 11;
            pgbWaitJoin.Name = "pgbWaitJoin";
            pgbWaitJoin.RightToLeft = RightToLeft.Yes;
            pgbWaitJoin.RightToLeftLayout = true;
            pgbWaitJoin.Size = new Size(292, 67);
            pgbWaitJoin.Style = ProgressBarStyle.Continuous;
            pgbWaitJoin.TabIndex = 6;
            // 
            // lblWithWell
            // 
            lblWithWell.AutoSize = true;
            lblWithWell.Location = new Point(12, 24);
            lblWithWell.Name = "lblWithWell";
            lblWithWell.Size = new Size(73, 15);
            lblWithWell.TabIndex = 10;
            lblWithWell.Text = "(with well®)";
            // 
            // lblSSP
            // 
            lblSSP.AutoSize = true;
            lblSSP.Location = new Point(12, 9);
            lblSSP.Name = "lblSSP";
            lblSSP.Size = new Size(232, 15);
            lblSSP.TabIndex = 9;
            lblSSP.Text = "Stone, paper, scissors over who will go first";
            // 
            // optWell
            // 
            optWell.AutoSize = true;
            optWell.Location = new Point(12, 117);
            optWell.Name = "optWell";
            optWell.Size = new Size(70, 19);
            optWell.TabIndex = 14;
            optWell.TabStop = true;
            optWell.Text = "&Brunnen";
            optWell.UseVisualStyleBackColor = true;
            // 
            // optPaper
            // 
            optPaper.AutoSize = true;
            optPaper.Location = new Point(12, 92);
            optPaper.Name = "optPaper";
            optPaper.Size = new Size(58, 19);
            optPaper.TabIndex = 13;
            optPaper.TabStop = true;
            optPaper.Text = "&Papier";
            optPaper.UseVisualStyleBackColor = true;
            // 
            // optStone
            // 
            optStone.AutoSize = true;
            optStone.Location = new Point(12, 67);
            optStone.Name = "optStone";
            optStone.Size = new Size(51, 19);
            optStone.TabIndex = 12;
            optStone.TabStop = true;
            optStone.Text = "&Stein";
            optStone.UseVisualStyleBackColor = true;
            // 
            // optScissors
            // 
            optScissors.AutoSize = true;
            optScissors.Location = new Point(12, 42);
            optScissors.Name = "optScissors";
            optScissors.Size = new Size(60, 19);
            optScissors.TabIndex = 11;
            optScissors.TabStop = true;
            optScissors.Text = "Sc&here";
            optScissors.UseVisualStyleBackColor = true;
            // 
            // frmJoinGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(320, 369);
            Controls.Add(optWell);
            Controls.Add(optPaper);
            Controls.Add(optStone);
            Controls.Add(optScissors);
            Controls.Add(lblWithWell);
            Controls.Add(lblSSP);
            Controls.Add(pgbWaitJoin);
            Controls.Add(btnCancel);
            Controls.Add(btnPaste);
            Controls.Add(txtToken);
            Controls.Add(lblEnterToken);
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

        private Label lblEnterToken;
        private TextBox txtToken;
        private Button btnPaste;
        private Button btnCancel;
        private ProgressBar pgbWaitJoin;
        private Label lblWithWell;
        private Label lblSSP;
        private RadioButton optWell;
        private RadioButton optPaper;
        private RadioButton optStone;
        private RadioButton optScissors;
    }
}