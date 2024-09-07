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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInitiateGame));
            label1 = new Label();
            lblToken = new TextBox();
            btnCopy = new Button();
            btnCancel = new Button();
            label2 = new Label();
            pgbWaitJoin = new ProgressBar();
            label3 = new Label();
            label4 = new Label();
            optScissors = new RadioButton();
            optStone = new RadioButton();
            optPaper = new RadioButton();
            optWell = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 145);
            label1.Name = "label1";
            label1.Size = new Size(201, 15);
            label1.TabIndex = 0;
            label1.Text = "Forward this &token to your opponent";
            // 
            // lblToken
            // 
            lblToken.Font = new Font("Courier New", 9F, FontStyle.Bold);
            lblToken.HideSelection = false;
            lblToken.Location = new Point(12, 163);
            lblToken.Name = "lblToken";
            lblToken.ReadOnly = true;
            lblToken.Size = new Size(294, 21);
            lblToken.TabIndex = 4;
            lblToken.TextAlign = HorizontalAlignment.Center;
            lblToken.WordWrap = false;
            // 
            // btnCopy
            // 
            btnCopy.Enabled = false;
            btnCopy.Location = new Point(12, 190);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(90, 25);
            btnCopy.TabIndex = 5;
            btnCopy.Text = "Cop&y";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 331);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.Location = new Point(12, 227);
            label2.Name = "label2";
            label2.Size = new Size(294, 41);
            label2.TabIndex = 5;
            label2.Text = "On the other end, open the File > Join Game menu, and paste the token there.";
            label2.UseMnemonic = false;
            // 
            // pgbWaitJoin
            // 
            pgbWaitJoin.Enabled = false;
            pgbWaitJoin.ForeColor = Color.Orchid;
            pgbWaitJoin.Location = new Point(12, 271);
            pgbWaitJoin.MarqueeAnimationSpeed = 11;
            pgbWaitJoin.Name = "pgbWaitJoin";
            pgbWaitJoin.RightToLeft = RightToLeft.Yes;
            pgbWaitJoin.RightToLeftLayout = true;
            pgbWaitJoin.Size = new Size(292, 54);
            pgbWaitJoin.Style = ProgressBarStyle.Continuous;
            pgbWaitJoin.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(232, 15);
            label3.TabIndex = 0;
            label3.Text = "Stone, paper, scissors over who will go first";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 24);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 8;
            label4.Text = "(with well®)";
            // 
            // optScissors
            // 
            optScissors.AutoSize = true;
            optScissors.Location = new Point(12, 42);
            optScissors.Name = "optScissors";
            optScissors.Size = new Size(60, 19);
            optScissors.TabIndex = 1;
            optScissors.TabStop = true;
            optScissors.Text = "Sc&here";
            optScissors.UseVisualStyleBackColor = true;
            optScissors.CheckedChanged += optScissors_CheckedChanged;
            // 
            // optStone
            // 
            optStone.AutoSize = true;
            optStone.Location = new Point(12, 67);
            optStone.Name = "optStone";
            optStone.Size = new Size(51, 19);
            optStone.TabIndex = 2;
            optStone.TabStop = true;
            optStone.Text = "&Stein";
            optStone.UseVisualStyleBackColor = true;
            optStone.CheckedChanged += optStone_CheckedChanged;
            // 
            // optPaper
            // 
            optPaper.AutoSize = true;
            optPaper.Location = new Point(12, 92);
            optPaper.Name = "optPaper";
            optPaper.Size = new Size(58, 19);
            optPaper.TabIndex = 3;
            optPaper.TabStop = true;
            optPaper.Text = "&Papier";
            optPaper.UseVisualStyleBackColor = true;
            optPaper.CheckedChanged += optPaper_CheckedChanged;
            // 
            // optWell
            // 
            optWell.AutoSize = true;
            optWell.Location = new Point(12, 117);
            optWell.Name = "optWell";
            optWell.Size = new Size(70, 19);
            optWell.TabIndex = 4;
            optWell.TabStop = true;
            optWell.Text = "&Brunnen";
            optWell.UseVisualStyleBackColor = true;
            optWell.CheckedChanged += optWell_CheckedChanged;
            // 
            // frmInitiateGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(318, 371);
            Controls.Add(optWell);
            Controls.Add(optPaper);
            Controls.Add(optStone);
            Controls.Add(optScissors);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pgbWaitJoin);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnCopy);
            Controls.Add(lblToken);
            Controls.Add(label1);
            DoubleBuffered = true;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Label label3;
        private Label label4;
        private RadioButton optScissors;
        private RadioButton optStone;
        private RadioButton optPaper;
        private RadioButton optWell;
    }
}