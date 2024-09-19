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
        MainToolbar = new ToolStrip();
        tbbInitiate = new ToolStripButton();
        tbbJoin = new ToolStripButton();
        tbbEditPlayerProfile = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        tbbViewServerTraffic = new ToolStripButton();
        tbbViewApiMessageLog = new ToolStripButton();
        MdiError = new ErrorProvider(components);
        MdiBkg = new System.ComponentModel.BackgroundWorker();
        MainMenu = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mnuFileInitiateTournamentOnline = new ToolStripMenuItem();
        mnuFileInitiateTournamentLocal = new ToolStripMenuItem();
        mnuFilePractice = new ToolStripMenuItem();
        toolStripMenuItem7 = new ToolStripSeparator();
        mnuFileJoinGame = new ToolStripMenuItem();
        mnuFileLoadSavegame = new ToolStripMenuItem();
        toolStripMenuItem5 = new ToolStripSeparator();
        mnuFileBackup = new ToolStripMenuItem();
        mnuFileRestore = new ToolStripMenuItem();
        toolStripMenuItem6 = new ToolStripSeparator();
        mnuFileQuit = new ToolStripMenuItem();
        mnuView = new ToolStripMenuItem();
        mnuViewSwitchLanguage = new ToolStripMenuItem();
        mnuViewSwitchLanguageEn = new ToolStripMenuItem();
        mnuViewSwitchLanguageFi = new ToolStripMenuItem();
        mnuViewSwitchLanguageDe = new ToolStripMenuItem();
        mnuViewSwitchLanguageUa = new ToolStripMenuItem();
        mnuViewServerTraffic = new ToolStripMenuItem();
        mnuViewApiMessages = new ToolStripMenuItem();
        mnuTools = new ToolStripMenuItem();
        mnuToolsLevelDesigner = new ToolStripMenuItem();
        contributeToolStripMenuItem = new ToolStripMenuItem();
        mnuCommunityEditPlayerProfile = new ToolStripMenuItem();
        toolStripMenuItem8 = new ToolStripSeparator();
        discordToolStripMenuItem = new ToolStripMenuItem();
        forumToolStripMenuItem = new ToolStripMenuItem();
        mnuWindow = new ToolStripMenuItem();
        closeToolStripMenuItem = new ToolStripMenuItem();
        arrangeToolStripMenuItem = new ToolStripMenuItem();
        minimizeAllToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem4 = new ToolStripSeparator();
        helpToolStripMenuItem = new ToolStripMenuItem();
        buyFullVersionToolStripMenuItem = new ToolStripMenuItem();
        payAndRegisterToolStripMenuItem = new ToolStripMenuItem();
        enterProductkeyToolStripMenuItem = new ToolStripMenuItem();
        onlineHelpToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripMenuItem();
        toolStripMenuItem3 = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        mnuHelpAbout = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        toolStripStatusLabel4 = new ToolStripStatusLabel();
        toolStripStatusLabel2 = new ToolStripStatusLabel();
        toolStripStatusLabel3 = new ToolStripStatusLabel();
        toolStripProgressBar1 = new ToolStripProgressBar();
        MainToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MdiError).BeginInit();
        MainMenu.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // MainToolbar
        // 
        MainToolbar.Items.AddRange(new ToolStripItem[] { tbbInitiate, tbbJoin, tbbEditPlayerProfile, toolStripSeparator1, tbbViewServerTraffic, tbbViewApiMessageLog });
        resources.ApplyResources(MainToolbar, "MainToolbar");
        MainToolbar.Name = "MainToolbar";
        MdiHelp.SetShowHelp(MainToolbar, (bool)resources.GetObject("MainToolbar.ShowHelp"));
        // 
        // tbbInitiate
        // 
        tbbInitiate.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(tbbInitiate, "tbbInitiate");
        tbbInitiate.Name = "tbbInitiate";
        tbbInitiate.Click += tbbInitiate_Click;
        // 
        // tbbJoin
        // 
        tbbJoin.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(tbbJoin, "tbbJoin");
        tbbJoin.Name = "tbbJoin";
        tbbJoin.Click += tbbJoin_Click;
        // 
        // tbbEditPlayerProfile
        // 
        tbbEditPlayerProfile.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(tbbEditPlayerProfile, "tbbEditPlayerProfile");
        tbbEditPlayerProfile.Name = "tbbEditPlayerProfile";
        tbbEditPlayerProfile.Click += ttbEditPlayerProfile_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
        // 
        // tbbViewServerTraffic
        // 
        tbbViewServerTraffic.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(tbbViewServerTraffic, "tbbViewServerTraffic");
        tbbViewServerTraffic.Name = "tbbViewServerTraffic";
        tbbViewServerTraffic.Click += tbbViewServerTraffic_Click;
        // 
        // tbbViewApiMessageLog
        // 
        tbbViewApiMessageLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
        resources.ApplyResources(tbbViewApiMessageLog, "tbbViewApiMessageLog");
        tbbViewApiMessageLog.Name = "tbbViewApiMessageLog";
        tbbViewApiMessageLog.Click += tbbViewApiMessageLog_Click;
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
        MainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuTools, contributeToolStripMenuItem, mnuWindow, helpToolStripMenuItem });
        resources.ApplyResources(MainMenu, "MainMenu");
        MainMenu.MdiWindowListItem = mnuWindow;
        MainMenu.Name = "MainMenu";
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileInitiateTournamentOnline, mnuFileInitiateTournamentLocal, mnuFilePractice, toolStripMenuItem7, mnuFileJoinGame, mnuFileLoadSavegame, toolStripMenuItem5, mnuFileBackup, mnuFileRestore, toolStripMenuItem6, mnuFileQuit });
        mnuFile.Name = "mnuFile";
        resources.ApplyResources(mnuFile, "mnuFile");
        // 
        // mnuFileInitiateTournamentOnline
        // 
        mnuFileInitiateTournamentOnline.Name = "mnuFileInitiateTournamentOnline";
        resources.ApplyResources(mnuFileInitiateTournamentOnline, "mnuFileInitiateTournamentOnline");
        mnuFileInitiateTournamentOnline.Click += mnuFileInitiateTournamentOnline_Click;
        // 
        // mnuFileInitiateTournamentLocal
        // 
        mnuFileInitiateTournamentLocal.Name = "mnuFileInitiateTournamentLocal";
        resources.ApplyResources(mnuFileInitiateTournamentLocal, "mnuFileInitiateTournamentLocal");
        mnuFileInitiateTournamentLocal.Click += mnuFileInitiateTournamentLocal_Click;
        // 
        // mnuFilePractice
        // 
        mnuFilePractice.Name = "mnuFilePractice";
        resources.ApplyResources(mnuFilePractice, "mnuFilePractice");
        mnuFilePractice.Click += mnuFilePractice_Click;
        // 
        // toolStripMenuItem7
        // 
        toolStripMenuItem7.Name = "toolStripMenuItem7";
        resources.ApplyResources(toolStripMenuItem7, "toolStripMenuItem7");
        // 
        // mnuFileJoinGame
        // 
        mnuFileJoinGame.Name = "mnuFileJoinGame";
        resources.ApplyResources(mnuFileJoinGame, "mnuFileJoinGame");
        mnuFileJoinGame.Click += mnuFileJoinGame_Click;
        // 
        // mnuFileLoadSavegame
        // 
        mnuFileLoadSavegame.Name = "mnuFileLoadSavegame";
        resources.ApplyResources(mnuFileLoadSavegame, "mnuFileLoadSavegame");
        // 
        // toolStripMenuItem5
        // 
        toolStripMenuItem5.Name = "toolStripMenuItem5";
        resources.ApplyResources(toolStripMenuItem5, "toolStripMenuItem5");
        // 
        // mnuFileBackup
        // 
        mnuFileBackup.Name = "mnuFileBackup";
        resources.ApplyResources(mnuFileBackup, "mnuFileBackup");
        // 
        // mnuFileRestore
        // 
        mnuFileRestore.Name = "mnuFileRestore";
        resources.ApplyResources(mnuFileRestore, "mnuFileRestore");
        // 
        // toolStripMenuItem6
        // 
        toolStripMenuItem6.Name = "toolStripMenuItem6";
        resources.ApplyResources(toolStripMenuItem6, "toolStripMenuItem6");
        // 
        // mnuFileQuit
        // 
        mnuFileQuit.Name = "mnuFileQuit";
        resources.ApplyResources(mnuFileQuit, "mnuFileQuit");
        mnuFileQuit.Click += quitToolStripMenuItem_Click;
        // 
        // mnuView
        // 
        mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuViewSwitchLanguage, mnuViewServerTraffic, mnuViewApiMessages });
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
        // mnuViewServerTraffic
        // 
        mnuViewServerTraffic.Name = "mnuViewServerTraffic";
        resources.ApplyResources(mnuViewServerTraffic, "mnuViewServerTraffic");
        mnuViewServerTraffic.Click += mnuViewServerTraffic_Click;
        // 
        // mnuViewApiMessages
        // 
        mnuViewApiMessages.Name = "mnuViewApiMessages";
        resources.ApplyResources(mnuViewApiMessages, "mnuViewApiMessages");
        mnuViewApiMessages.Click += mnuViewApiMessages_Click;
        // 
        // mnuTools
        // 
        mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuToolsLevelDesigner });
        mnuTools.Name = "mnuTools";
        resources.ApplyResources(mnuTools, "mnuTools");
        // 
        // mnuToolsLevelDesigner
        // 
        mnuToolsLevelDesigner.Name = "mnuToolsLevelDesigner";
        resources.ApplyResources(mnuToolsLevelDesigner, "mnuToolsLevelDesigner");
        // 
        // contributeToolStripMenuItem
        // 
        contributeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCommunityEditPlayerProfile, toolStripMenuItem8, discordToolStripMenuItem, forumToolStripMenuItem });
        contributeToolStripMenuItem.Name = "contributeToolStripMenuItem";
        resources.ApplyResources(contributeToolStripMenuItem, "contributeToolStripMenuItem");
        // 
        // mnuCommunityEditPlayerProfile
        // 
        mnuCommunityEditPlayerProfile.Name = "mnuCommunityEditPlayerProfile";
        resources.ApplyResources(mnuCommunityEditPlayerProfile, "mnuCommunityEditPlayerProfile");
        mnuCommunityEditPlayerProfile.Click += mnuCommunityEditPlayerProfile_Click;
        // 
        // toolStripMenuItem8
        // 
        toolStripMenuItem8.Name = "toolStripMenuItem8";
        resources.ApplyResources(toolStripMenuItem8, "toolStripMenuItem8");
        // 
        // discordToolStripMenuItem
        // 
        discordToolStripMenuItem.Name = "discordToolStripMenuItem";
        resources.ApplyResources(discordToolStripMenuItem, "discordToolStripMenuItem");
        // 
        // forumToolStripMenuItem
        // 
        forumToolStripMenuItem.Name = "forumToolStripMenuItem";
        resources.ApplyResources(forumToolStripMenuItem, "forumToolStripMenuItem");
        // 
        // mnuWindow
        // 
        mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem, arrangeToolStripMenuItem, minimizeAllToolStripMenuItem, toolStripMenuItem4 });
        mnuWindow.Name = "mnuWindow";
        resources.ApplyResources(mnuWindow, "mnuWindow");
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        resources.ApplyResources(closeToolStripMenuItem, "closeToolStripMenuItem");
        // 
        // arrangeToolStripMenuItem
        // 
        arrangeToolStripMenuItem.Name = "arrangeToolStripMenuItem";
        resources.ApplyResources(arrangeToolStripMenuItem, "arrangeToolStripMenuItem");
        // 
        // minimizeAllToolStripMenuItem
        // 
        minimizeAllToolStripMenuItem.Name = "minimizeAllToolStripMenuItem";
        resources.ApplyResources(minimizeAllToolStripMenuItem, "minimizeAllToolStripMenuItem");
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buyFullVersionToolStripMenuItem, onlineHelpToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem1, mnuHelpAbout });
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
        // mnuHelpAbout
        // 
        mnuHelpAbout.Name = "mnuHelpAbout";
        resources.ApplyResources(mnuHelpAbout, "mnuHelpAbout");
        mnuHelpAbout.Click += mnuHelpAbout_Click;
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
        MainMenuStrip = MainMenu;
        Name = "MainWindow";
        SizeGripStyle = SizeGripStyle.Show;
        MainToolbar.ResumeLayout(false);
        MainToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MdiError).EndInit();
        MainMenu.ResumeLayout(false);
        MainMenu.PerformLayout();
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
    private MenuStrip MainMenu;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuFileQuit;
    private ToolStripMenuItem mnuView;
    private ToolStripMenuItem mnuTools;
    private ToolStripMenuItem contributeToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabel4;
    private ToolStripMenuItem onlineHelpToolStripMenuItem;
    private ToolStripMenuItem mnuHelpAbout;
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
    private ToolStripMenuItem mnuWindow;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem arrangeToolStripMenuItem;
    private ToolStripMenuItem minimizeAllToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem4;
    private ToolStripMenuItem mnuFileJoinGame;
    private ToolStripSeparator toolStripMenuItem5;
    private ToolStripMenuItem mnuCommunityEditPlayerProfile;
    private ToolStrip MainToolbar;
    private ToolStripButton tbbInitiate;
    private ToolStripButton tbbJoin;
    private ToolStripButton tbbEditPlayerProfile;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem mnuFileInitiateTournamentOnline;
    private ToolStripMenuItem mnuFileInitiateTournamentLocal;
    private ToolStripMenuItem mnuFilePractice;
    private ToolStripSeparator toolStripMenuItem7;
    private ToolStripMenuItem mnuFileLoadSavegame;
    private ToolStripMenuItem mnuFileBackup;
    private ToolStripMenuItem mnuFileRestore;
    private ToolStripSeparator toolStripMenuItem6;
    private ToolStripSeparator toolStripMenuItem8;
    private ToolStripMenuItem discordToolStripMenuItem;
    private ToolStripMenuItem forumToolStripMenuItem;
    private ToolStripMenuItem mnuViewServerTraffic;
    private ToolStripMenuItem mnuViewApiMessages;
    private ToolStripMenuItem mnuToolsLevelDesigner;
    private ToolStripButton tbbViewServerTraffic;
    private ToolStripButton tbbViewApiMessageLog;
}
