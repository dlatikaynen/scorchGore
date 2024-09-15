using System.ComponentModel;

namespace ScorchGore.Forms;

public partial class frmAlreadyEnglish : Form
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

    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(frmAlreadyEnglish));
        lblInfo = new TextBox();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblInfo
        // 
        resources.ApplyResources(lblInfo, "lblInfo");
        lblInfo.Name = "lblInfo";
        lblInfo.ReadOnly = true;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        resources.ApplyResources(btnCancel, "btnCancel");
        btnCancel.Name = "btnCancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // frmAlreadyEnglish
        // 
        AcceptButton = btnCancel;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Dpi;
        CancelButton = btnCancel;
        Controls.Add(btnCancel);
        Controls.Add(lblInfo);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MdiChildrenMinimizedAnchorBottom = false;
        MinimizeBox = false;
        Name = "frmAlreadyEnglish";
        ShowInTaskbar = false;
        SizeGripStyle = SizeGripStyle.Hide;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox lblInfo;
    private Button btnCancel;
}
