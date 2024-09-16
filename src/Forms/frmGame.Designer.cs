namespace ScorchGore.Forms
{
    partial class frmGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            mnuGame = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            enterToolStripMenuItem = new ToolStripMenuItem();
            leaveToolStripMenuItem = new ToolStripMenuItem();
            abortToolStripMenuItem = new ToolStripMenuItem();
            lblStatusLabel = new Label();
            lblStatus = new Label();
            lblTurnLabel = new Label();
            lblTurn = new Label();
            lblCommand = new Label();
            lblOomph = new Label();
            txtCommand = new TextBox();
            txtOomph = new TextBox();
            mnuGame.SuspendLayout();
            SuspendLayout();
            // 
            // mnuGame
            // 
            mnuGame.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            resources.ApplyResources(mnuGame, "mnuGame");
            mnuGame.Name = "mnuGame";
            mnuGame.RenderMode = ToolStripRenderMode.Professional;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enterToolStripMenuItem, leaveToolStripMenuItem, abortToolStripMenuItem });
            gameToolStripMenuItem.MergeAction = MergeAction.Insert;
            gameToolStripMenuItem.MergeIndex = 2;
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            resources.ApplyResources(gameToolStripMenuItem, "gameToolStripMenuItem");
            // 
            // enterToolStripMenuItem
            // 
            enterToolStripMenuItem.Name = "enterToolStripMenuItem";
            resources.ApplyResources(enterToolStripMenuItem, "enterToolStripMenuItem");
            // 
            // leaveToolStripMenuItem
            // 
            leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            resources.ApplyResources(leaveToolStripMenuItem, "leaveToolStripMenuItem");
            // 
            // abortToolStripMenuItem
            // 
            abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            resources.ApplyResources(abortToolStripMenuItem, "abortToolStripMenuItem");
            // 
            // lblStatusLabel
            // 
            resources.ApplyResources(lblStatusLabel, "lblStatusLabel");
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.UseMnemonic = false;
            // 
            // lblStatus
            // 
            resources.ApplyResources(lblStatus, "lblStatus");
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Name = "lblStatus";
            lblStatus.UseMnemonic = false;
            // 
            // lblTurnLabel
            // 
            resources.ApplyResources(lblTurnLabel, "lblTurnLabel");
            lblTurnLabel.Name = "lblTurnLabel";
            lblTurnLabel.UseMnemonic = false;
            // 
            // lblTurn
            // 
            resources.ApplyResources(lblTurn, "lblTurn");
            lblTurn.BackColor = Color.Transparent;
            lblTurn.Name = "lblTurn";
            lblTurn.UseMnemonic = false;
            // 
            // lblCommand
            // 
            resources.ApplyResources(lblCommand, "lblCommand");
            lblCommand.Name = "lblCommand";
            // 
            // lblOomph
            // 
            resources.ApplyResources(lblOomph, "lblOomph");
            lblOomph.Name = "lblOomph";
            // 
            // txtCommand
            // 
            txtCommand.HideSelection = false;
            resources.ApplyResources(txtCommand, "txtCommand");
            txtCommand.Name = "txtCommand";
            txtCommand.ReadOnly = true;
            // 
            // txtOomph
            // 
            txtOomph.HideSelection = false;
            resources.ApplyResources(txtOomph, "txtOomph");
            txtOomph.Name = "txtOomph";
            txtOomph.ReadOnly = true;
            // 
            // frmGame
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtOomph);
            Controls.Add(txtCommand);
            Controls.Add(lblOomph);
            Controls.Add(lblCommand);
            Controls.Add(lblTurn);
            Controls.Add(lblTurnLabel);
            Controls.Add(lblStatus);
            Controls.Add(lblStatusLabel);
            Controls.Add(mnuGame);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            KeyPreview = true;
            MainMenuStrip = mnuGame;
            MaximizeBox = false;
            Name = "frmGame";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            mnuGame.ResumeLayout(false);
            mnuGame.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuGame;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem enterToolStripMenuItem;
        private ToolStripMenuItem leaveToolStripMenuItem;
        private ToolStripMenuItem abortToolStripMenuItem;
        private Label lblStatusLabel;
        private Label lblStatus;
        private Label lblTurnLabel;
        private Label lblTurn;
        private Label lblCommand;
        private Label lblOomph;
        private TextBox txtCommand;
        private TextBox txtOomph;
    }
}