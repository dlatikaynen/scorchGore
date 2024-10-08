namespace ScorchGore.Forms
{
    partial class frmMaterialPalette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialPalette));
            btnColor = new Button();
            lblBehavior = new Label();
            lstBehavior = new ComboBox();
            fmePalette = new GroupBox();
            lblInfo = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnCopyFrom = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            dlgColor = new ColorDialog();
            txtColor = new TextBox();
            btnColorPicker = new Button();
            fmePalette.SuspendLayout();
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.Gold;
            btnColor.FlatStyle = FlatStyle.Flat;
            btnColor.Location = new Point(8, 27);
            btnColor.Margin = new Padding(0);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(15, 15);
            btnColor.TabIndex = 0;
            btnColor.UseMnemonic = false;
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Visible = false;
            // 
            // lblBehavior
            // 
            lblBehavior.AutoSize = true;
            lblBehavior.Location = new Point(10, 13);
            lblBehavior.Name = "lblBehavior";
            lblBehavior.Size = new Size(109, 15);
            lblBehavior.TabIndex = 256;
            lblBehavior.Text = "&Medium (behavior)";
            // 
            // lstBehavior
            // 
            lstBehavior.DropDownStyle = ComboBoxStyle.DropDownList;
            lstBehavior.FormattingEnabled = true;
            lstBehavior.Location = new Point(12, 31);
            lstBehavior.Name = "lstBehavior";
            lstBehavior.Size = new Size(428, 23);
            lstBehavior.TabIndex = 257;
            lstBehavior.SelectedIndexChanged += lstBehavior_SelectedIndexChanged;
            // 
            // fmePalette
            // 
            fmePalette.Controls.Add(btnColor);
            fmePalette.Location = new Point(12, 72);
            fmePalette.Name = "fmePalette";
            fmePalette.Size = new Size(271, 286);
            fmePalette.TabIndex = 258;
            fmePalette.TabStop = false;
            fmePalette.Text = "&Palette";
            // 
            // lblInfo
            // 
            lblInfo.BorderStyle = BorderStyle.Fixed3D;
            lblInfo.Dock = DockStyle.Bottom;
            lblInfo.Location = new Point(0, 373);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(452, 67);
            lblInfo.TabIndex = 259;
            // 
            // btnAdd
            // 
            btnAdd.ImeMode = ImeMode.NoControl;
            btnAdd.Location = new Point(303, 80);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 30);
            btnAdd.TabIndex = 260;
            btnAdd.Text = "&Add...";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.ImeMode = ImeMode.NoControl;
            btnDelete.Location = new Point(303, 200);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 30);
            btnDelete.TabIndex = 262;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCopyFrom
            // 
            btnCopyFrom.ImeMode = ImeMode.NoControl;
            btnCopyFrom.Location = new Point(303, 236);
            btnCopyFrom.Name = "btnCopyFrom";
            btnCopyFrom.Size = new Size(137, 30);
            btnCopyFrom.TabIndex = 263;
            btnCopyFrom.Text = "C&opy from...";
            btnCopyFrom.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.ImeMode = ImeMode.NoControl;
            btnSave.Location = new Point(303, 328);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 30);
            btnSave.TabIndex = 264;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ImeMode = ImeMode.NoControl;
            btnCancel.Location = new Point(303, 292);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 30);
            btnCancel.TabIndex = 265;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(303, 124);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 266;
            label1.Text = "#aarrggbb";
            // 
            // dlgColor
            // 
            dlgColor.AnyColor = true;
            dlgColor.FullOpen = true;
            dlgColor.ShowHelp = true;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(303, 142);
            txtColor.MaxLength = 9;
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(102, 23);
            txtColor.TabIndex = 267;
            // 
            // btnColorPicker
            // 
            btnColorPicker.BackColor = SystemColors.Control;
            btnColorPicker.FlatStyle = FlatStyle.Flat;
            btnColorPicker.Location = new Point(408, 142);
            btnColorPicker.Margin = new Padding(0);
            btnColorPicker.Name = "btnColorPicker";
            btnColorPicker.Size = new Size(32, 23);
            btnColorPicker.TabIndex = 268;
            btnColorPicker.Text = "...";
            btnColorPicker.UseMnemonic = false;
            btnColorPicker.UseVisualStyleBackColor = false;
            btnColorPicker.Click += btnColorPicker_Click;
            // 
            // frmMaterialPalette
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 440);
            Controls.Add(btnColorPicker);
            Controls.Add(txtColor);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnCopyFrom);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lblInfo);
            Controls.Add(fmePalette);
            Controls.Add(lstBehavior);
            Controls.Add(lblBehavior);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMaterialPalette";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set of materials";
            fmePalette.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnColor;
        private Label lblBehavior;
        private ComboBox lstBehavior;
        private GroupBox fmePalette;
        private Label lblInfo;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnCopyFrom;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private ColorDialog dlgColor;
        private TextBox txtColor;
        private Button btnColorPicker;
    }
}