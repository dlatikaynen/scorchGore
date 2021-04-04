
namespace ScorchGore.Benutzeroberflaeche
{
    partial class Einstellungen
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
            System.Windows.Forms.RadioButton UnsinnigerRadio;
            this.label1 = new System.Windows.Forms.Label();
            this.AbbrechenKnopf = new System.Windows.Forms.Button();
            this.SpeichernKnopf = new System.Windows.Forms.Button();
            this.NamensBeschriftung = new System.Windows.Forms.Label();
            this.NamensEingabe = new System.Windows.Forms.TextBox();
            UnsinnigerRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "What made you think that a game like this would have any useful settings which yo" +
    "u could configure? Is that not a bit too much to ask for? I mean, we can\'t reall" +
    "y be bothered, can we?";
            // 
            // AbbrechenKnopf
            // 
            this.AbbrechenKnopf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbbrechenKnopf.Location = new System.Drawing.Point(12, 266);
            this.AbbrechenKnopf.Name = "AbbrechenKnopf";
            this.AbbrechenKnopf.Size = new System.Drawing.Size(79, 83);
            this.AbbrechenKnopf.TabIndex = 1;
            this.AbbrechenKnopf.Text = "&I\'d get out of here, if I were you";
            this.AbbrechenKnopf.UseVisualStyleBackColor = true;
            // 
            // SpeichernKnopf
            // 
            this.SpeichernKnopf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SpeichernKnopf.Location = new System.Drawing.Point(12, 355);
            this.SpeichernKnopf.Name = "SpeichernKnopf";
            this.SpeichernKnopf.Size = new System.Drawing.Size(79, 83);
            this.SpeichernKnopf.TabIndex = 2;
            this.SpeichernKnopf.Text = "Save &it if you must. You have been warned.";
            this.SpeichernKnopf.UseVisualStyleBackColor = true;
            // 
            // UnsinnigerRadio
            // 
            UnsinnigerRadio.Location = new System.Drawing.Point(107, 329);
            UnsinnigerRadio.Name = "UnsinnigerRadio";
            UnsinnigerRadio.Size = new System.Drawing.Size(98, 48);
            UnsinnigerRadio.TabIndex = 3;
            UnsinnigerRadio.TabStop = true;
            UnsinnigerRadio.Text = "This &is here because it\'s nice";
            UnsinnigerRadio.UseVisualStyleBackColor = false;
            // 
            // NamensBeschriftung
            // 
            this.NamensBeschriftung.Location = new System.Drawing.Point(12, 106);
            this.NamensBeschriftung.Name = "NamensBeschriftung";
            this.NamensBeschriftung.Size = new System.Drawing.Size(136, 43);
            this.NamensBeschriftung.TabIndex = 4;
            this.NamensBeschriftung.Text = "Wr&ite here. A name or something - idk I\'m not a genealogist ";
            // 
            // NamensEingabe
            // 
            this.NamensEingabe.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.NamensEingabe.HideSelection = false;
            this.NamensEingabe.Location = new System.Drawing.Point(14, 152);
            this.NamensEingabe.MaxLength = 19;
            this.NamensEingabe.Name = "NamensEingabe";
            this.NamensEingabe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NamensEingabe.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.NamensEingabe.Size = new System.Drawing.Size(190, 20);
            this.NamensEingabe.TabIndex = 0;
            // 
            // Einstellungen
            // 
            this.AcceptButton = this.SpeichernKnopf;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.AbbrechenKnopf;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(217, 450);
            this.Controls.Add(this.NamensEingabe);
            this.Controls.Add(this.NamensBeschriftung);
            this.Controls.Add(UnsinnigerRadio);
            this.Controls.Add(this.SpeichernKnopf);
            this.Controls.Add(this.AbbrechenKnopf);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Einstellungen";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Misconfiguration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AbbrechenKnopf;
        private System.Windows.Forms.Button SpeichernKnopf;
        private System.Windows.Forms.Label NamensBeschriftung;
        private System.Windows.Forms.TextBox NamensEingabe;
    }
}