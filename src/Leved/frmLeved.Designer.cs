namespace ScorchGore.Leved
{
    partial class frmLeved
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeved));
            SuspendLayout();
            // 
            // frmLeved
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
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
            Name = "frmLeved";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmLeved_Load;
            KeyDown += frmLeved_KeyDown;
            KeyUp += frmLeved_KeyUp;
            MouseDown += frmLeved_MouseDown;
            MouseMove += frmLeved_MouseMove;
            MouseUp += frmLeved_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}