namespace ScorchGore.Arena
{
    partial class frmArena
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
            pnlViewport = new Panel();
            pnlArena = new Panel();
            pnlViewport.SuspendLayout();
            SuspendLayout();
            // 
            // pnlViewport
            // 
            pnlViewport.BackColor = Color.FromArgb(16, 16, 16);
            pnlViewport.BackgroundImageLayout = ImageLayout.None;
            pnlViewport.BorderStyle = BorderStyle.FixedSingle;
            pnlViewport.Controls.Add(pnlArena);
            pnlViewport.Dock = DockStyle.Fill;
            pnlViewport.Location = new Point(60, 60);
            pnlViewport.Margin = new Padding(0);
            pnlViewport.Name = "pnlViewport";
            pnlViewport.Size = new Size(530, 360);
            pnlViewport.TabIndex = 0;
            // 
            // pnlArena
            // 
            pnlArena.BackColor = Color.White;
            pnlArena.BackgroundImageLayout = ImageLayout.Stretch;
            pnlArena.CausesValidation = false;
            pnlArena.Cursor = Cursors.Cross;
            pnlArena.Location = new Point(66, 68);
            pnlArena.Margin = new Padding(0);
            pnlArena.Name = "pnlArena";
            pnlArena.Size = new Size(200, 100);
            pnlArena.TabIndex = 0;
            // 
            // frmArena
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Window;
            BackgroundImage = Properties.Resources.penrose_nontiling;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(650, 450);
            Controls.Add(pnlViewport);
            DoubleBuffered = true;
            HelpButton = true;
            KeyPreview = true;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmArena";
            Padding = new Padding(60, 60, 60, 30);
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmArena";
            Load += frmArena_Load;
            SizeChanged += frmArena_SizeChanged;
            KeyDown += frmArena_KeyDown;
            pnlViewport.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlViewport;
        private Panel pnlArena;
    }
}