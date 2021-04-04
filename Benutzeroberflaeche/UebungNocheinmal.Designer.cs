
namespace ScorchGore.Benutzeroberflaeche
{
    partial class UebungNocheinmal
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
            this.ErgebnisGewonnen = new System.Windows.Forms.Label();
            this.ErgebnisBesiegt = new System.Windows.Forms.Label();
            this.WeitermachenKnopf = new System.Windows.Forms.Button();
            this.NeueWerteKnopf = new System.Windows.Forms.Button();
            this.BeendenKnopf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ErgebnisGewonnen
            // 
            this.ErgebnisGewonnen.AutoSize = true;
            this.ErgebnisGewonnen.Location = new System.Drawing.Point(12, 9);
            this.ErgebnisGewonnen.Name = "ErgebnisGewonnen";
            this.ErgebnisGewonnen.Size = new System.Drawing.Size(99, 13);
            this.ErgebnisGewonnen.TabIndex = 1;
            this.ErgebnisGewonnen.Text = "{0} won, {1} HP left";
            this.ErgebnisGewonnen.UseMnemonic = false;
            // 
            // ErgebnisBesiegt
            // 
            this.ErgebnisBesiegt.AutoSize = true;
            this.ErgebnisBesiegt.Location = new System.Drawing.Point(12, 27);
            this.ErgebnisBesiegt.Name = "ErgebnisBesiegt";
            this.ErgebnisBesiegt.Size = new System.Drawing.Size(109, 13);
            this.ErgebnisBesiegt.TabIndex = 2;
            this.ErgebnisBesiegt.Text = "{0} noobed out by {1}";
            this.ErgebnisBesiegt.UseMnemonic = false;
            // 
            // WeitermachenKnopf
            // 
            this.WeitermachenKnopf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.WeitermachenKnopf.Location = new System.Drawing.Point(15, 60);
            this.WeitermachenKnopf.Name = "WeitermachenKnopf";
            this.WeitermachenKnopf.Size = new System.Drawing.Size(210, 23);
            this.WeitermachenKnopf.TabIndex = 3;
            this.WeitermachenKnopf.Text = "Keep parameters and continue";
            this.WeitermachenKnopf.UseVisualStyleBackColor = true;
            // 
            // NeueWerteKnopf
            // 
            this.NeueWerteKnopf.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.NeueWerteKnopf.Location = new System.Drawing.Point(15, 89);
            this.NeueWerteKnopf.Name = "NeueWerteKnopf";
            this.NeueWerteKnopf.Size = new System.Drawing.Size(210, 23);
            this.NeueWerteKnopf.TabIndex = 4;
            this.NeueWerteKnopf.Text = "Adjust parameters for next round";
            this.NeueWerteKnopf.UseVisualStyleBackColor = true;
            // 
            // BeendenKnopf
            // 
            this.BeendenKnopf.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.BeendenKnopf.Location = new System.Drawing.Point(15, 118);
            this.BeendenKnopf.Name = "BeendenKnopf";
            this.BeendenKnopf.Size = new System.Drawing.Size(210, 23);
            this.BeendenKnopf.TabIndex = 5;
            this.BeendenKnopf.Text = "Exit to main";
            this.BeendenKnopf.UseVisualStyleBackColor = true;
            // 
            // UebungNocheinmal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 151);
            this.Controls.Add(this.BeendenKnopf);
            this.Controls.Add(this.NeueWerteKnopf);
            this.Controls.Add(this.WeitermachenKnopf);
            this.Controls.Add(this.ErgebnisBesiegt);
            this.Controls.Add(this.ErgebnisGewonnen);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UebungNocheinmal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Drill Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErgebnisGewonnen;
        private System.Windows.Forms.Label ErgebnisBesiegt;
        private System.Windows.Forms.Button WeitermachenKnopf;
        private System.Windows.Forms.Button NeueWerteKnopf;
        private System.Windows.Forms.Button BeendenKnopf;
    }
}