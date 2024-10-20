namespace ScorchGore.Forms
{
    partial class frmUnsavedData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnsavedData));
            cmdCancel = new Button();
            cmdNo = new Button();
            cmdYes = new Button();
            lblHint = new Label();
            SuspendLayout();
            // 
            // cmdCancel
            // 
            cmdCancel.DialogResult = DialogResult.Cancel;
            cmdCancel.Location = new Point(95, 217);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(136, 47);
            cmdCancel.TabIndex = 1;
            cmdCancel.Text = "Hold your horses";
            cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdNo
            // 
            cmdNo.BackColor = Color.Crimson;
            cmdNo.DialogResult = DialogResult.No;
            cmdNo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            cmdNo.ForeColor = SystemColors.ControlLightLight;
            cmdNo.Location = new Point(180, 159);
            cmdNo.Name = "cmdNo";
            cmdNo.Size = new Size(134, 29);
            cmdNo.TabIndex = 2;
            cmdNo.TabStop = false;
            cmdNo.Text = "Lost, it will be";
            cmdNo.UseVisualStyleBackColor = false;
            cmdNo.MouseEnter += cmdNo_MouseEnter;
            // 
            // cmdYes
            // 
            cmdYes.DialogResult = DialogResult.Yes;
            cmdYes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cmdYes.Location = new Point(12, 92);
            cmdYes.Name = "cmdYes";
            cmdYes.Size = new Size(189, 41);
            cmdYes.TabIndex = 0;
            cmdYes.Text = "SAVE IT NOW";
            cmdYes.UseVisualStyleBackColor = true;
            // 
            // lblHint
            // 
            lblHint.Location = new Point(10, 12);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(304, 77);
            lblHint.TabIndex = 3;
            lblHint.Text = resources.GetString("lblHint.Text");
            // 
            // frmUnsavedData
            // 
            AcceptButton = cmdYes;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cmdCancel;
            ClientSize = new Size(326, 276);
            Controls.Add(lblHint);
            Controls.Add(cmdYes);
            Controls.Add(cmdNo);
            Controls.Add(cmdCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUnsavedData";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Unsaved Data";
            ResumeLayout(false);
        }

        #endregion

        private Button cmdCancel;
        private Button cmdNo;
        private Button cmdYes;
        private Label lblHint;
    }
}