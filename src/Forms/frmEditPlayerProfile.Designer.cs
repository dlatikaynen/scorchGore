namespace ScorchGore.Forms
{
    partial class frmEditPlayerProfile
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPlayerProfile));
            Validator = new ErrorProvider(components);
            label1 = new Label();
            txtName = new TextBox();
            btnCancel = new Button();
            cmdOk = new Button();
            ((System.ComponentModel.ISupportInitialize)Validator).BeginInit();
            SuspendLayout();
            // 
            // Validator
            // 
            Validator.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            Validator.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Your &name*";
            // 
            // txtName
            // 
            txtName.HideSelection = false;
            txtName.Location = new Point(13, 30);
            txtName.MaxLength = 12;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Enter a good name here";
            txtName.Size = new Size(214, 23);
            txtName.TabIndex = 0;
            txtName.WordWrap = false;
            txtName.Validating += txtName_Validating;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(104, 59);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOk
            // 
            cmdOk.DialogResult = DialogResult.OK;
            cmdOk.Location = new Point(12, 59);
            cmdOk.Name = "cmdOk";
            cmdOk.Size = new Size(86, 30);
            cmdOk.TabIndex = 1;
            cmdOk.Text = "&Ok";
            cmdOk.UseVisualStyleBackColor = true;
            cmdOk.Click += cmdOk_Click;
            // 
            // frmEditPlayerProfile
            // 
            AcceptButton = cmdOk;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new Size(265, 100);
            Controls.Add(cmdOk);
            Controls.Add(btnCancel);
            Controls.Add(txtName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditPlayerProfile";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Edit player profile";
            ((System.ComponentModel.ISupportInitialize)Validator).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider Validator;
        private TextBox txtName;
        private Label label1;
        private Button cmdOk;
        private Button btnCancel;
    }
}