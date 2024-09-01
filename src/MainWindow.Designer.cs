namespace Fso.ScorchGore;

partial class MainWindow
{
    /// <summary>
    /// Required designer variable
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        MdiHelp = new HelpProvider();
        MdiError = new ErrorProvider(components);
        MdiBkg = new System.ComponentModel.BackgroundWorker();
        MainMenu = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        newGameToolStripMenuItem = new ToolStripMenuItem();
        practiceOnlineToolStripMenuItem = new ToolStripMenuItem();
        practiceLocalToolStripMenuItem = new ToolStripMenuItem();
        tournamentonlineToolStripMenuItem = new ToolStripMenuItem();
        tournamentLocalToolStripMenuItem = new ToolStripMenuItem();
        mnuFileQuit = new ToolStripMenuItem();
        mnuView = new ToolStripMenuItem();
        mnuViewSwitchLanguage = new ToolStripMenuItem();
        mnuViewSwitchLanguageEn = new ToolStripMenuItem();
        mnuViewSwitchLanguageFi = new ToolStripMenuItem();
        mnuViewSwitchLanguageDe = new ToolStripMenuItem();
        mnuViewSwitchLanguageUa = new ToolStripMenuItem();
        mnuTools = new ToolStripMenuItem();
        contributeToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        buyFullVersionToolStripMenuItem = new ToolStripMenuItem();
        payAndRegisterToolStripMenuItem = new ToolStripMenuItem();
        enterProductkeyToolStripMenuItem = new ToolStripMenuItem();
        onlineHelpToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripMenuItem();
        toolStripMenuItem3 = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        MainToolbar = new ToolStrip();
        toolStripButton1 = new ToolStripButton();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        toolStripButton4 = new ToolStripButton();
        toolStripButton5 = new ToolStripButton();
        toolStripButton6 = new ToolStripButton();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        toolStripStatusLabel4 = new ToolStripStatusLabel();
        toolStripStatusLabel2 = new ToolStripStatusLabel();
        toolStripStatusLabel3 = new ToolStripStatusLabel();
        toolStripProgressBar1 = new ToolStripProgressBar();
        ((System.ComponentModel.ISupportInitialize)MdiError).BeginInit();
        MainMenu.SuspendLayout();
        MainToolbar.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // MdiError
        // 
        MdiError.ContainerControl = this;
        // 
        // MdiBkg
        // 
        MdiBkg.WorkerReportsProgress = true;
        MdiBkg.WorkerSupportsCancellation = true;
        // 
        // MainMenu
        // 
        MainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuTools, contributeToolStripMenuItem, helpToolStripMenuItem });
        resources.ApplyResources(MainMenu, "MainMenu");
        MainMenu.Name = "MainMenu";
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, mnuFileQuit });
        mnuFile.Name = "mnuFile";
        resources.ApplyResources(mnuFile, "mnuFile");
        // 
        // newGameToolStripMenuItem
        // 
        newGameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { practiceOnlineToolStripMenuItem, practiceLocalToolStripMenuItem, tournamentonlineToolStripMenuItem, tournamentLocalToolStripMenuItem });
        newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
        resources.ApplyResources(newGameToolStripMenuItem, "newGameToolStripMenuItem");
        newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
        // 
        // practiceOnlineToolStripMenuItem
        // 
        practiceOnlineToolStripMenuItem.Name = "practiceOnlineToolStripMenuItem";
        resources.ApplyResources(practiceOnlineToolStripMenuItem, "practiceOnlineToolStripMenuItem");
        // 
        // practiceLocalToolStripMenuItem
        // 
        practiceLocalToolStripMenuItem.Name = "practiceLocalToolStripMenuItem";
        resources.ApplyResources(practiceLocalToolStripMenuItem, "practiceLocalToolStripMenuItem");
        // 
        // tournamentonlineToolStripMenuItem
        // 
        tournamentonlineToolStripMenuItem.Name = "tournamentonlineToolStripMenuItem";
        resources.ApplyResources(tournamentonlineToolStripMenuItem, "tournamentonlineToolStripMenuItem");
        // 
        // tournamentLocalToolStripMenuItem
        // 
        tournamentLocalToolStripMenuItem.Name = "tournamentLocalToolStripMenuItem";
        resources.ApplyResources(tournamentLocalToolStripMenuItem, "tournamentLocalToolStripMenuItem");
        // 
        // mnuFileQuit
        // 
        mnuFileQuit.Name = "mnuFileQuit";
        resources.ApplyResources(mnuFileQuit, "mnuFileQuit");
        mnuFileQuit.Click += quitToolStripMenuItem_Click;
        // 
        // mnuView
        // 
        mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuViewSwitchLanguage });
        mnuView.Name = "mnuView";
        resources.ApplyResources(mnuView, "mnuView");
        // 
        // mnuViewSwitchLanguage
        // 
        mnuViewSwitchLanguage.DropDownItems.AddRange(new ToolStripItem[] { mnuViewSwitchLanguageEn, mnuViewSwitchLanguageFi, mnuViewSwitchLanguageDe, mnuViewSwitchLanguageUa });
        mnuViewSwitchLanguage.Name = "mnuViewSwitchLanguage";
        resources.ApplyResources(mnuViewSwitchLanguage, "mnuViewSwitchLanguage");
        // 
        // mnuViewSwitchLanguageEn
        // 
        mnuViewSwitchLanguageEn.Name = "mnuViewSwitchLanguageEn";
        resources.ApplyResources(mnuViewSwitchLanguageEn, "mnuViewSwitchLanguageEn");
        mnuViewSwitchLanguageEn.Click += mnuViewSwitchLanguageEn_Click;
        // 
        // mnuViewSwitchLanguageFi
        // 
        mnuViewSwitchLanguageFi.Name = "mnuViewSwitchLanguageFi";
        resources.ApplyResources(mnuViewSwitchLanguageFi, "mnuViewSwitchLanguageFi");
        mnuViewSwitchLanguageFi.Click += mnuViewSwitchLanguageFi_Click;
        // 
        // mnuViewSwitchLanguageDe
        // 
        mnuViewSwitchLanguageDe.Name = "mnuViewSwitchLanguageDe";
        resources.ApplyResources(mnuViewSwitchLanguageDe, "mnuViewSwitchLanguageDe");
        mnuViewSwitchLanguageDe.Click += mnuViewSwitchLanguageDe_Click;
        // 
        // mnuViewSwitchLanguageUa
        // 
        mnuViewSwitchLanguageUa.Name = "mnuViewSwitchLanguageUa";
        resources.ApplyResources(mnuViewSwitchLanguageUa, "mnuViewSwitchLanguageUa");
        mnuViewSwitchLanguageUa.Click += mnuViewSwitchLanguageUa_Click;
        // 
        // mnuTools
        // 
        mnuTools.Name = "mnuTools";
        resources.ApplyResources(mnuTools, "mnuTools");
        // 
        // contributeToolStripMenuItem
        // 
        contributeToolStripMenuItem.Name = "contributeToolStripMenuItem";
        resources.ApplyResources(contributeToolStripMenuItem, "contributeToolStripMenuItem");
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buyFullVersionToolStripMenuItem, onlineHelpToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem1, aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
        // 
        // buyFullVersionToolStripMenuItem
        // 
        buyFullVersionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { payAndRegisterToolStripMenuItem, enterProductkeyToolStripMenuItem });
        buyFullVersionToolStripMenuItem.Name = "buyFullVersionToolStripMenuItem";
        resources.ApplyResources(buyFullVersionToolStripMenuItem, "buyFullVersionToolStripMenuItem");
        // 
        // payAndRegisterToolStripMenuItem
        // 
        payAndRegisterToolStripMenuItem.Name = "payAndRegisterToolStripMenuItem";
        resources.ApplyResources(payAndRegisterToolStripMenuItem, "payAndRegisterToolStripMenuItem");
        // 
        // enterProductkeyToolStripMenuItem
        // 
        enterProductkeyToolStripMenuItem.Name = "enterProductkeyToolStripMenuItem";
        resources.ApplyResources(enterProductkeyToolStripMenuItem, "enterProductkeyToolStripMenuItem");
        // 
        // onlineHelpToolStripMenuItem
        // 
        onlineHelpToolStripMenuItem.Name = "onlineHelpToolStripMenuItem";
        resources.ApplyResources(onlineHelpToolStripMenuItem, "onlineHelpToolStripMenuItem");
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
        // 
        // MainToolbar
        // 
        MainToolbar.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripSeparator1, toolStripButton4, toolStripButton5, toolStripButton6 });
        resources.ApplyResources(MainToolbar, "MainToolbar");
        MainToolbar.Name = "MainToolbar";
        // 
        // toolStripButton1
        // 
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton1, "toolStripButton1");
        toolStripButton1.Name = "toolStripButton1";
        // 
        // toolStripButton2
        // 
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton2, "toolStripButton2");
        toolStripButton2.Name = "toolStripButton2";
        // 
        // toolStripButton3
        // 
        toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton3, "toolStripButton3");
        toolStripButton3.Name = "toolStripButton3";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
        // 
        // toolStripButton4
        // 
        toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton4, "toolStripButton4");
        toolStripButton4.Name = "toolStripButton4";
        // 
        // toolStripButton5
        // 
        toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton5, "toolStripButton5");
        toolStripButton5.Name = "toolStripButton5";
        // 
        // toolStripButton6
        // 
        toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(toolStripButton6, "toolStripButton6");
        toolStripButton6.Name = "toolStripButton6";
        // 
        // statusStrip1
        // 
        statusStrip1.AllowItemReorder = true;
        statusStrip1.GripStyle = ToolStripGripStyle.Visible;
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel4, toolStripStatusLabel2, toolStripStatusLabel3, toolStripProgressBar1 });
        resources.ApplyResources(statusStrip1, "statusStrip1");
        statusStrip1.Name = "statusStrip1";
        statusStrip1.RenderMode = ToolStripRenderMode.Professional;
        // 
        // toolStripStatusLabel1
        // 
        toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        toolStripStatusLabel1.Padding = new Padding(0, 0, 10, 0);
        resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
        // 
        // toolStripStatusLabel4
        // 
        toolStripStatusLabel4.Name = "toolStripStatusLabel4";
        toolStripStatusLabel4.Padding = new Padding(10, 0, 10, 0);
        resources.ApplyResources(toolStripStatusLabel4, "toolStripStatusLabel4");
        // 
        // toolStripStatusLabel2
        // 
        resources.ApplyResources(toolStripStatusLabel2, "toolStripStatusLabel2");
        toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        toolStripStatusLabel2.Padding = new Padding(10, 0, 10, 0);
        // 
        // toolStripStatusLabel3
        // 
        toolStripStatusLabel3.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripStatusLabel3.Name = "toolStripStatusLabel3";
        resources.ApplyResources(toolStripStatusLabel3, "toolStripStatusLabel3");
        toolStripStatusLabel3.Spring = true;
        // 
        // toolStripProgressBar1
        // 
        toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
        toolStripProgressBar1.AutoToolTip = true;
        toolStripProgressBar1.MarqueeAnimationSpeed = 33;
        toolStripProgressBar1.Name = "toolStripProgressBar1";
        resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
        toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
        toolStripProgressBar1.Value = 50;
        // 
        // MainWindow
        // 
        AccessibleRole = AccessibleRole.Application;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(statusStrip1);
        Controls.Add(MainToolbar);
        Controls.Add(MainMenu);
        DoubleBuffered = true;
        HelpButton = true;
        IsMdiContainer = true;
        Name = "MainWindow";
        SizeGripStyle = SizeGripStyle.Show;
        ((System.ComponentModel.ISupportInitialize)MdiError).EndInit();
        MainMenu.ResumeLayout(false);
        MainMenu.PerformLayout();
        MainToolbar.ResumeLayout(false);
        MainToolbar.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private HelpProvider MdiHelp;
    private ErrorProvider MdiError;
    private System.ComponentModel.BackgroundWorker MdiBkg;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private ToolStripProgressBar toolStripProgressBar1;
    private ToolStrip MainToolbar;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private ToolStripButton toolStripButton3;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton4;
    private ToolStripButton toolStripButton5;
    private ToolStripButton toolStripButton6;
    private MenuStrip MainMenu;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem newGameToolStripMenuItem;
    private ToolStripMenuItem mnuFileQuit;
    private ToolStripMenuItem mnuView;
    private ToolStripMenuItem mnuTools;
    private ToolStripMenuItem contributeToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem practiceOnlineToolStripMenuItem;
    private ToolStripMenuItem practiceLocalToolStripMenuItem;
    private ToolStripMenuItem tournamentonlineToolStripMenuItem;
    private ToolStripMenuItem tournamentLocalToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabel4;
    private ToolStripMenuItem onlineHelpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem buyFullVersionToolStripMenuItem;
    private ToolStripMenuItem payAndRegisterToolStripMenuItem;
    private ToolStripMenuItem enterProductkeyToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem mnuViewSwitchLanguage;
    private ToolStripMenuItem mnuViewSwitchLanguageDe;
    private ToolStripMenuItem mnuViewSwitchLanguageEn;
    private ToolStripMenuItem mnuViewSwitchLanguageFi;
    private ToolStripMenuItem mnuViewSwitchLanguageUa;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem toolStripMenuItem3;
}
