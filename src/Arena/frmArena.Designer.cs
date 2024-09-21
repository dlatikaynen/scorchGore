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
            pnlArena = new Panel();
            SuspendLayout();
            // 
            // pnlArena
            // 
            pnlArena.BackColor = SystemColors.WindowText;
            pnlArena.CausesValidation = false;
            pnlArena.Location = new Point(70, 61);
            pnlArena.Margin = new Padding(0);
            pnlArena.Name = "pnlArena";
            pnlArena.Size = new Size(101, 52);
            pnlArena.TabIndex = 0;
            pnlArena.MouseDown += pnlArena_MouseDown;
            pnlArena.MouseMove += pnlArena_MouseMove;
            pnlArena.MouseUp += pnlArena_MouseUp;
            // 
            // frmArena
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            CausesValidation = false;
            ClientSize = new Size(640, 480);
            ControlBox = false;
            Controls.Add(pnlArena);
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximumSize = new Size(640, 480);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmArena";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmArena_FormClosing;
            Load += frmArena_Load;
            KeyDown += frmArena_KeyDown;
            KeyUp += frmArena_KeyUp;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlArena;
    }
}