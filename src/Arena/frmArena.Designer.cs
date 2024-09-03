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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArena));
            pnlViewport = new Panel();
            SuspendLayout();
            // 
            // pnlViewport
            // 
            pnlViewport.BorderStyle = BorderStyle.Fixed3D;
            resources.ApplyResources(pnlViewport, "pnlViewport");
            pnlViewport.Name = "pnlViewport";
            pnlViewport.Paint += pnlViewport_Paint;
            // 
            // frmArena
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Window;
            BackgroundImage = Properties.Resources.penrose_nontiling;
            Controls.Add(pnlViewport);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmArena";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += frmArena_Load;
            KeyDown += frmArena_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlViewport;
    }
}