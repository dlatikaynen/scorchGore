using System.Windows.Forms;

namespace ScorchGore
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.WeltErzeugen = new System.Windows.Forms.Panel();
            this.StartCloud = new System.Windows.Forms.Button();
            this.StartOffline = new System.Windows.Forms.Button();
            this.RauheitsfaktorProzent = new System.Windows.Forms.TrackBar();
            this.HoechstHoeheProzent = new System.Windows.Forms.TrackBar();
            this.MindesthoeheProzent = new System.Windows.Forms.TrackBar();
            this.MountainosityFactorLabel = new System.Windows.Forms.Label();
            this.MaximumElevationLabel = new System.Windows.Forms.Label();
            this.MinimumElevationLabel = new System.Windows.Forms.Label();
            this.ScorchGore = new System.Windows.Forms.Label();
            this.Copyright = new System.Windows.Forms.TextBox();
            this.PlayerNames = new System.Windows.Forms.Label();
            this.AufGegnerWarten = new Durchsichtig();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CloudVerbindung = new Durchsichtig();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MitspielerFindenFortschritt = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SchussEingabefeld = new Durchsichtig();
            this.Ladung = new System.Windows.Forms.TextBox();
            this.Winkel = new System.Windows.Forms.TextBox();
            this.NameDesDranSeienden = new System.Windows.Forms.Label();
            this.OomphLabel = new DurchsichtigesLabel();
            this.CommandLabel = new DurchsichtigesLabel();
            this.WeltErzeugen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RauheitsfaktorProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoechstHoeheProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MindesthoeheProzent)).BeginInit();
            this.AufGegnerWarten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.CloudVerbindung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SchussEingabefeld.SuspendLayout();
            this.SuspendLayout();
            // 
            // WeltErzeugen
            // 
            this.WeltErzeugen.BackColor = System.Drawing.Color.Tomato;
            this.WeltErzeugen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WeltErzeugen.Controls.Add(this.StartCloud);
            this.WeltErzeugen.Controls.Add(this.StartOffline);
            this.WeltErzeugen.Controls.Add(this.RauheitsfaktorProzent);
            this.WeltErzeugen.Controls.Add(this.HoechstHoeheProzent);
            this.WeltErzeugen.Controls.Add(this.MindesthoeheProzent);
            this.WeltErzeugen.Controls.Add(this.MountainosityFactorLabel);
            this.WeltErzeugen.Controls.Add(this.MaximumElevationLabel);
            this.WeltErzeugen.Controls.Add(this.MinimumElevationLabel);
            this.WeltErzeugen.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.WeltErzeugen.Location = new System.Drawing.Point(12, 88);
            this.WeltErzeugen.Name = "WeltErzeugen";
            this.WeltErzeugen.Size = new System.Drawing.Size(299, 240);
            this.WeltErzeugen.TabIndex = 0;
            this.WeltErzeugen.Visible = false;
            // 
            // StartCloud
            // 
            this.StartCloud.BackColor = System.Drawing.Color.CornflowerBlue;
            this.StartCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartCloud.Location = new System.Drawing.Point(184, 204);
            this.StartCloud.Margin = new System.Windows.Forms.Padding(2);
            this.StartCloud.Name = "StartCloud";
            this.StartCloud.Size = new System.Drawing.Size(102, 23);
            this.StartCloud.TabIndex = 8;
            this.StartCloud.Text = "CLOUD";
            this.StartCloud.UseVisualStyleBackColor = false;
            this.StartCloud.Click += new System.EventHandler(this.StartCloud_Click);
            // 
            // StartOffline
            // 
            this.StartOffline.BackColor = System.Drawing.Color.Magenta;
            this.StartOffline.Location = new System.Drawing.Point(8, 204);
            this.StartOffline.Margin = new System.Windows.Forms.Padding(2);
            this.StartOffline.Name = "StartOffline";
            this.StartOffline.Size = new System.Drawing.Size(102, 23);
            this.StartOffline.TabIndex = 7;
            this.StartOffline.Text = "O f f l i n e";
            this.StartOffline.UseVisualStyleBackColor = false;
            this.StartOffline.Click += new System.EventHandler(this.StartOffline_Click);
            // 
            // RauheitsfaktorProzent
            // 
            this.RauheitsfaktorProzent.AutoSize = false;
            this.RauheitsfaktorProzent.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.RauheitsfaktorProzent.Location = new System.Drawing.Point(3, 155);
            this.RauheitsfaktorProzent.Maximum = 100;
            this.RauheitsfaktorProzent.Name = "RauheitsfaktorProzent";
            this.RauheitsfaktorProzent.Size = new System.Drawing.Size(289, 28);
            this.RauheitsfaktorProzent.SmallChange = 5;
            this.RauheitsfaktorProzent.TabIndex = 6;
            this.RauheitsfaktorProzent.TickFrequency = 10;
            this.RauheitsfaktorProzent.Value = 26;
            // 
            // HoechstHoeheProzent
            // 
            this.HoechstHoeheProzent.AutoSize = false;
            this.HoechstHoeheProzent.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.HoechstHoeheProzent.Location = new System.Drawing.Point(2, 93);
            this.HoechstHoeheProzent.Maximum = 100;
            this.HoechstHoeheProzent.Name = "HoechstHoeheProzent";
            this.HoechstHoeheProzent.Size = new System.Drawing.Size(289, 28);
            this.HoechstHoeheProzent.SmallChange = 5;
            this.HoechstHoeheProzent.TabIndex = 5;
            this.HoechstHoeheProzent.TickFrequency = 10;
            this.HoechstHoeheProzent.Value = 65;
            // 
            // MindesthoeheProzent
            // 
            this.MindesthoeheProzent.AutoSize = false;
            this.MindesthoeheProzent.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.MindesthoeheProzent.Location = new System.Drawing.Point(2, 32);
            this.MindesthoeheProzent.Maximum = 100;
            this.MindesthoeheProzent.Name = "MindesthoeheProzent";
            this.MindesthoeheProzent.Size = new System.Drawing.Size(289, 28);
            this.MindesthoeheProzent.SmallChange = 5;
            this.MindesthoeheProzent.TabIndex = 4;
            this.MindesthoeheProzent.TickFrequency = 10;
            this.MindesthoeheProzent.Value = 5;
            // 
            // MountainosityFactorLabel
            // 
            this.MountainosityFactorLabel.AutoSize = true;
            this.MountainosityFactorLabel.BackColor = System.Drawing.Color.Tomato;
            this.MountainosityFactorLabel.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MountainosityFactorLabel.Location = new System.Drawing.Point(3, 123);
            this.MountainosityFactorLabel.Name = "MountainosityFactorLabel";
            this.MountainosityFactorLabel.Size = new System.Drawing.Size(255, 28);
            this.MountainosityFactorLabel.TabIndex = 3;
            this.MountainosityFactorLabel.Text = "Mountainosity factor";
            // 
            // MaximumElevationLabel
            // 
            this.MaximumElevationLabel.AutoSize = true;
            this.MaximumElevationLabel.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumElevationLabel.Location = new System.Drawing.Point(3, 63);
            this.MaximumElevationLabel.Name = "MaximumElevationLabel";
            this.MaximumElevationLabel.Size = new System.Drawing.Size(209, 28);
            this.MaximumElevationLabel.TabIndex = 1;
            this.MaximumElevationLabel.Text = "Maximum height";
            // 
            // MinimumElevationLabel
            // 
            this.MinimumElevationLabel.AutoSize = true;
            this.MinimumElevationLabel.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumElevationLabel.Location = new System.Drawing.Point(3, 0);
            this.MinimumElevationLabel.Name = "MinimumElevationLabel";
            this.MinimumElevationLabel.Size = new System.Drawing.Size(236, 28);
            this.MinimumElevationLabel.TabIndex = 0;
            this.MinimumElevationLabel.Text = "Minimum elevation";
            // 
            // ScorchGore
            // 
            this.ScorchGore.AutoSize = true;
            this.ScorchGore.Font = new System.Drawing.Font("Times New Roman", 70F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScorchGore.ForeColor = System.Drawing.Color.Crimson;
            this.ScorchGore.Location = new System.Drawing.Point(12, 9);
            this.ScorchGore.Name = "ScorchGore";
            this.ScorchGore.Size = new System.Drawing.Size(713, 104);
            this.ScorchGore.TabIndex = 1;
            this.ScorchGore.Text = "SCORCH GORE";
            // 
            // Copyright
            // 
            this.Copyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Copyright.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Copyright.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Copyright.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copyright.Location = new System.Drawing.Point(535, 406);
            this.Copyright.Multiline = true;
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(315, 100);
            this.Copyright.TabIndex = 2;
            this.Copyright.TabStop = false;
            this.Copyright.Text = "Copyright (C)2021. All Rights Reserved\r\nGameplay: Jonas & Lukas Latikaynen\r\nProgr" +
    "amming: Daniel Latikaynen\r\nAdditional code: Lukas Latikaynen";
            this.Copyright.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Copyright.WordWrap = false;
            // 
            // PlayerNames
            // 
            this.PlayerNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerNames.BackColor = System.Drawing.Color.Transparent;
            this.PlayerNames.Enabled = false;
            this.PlayerNames.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNames.Location = new System.Drawing.Point(12, 0);
            this.PlayerNames.Name = "PlayerNames";
            this.PlayerNames.Size = new System.Drawing.Size(838, 25);
            this.PlayerNames.TabIndex = 3;
            this.PlayerNames.Text = "playerNames";
            this.PlayerNames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlayerNames.UseMnemonic = false;
            this.PlayerNames.Visible = false;
            // 
            // AufGegnerWarten
            // 
            this.AufGegnerWarten.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AufGegnerWarten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AufGegnerWarten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AufGegnerWarten.Controls.Add(this.pictureBox2);
            this.AufGegnerWarten.Controls.Add(this.label7);
            this.AufGegnerWarten.Location = new System.Drawing.Point(372, 368);
            this.AufGegnerWarten.Name = "AufGegnerWarten";
            this.AufGegnerWarten.Size = new System.Drawing.Size(119, 138);
            this.AufGegnerWarten.TabIndex = 7;
            this.AufGegnerWarten.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 82);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(111, 47);
            this.label7.TabIndex = 0;
            this.label7.Text = "waiting   for   other player\'s move";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.UseMnemonic = false;
            // 
            // CloudVerbindung
            // 
            this.CloudVerbindung.BackColor = System.Drawing.Color.LightSkyBlue;
            this.CloudVerbindung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloudVerbindung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CloudVerbindung.Controls.Add(this.pictureBox1);
            this.CloudVerbindung.Controls.Add(this.MitspielerFindenFortschritt);
            this.CloudVerbindung.Controls.Add(this.label4);
            this.CloudVerbindung.Location = new System.Drawing.Point(731, 28);
            this.CloudVerbindung.Name = "CloudVerbindung";
            this.CloudVerbindung.Size = new System.Drawing.Size(119, 361);
            this.CloudVerbindung.TabIndex = 6;
            this.CloudVerbindung.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 82);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MitspielerFindenFortschritt
            // 
            this.MitspielerFindenFortschritt.ForeColor = System.Drawing.Color.Azure;
            this.MitspielerFindenFortschritt.Location = new System.Drawing.Point(27, 5);
            this.MitspielerFindenFortschritt.Name = "MitspielerFindenFortschritt";
            this.MitspielerFindenFortschritt.Size = new System.Drawing.Size(87, 249);
            this.MitspielerFindenFortschritt.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MitspielerFindenFortschritt.TabIndex = 2;
            this.MitspielerFindenFortschritt.Value = 99;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(18, 249);
            this.label4.TabIndex = 0;
            this.label4.Text = "waiting   for   other";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.UseMnemonic = false;
            // 
            // SchussEingabefeld
            // 
            this.SchussEingabefeld.BackColor = System.Drawing.Color.Peru;
            this.SchussEingabefeld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SchussEingabefeld.Controls.Add(this.Ladung);
            this.SchussEingabefeld.Controls.Add(this.Winkel);
            this.SchussEingabefeld.Controls.Add(this.NameDesDranSeienden);
            this.SchussEingabefeld.Controls.Add(this.OomphLabel);
            this.SchussEingabefeld.Controls.Add(this.CommandLabel);
            this.SchussEingabefeld.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.SchussEingabefeld.Location = new System.Drawing.Point(30, 334);
            this.SchussEingabefeld.Name = "SchussEingabefeld";
            this.SchussEingabefeld.Opacity = 30;
            this.SchussEingabefeld.Size = new System.Drawing.Size(244, 172);
            this.SchussEingabefeld.TabIndex = 5;
            this.SchussEingabefeld.Visible = false;
            // 
            // Ladung
            // 
            this.Ladung.BackColor = System.Drawing.Color.Crimson;
            this.Ladung.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ladung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Ladung.Location = new System.Drawing.Point(8, 130);
            this.Ladung.Name = "Ladung";
            this.Ladung.Size = new System.Drawing.Size(221, 24);
            this.Ladung.TabIndex = 4;
            // 
            // Winkel
            // 
            this.Winkel.BackColor = System.Drawing.Color.Crimson;
            this.Winkel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Winkel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Winkel.Location = new System.Drawing.Point(8, 70);
            this.Winkel.Name = "Winkel";
            this.Winkel.Size = new System.Drawing.Size(221, 24);
            this.Winkel.TabIndex = 3;
            // 
            // NameDesDranSeienden
            // 
            this.NameDesDranSeienden.BackColor = System.Drawing.Color.Transparent;
            this.NameDesDranSeienden.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameDesDranSeienden.ForeColor = System.Drawing.Color.Yellow;
            this.NameDesDranSeienden.Location = new System.Drawing.Point(3, 0);
            this.NameDesDranSeienden.Name = "NameDesDranSeienden";
            this.NameDesDranSeienden.Size = new System.Drawing.Size(233, 22);
            this.NameDesDranSeienden.TabIndex = 2;
            this.NameDesDranSeienden.Text = "spielerName";
            this.NameDesDranSeienden.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NameDesDranSeienden.UseMnemonic = false;
            // 
            // OomphLabel
            // 
            this.OomphLabel.AutoSize = true;
            this.OomphLabel.BackColor = System.Drawing.Color.Transparent;
            this.OomphLabel.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OomphLabel.Location = new System.Drawing.Point(5, 98);
            this.OomphLabel.Name = "OomphLabel";
            this.OomphLabel.Size = new System.Drawing.Size(95, 28);
            this.OomphLabel.TabIndex = 1;
            this.OomphLabel.Text = "Oomph";
            this.OomphLabel.Transparent = true;
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.BackColor = System.Drawing.Color.Transparent;
            this.CommandLabel.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandLabel.Location = new System.Drawing.Point(5, 39);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(128, 28);
            this.CommandLabel.TabIndex = 0;
            this.CommandLabel.Text = "Command";
            this.CommandLabel.Transparent = true;
            this.CommandLabel.UseMnemonic = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(862, 518);
            this.Controls.Add(this.WeltErzeugen);
            this.Controls.Add(this.AufGegnerWarten);
            this.Controls.Add(this.CloudVerbindung);
            this.Controls.Add(this.SchussEingabefeld);
            this.Controls.Add(this.PlayerNames);
            this.Controls.Add(this.Copyright);
            this.Controls.Add(this.ScorchGore);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Scorch Gore";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.WeltErzeugen.ResumeLayout(false);
            this.WeltErzeugen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RauheitsfaktorProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoechstHoeheProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MindesthoeheProzent)).EndInit();
            this.AufGegnerWarten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.CloudVerbindung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SchussEingabefeld.ResumeLayout(false);
            this.SchussEingabefeld.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel WeltErzeugen;
        private System.Windows.Forms.TrackBar RauheitsfaktorProzent;
        private System.Windows.Forms.TrackBar HoechstHoeheProzent;
        private System.Windows.Forms.TrackBar MindesthoeheProzent;
        private System.Windows.Forms.Label MountainosityFactorLabel;
        private System.Windows.Forms.Label MaximumElevationLabel;
        private System.Windows.Forms.Label MinimumElevationLabel;
        private System.Windows.Forms.Label ScorchGore;
        private System.Windows.Forms.TextBox Copyright;
        private System.Windows.Forms.Label PlayerNames;
        private Durchsichtig SchussEingabefeld;
        private System.Windows.Forms.Label NameDesDranSeienden;
        private DurchsichtigesLabel OomphLabel;
        private DurchsichtigesLabel CommandLabel;
        private System.Windows.Forms.TextBox Ladung;
        private System.Windows.Forms.TextBox Winkel;
        private System.Windows.Forms.Button StartCloud;
        private System.Windows.Forms.Button StartOffline;
        private System.Windows.Forms.Label label4;
        private Durchsichtig CloudVerbindung;
        private ProgressBar MitspielerFindenFortschritt;
        private PictureBox pictureBox1;
        private Durchsichtig AufGegnerWarten;
        private PictureBox pictureBox2;
        private Label label7;
    }
}

