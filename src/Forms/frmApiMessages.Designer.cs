﻿namespace ScorchGore.Forms
{
    partial class frmApiMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApiMessages));
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // txtOutput
            // 
            txtOutput.AccessibleRole = AccessibleRole.Text;
            txtOutput.BackColor = SystemColors.WindowText;
            txtOutput.Dock = DockStyle.Fill;
            txtOutput.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutput.ForeColor = SystemColors.Window;
            txtOutput.Location = new Point(0, 0);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new Size(576, 147);
            txtOutput.TabIndex = 0;
            txtOutput.Text = "OHAI";
            txtOutput.WordWrap = false;
            // 
            // frmApiMessages
            // 
            AccessibleRole = AccessibleRole.Pane;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.WindowText;
            ClientSize = new Size(576, 147);
            Controls.Add(txtOutput);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmApiMessages";
            ShowInTaskbar = false;
            Text = "Multiplayer comm log";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtOutput;
    }
}