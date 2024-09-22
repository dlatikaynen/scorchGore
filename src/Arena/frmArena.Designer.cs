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
            SuspendLayout();
            // 
            // frmArena
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            CausesValidation = false;
            ClientSize = new Size(640, 480);
            ControlBox = false;
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
            Load += frmArena_Load;
            KeyDown += frmArena_KeyDown;
            KeyUp += frmArena_KeyUp;
            MouseDown += frmArena_MouseDown;
            MouseMove += frmArena_MouseMove;
            MouseUp += frmArena_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}