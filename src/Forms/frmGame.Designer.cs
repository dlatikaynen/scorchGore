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
            // frmGame
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mnuGame);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
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
    }
}