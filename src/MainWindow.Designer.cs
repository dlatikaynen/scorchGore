using ScorchGore.Properties;

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
        mnuFileSeparator1 = new ToolStripSeparator();
        mnuFileJoinGame = new ToolStripMenuItem();
        mnuFileLoadSavegame = new ToolStripMenuItem();
        mnuFileSeparator2 = new ToolStripSeparator();
        mnuFileOpenWorkspace = new ToolStripMenuItem();
        mnuFileSave = new ToolStripMenuItem();
        mnuFileSaveAs = new ToolStripMenuItem();
        mnuFileSeparator3 = new ToolStripSeparator();
        mnuFileQuit = new ToolStripMenuItem();
        mnuView = new ToolStripMenuItem();
        mnuViewSwitchLanguage = new ToolStripMenuItem();
        mnuViewSwitchLanguageEn = new ToolStripMenuItem();
        mnuViewSwitchLanguageFi = new ToolStripMenuItem();
        mnuViewSwitchLanguageDe = new ToolStripMenuItem();
        mnuViewSwitchLanguageUa = new ToolStripMenuItem();
        mnuViewServerTraffic = new ToolStripMenuItem();
        mnuViewApiMessages = new ToolStripMenuItem();
        toolStripMenuItem10 = new ToolStripMenuItem();
        mnuViewSeparator = new ToolStripSeparator();
        mnuViewShowGrid = new ToolStripMenuItem();
        mnuViewStickToGrid = new ToolStripMenuItem();
        mnuTools = new ToolStripMenuItem();
        mnuToolsLevelDesigner = new ToolStripMenuItem();
        mnuToolsMaterials = new ToolStripMenuItem();
        mnuToolsAssetMgr = new ToolStripMenuItem();
        mnuToolsSeparator = new ToolStripSeparator();
        mnuToolsBossKey = new ToolStripMenuItem();
        mnuCommunity = new ToolStripMenuItem();
        mnuCommunityEditPlayerProfile = new ToolStripMenuItem();
        mnuCommunitySeparator = new ToolStripSeparator();
        mnuCommunityDiscord = new ToolStripMenuItem();
        mnuCommunityForum = new ToolStripMenuItem();
        mnuWindow = new ToolStripMenuItem();
        mnuWindowClose = new ToolStripMenuItem();
        mnuWindowArrange = new ToolStripMenuItem();
        mnuWindowMinimizeAll = new ToolStripMenuItem();
        mnuWindowSeparator = new ToolStripSeparator();
        mnuHelp = new ToolStripMenuItem();
        mnuHelpGetFullVersion = new ToolStripMenuItem();
        payAndRegisterToolStripMenuItem = new ToolStripMenuItem();
        enterProductkeyToolStripMenuItem = new ToolStripMenuItem();
        mnuHelpOnline = new ToolStripMenuItem();
        mnuHelpToC = new ToolStripMenuItem();
        mnuHelpPrivacy = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        mnuHelpAbout = new ToolStripMenuItem();
        MdiStatusStrip = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        toolStripStatusLabel4 = new ToolStripStatusLabel();
        toolStripStatusLabel2 = new ToolStripStatusLabel();
        toolStripStatusLabel3 = new ToolStripStatusLabel();
        toolStripProgressBar1 = new ToolStripProgressBar();
        MainToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MdiError).BeginInit();
        MainMenu.SuspendLayout();
        MdiStatusStrip.SuspendLayout();
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
        MainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuTools, mnuCommunity, mnuWindow, mnuHelp });
        resources.ApplyResources(MainMenu, "MainMenu");
        MainMenu.MdiWindowListItem = mnuWindow;
        MainMenu.Name = "MainMenu";
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileInitiateTournamentOnline, mnuFileInitiateTournamentLocal, mnuFilePractice, mnuFileSeparator1, mnuFileJoinGame, mnuFileLoadSavegame, mnuFileSeparator2, mnuFileOpenWorkspace, mnuFileSave, mnuFileSaveAs, mnuFileSeparator3, mnuFileQuit });
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
        // mnuFileSeparator1
        // 
        mnuFileSeparator1.Name = "mnuFileSeparator1";
        resources.ApplyResources(mnuFileSeparator1, "mnuFileSeparator1");
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
        // mnuFileSeparator2
        // 
        mnuFileSeparator2.Name = "mnuFileSeparator2";
        resources.ApplyResources(mnuFileSeparator2, "mnuFileSeparator2");
        // 
        // mnuFileOpenWorkspace
        // 
        mnuFileOpenWorkspace.Name = "mnuFileOpenWorkspace";
        resources.ApplyResources(mnuFileOpenWorkspace, "mnuFileOpenWorkspace");
        // 
        // mnuFileSave
        // 
        mnuFileSave.Name = "mnuFileSave";
        resources.ApplyResources(mnuFileSave, "mnuFileSave");
        mnuFileSave.Click += mnuFileSave_Click;
        // 
        // mnuFileSaveAs
        // 
        mnuFileSaveAs.Name = "mnuFileSaveAs";
        resources.ApplyResources(mnuFileSaveAs, "mnuFileSaveAs");
        // 
        // mnuFileSeparator3
        // 
        mnuFileSeparator3.Name = "mnuFileSeparator3";
        resources.ApplyResources(mnuFileSeparator3, "mnuFileSeparator3");
        // 
        // mnuFileQuit
        // 
        mnuFileQuit.Name = "mnuFileQuit";
        resources.ApplyResources(mnuFileQuit, "mnuFileQuit");
        mnuFileQuit.Click += quitToolStripMenuItem_Click;
        // 
        // mnuView
        // 
        mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuViewSwitchLanguage, mnuViewServerTraffic, mnuViewApiMessages, toolStripMenuItem10, mnuViewSeparator, mnuViewShowGrid, mnuViewStickToGrid });
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
        mnuViewServerTraffic.Image = Resources.server_traffic;
        mnuViewServerTraffic.Name = "mnuViewServerTraffic";
        resources.ApplyResources(mnuViewServerTraffic, "mnuViewServerTraffic");
        mnuViewServerTraffic.Click += mnuViewServerTraffic_Click;
        // 
        // mnuViewApiMessages
        // 
        mnuViewApiMessages.Image = Resources.api_log;
        mnuViewApiMessages.Name = "mnuViewApiMessages";
        resources.ApplyResources(mnuViewApiMessages, "mnuViewApiMessages");
        mnuViewApiMessages.Click += mnuViewApiMessages_Click;
        // 
        // toolStripMenuItem10
        // 
        toolStripMenuItem10.Image = Resources.toolbox;
        toolStripMenuItem10.Name = "toolStripMenuItem10";
        resources.ApplyResources(toolStripMenuItem10, "toolStripMenuItem10");
        // 
        // mnuViewSeparator
        // 
        mnuViewSeparator.Name = "mnuViewSeparator";
        resources.ApplyResources(mnuViewSeparator, "mnuViewSeparator");
        // 
        // mnuViewShowGrid
        // 
        mnuViewShowGrid.Checked = true;
        mnuViewShowGrid.CheckOnClick = true;
        mnuViewShowGrid.CheckState = CheckState.Checked;
        mnuViewShowGrid.Name = "mnuViewShowGrid";
        resources.ApplyResources(mnuViewShowGrid, "mnuViewShowGrid");
        mnuViewShowGrid.Click += mnuViewShowGrid_Click;
        // 
        // mnuViewStickToGrid
        // 
        mnuViewStickToGrid.CheckOnClick = true;
        mnuViewStickToGrid.Name = "mnuViewStickToGrid";
        resources.ApplyResources(mnuViewStickToGrid, "mnuViewStickToGrid");
        // 
        // mnuTools
        // 
        mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuToolsLevelDesigner, mnuToolsMaterials, mnuToolsAssetMgr, mnuToolsSeparator, mnuToolsBossKey });
        mnuTools.Name = "mnuTools";
        resources.ApplyResources(mnuTools, "mnuTools");
        // 
        // mnuToolsLevelDesigner
        // 
        resources.ApplyResources(mnuToolsLevelDesigner, "mnuToolsLevelDesigner");
        mnuToolsLevelDesigner.Name = "mnuToolsLevelDesigner";
        mnuToolsLevelDesigner.Click += mnuToolsLevelDesigner_Click;
        // 
        // mnuToolsMaterials
        // 
        mnuToolsMaterials.Image = Resources.material;
        mnuToolsMaterials.Name = "mnuToolsMaterials";
        resources.ApplyResources(mnuToolsMaterials, "mnuToolsMaterials");
        mnuToolsMaterials.Click += mnuToolsMaterials_Click;
        // 
        // mnuToolsAssetMgr
        // 
        mnuToolsAssetMgr.Image = Resources.assets;
        mnuToolsAssetMgr.Name = "mnuToolsAssetMgr";
        resources.ApplyResources(mnuToolsAssetMgr, "mnuToolsAssetMgr");
        mnuToolsAssetMgr.Click += mnuToolsAssetMgr_Click;
        // 
        // mnuToolsSeparator
        // 
        mnuToolsSeparator.Name = "mnuToolsSeparator";
        resources.ApplyResources(mnuToolsSeparator, "mnuToolsSeparator");
        // 
        // mnuToolsBossKey
        // 
        mnuToolsBossKey.Name = "mnuToolsBossKey";
        resources.ApplyResources(mnuToolsBossKey, "mnuToolsBossKey");
        mnuToolsBossKey.Click += mnuToolsBossKey_Click;
        // 
        // mnuCommunity
        // 
        mnuCommunity.DropDownItems.AddRange(new ToolStripItem[] { mnuCommunityEditPlayerProfile, mnuCommunitySeparator, mnuCommunityDiscord, mnuCommunityForum });
        mnuCommunity.Name = "mnuCommunity";
        resources.ApplyResources(mnuCommunity, "mnuCommunity");
        // 
        // mnuCommunityEditPlayerProfile
        // 
        mnuCommunityEditPlayerProfile.Name = "mnuCommunityEditPlayerProfile";
        resources.ApplyResources(mnuCommunityEditPlayerProfile, "mnuCommunityEditPlayerProfile");
        mnuCommunityEditPlayerProfile.Click += mnuCommunityEditPlayerProfile_Click;
        // 
        // mnuCommunitySeparator
        // 
        mnuCommunitySeparator.Name = "mnuCommunitySeparator";
        resources.ApplyResources(mnuCommunitySeparator, "mnuCommunitySeparator");
        // 
        // mnuCommunityDiscord
        // 
        mnuCommunityDiscord.Name = "mnuCommunityDiscord";
        resources.ApplyResources(mnuCommunityDiscord, "mnuCommunityDiscord");
        // 
        // mnuCommunityForum
        // 
        mnuCommunityForum.Name = "mnuCommunityForum";
        resources.ApplyResources(mnuCommunityForum, "mnuCommunityForum");
        // 
        // mnuWindow
        // 
        mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuWindowClose, mnuWindowArrange, mnuWindowMinimizeAll, mnuWindowSeparator });
        mnuWindow.Name = "mnuWindow";
        resources.ApplyResources(mnuWindow, "mnuWindow");
        // 
        // mnuWindowClose
        // 
        mnuWindowClose.Name = "mnuWindowClose";
        resources.ApplyResources(mnuWindowClose, "mnuWindowClose");
        // 
        // mnuWindowArrange
        // 
        mnuWindowArrange.Name = "mnuWindowArrange";
        resources.ApplyResources(mnuWindowArrange, "mnuWindowArrange");
        // 
        // mnuWindowMinimizeAll
        // 
        mnuWindowMinimizeAll.Name = "mnuWindowMinimizeAll";
        resources.ApplyResources(mnuWindowMinimizeAll, "mnuWindowMinimizeAll");
        // 
        // mnuWindowSeparator
        // 
        mnuWindowSeparator.Name = "mnuWindowSeparator";
        resources.ApplyResources(mnuWindowSeparator, "mnuWindowSeparator");
        // 
        // mnuHelp
        // 
        mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuHelpGetFullVersion, mnuHelpOnline, mnuHelpToC, mnuHelpPrivacy, toolStripMenuItem1, mnuHelpAbout });
        mnuHelp.Name = "mnuHelp";
        resources.ApplyResources(mnuHelp, "mnuHelp");
        // 
        // mnuHelpGetFullVersion
        // 
        mnuHelpGetFullVersion.DropDownItems.AddRange(new ToolStripItem[] { payAndRegisterToolStripMenuItem, enterProductkeyToolStripMenuItem });
        mnuHelpGetFullVersion.Name = "mnuHelpGetFullVersion";
        resources.ApplyResources(mnuHelpGetFullVersion, "mnuHelpGetFullVersion");
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
        // mnuHelpOnline
        // 
        mnuHelpOnline.Name = "mnuHelpOnline";
        resources.ApplyResources(mnuHelpOnline, "mnuHelpOnline");
        // 
        // mnuHelpToC
        // 
        mnuHelpToC.Name = "mnuHelpToC";
        resources.ApplyResources(mnuHelpToC, "mnuHelpToC");
        // 
        // mnuHelpPrivacy
        // 
        mnuHelpPrivacy.Name = "mnuHelpPrivacy";
        resources.ApplyResources(mnuHelpPrivacy, "mnuHelpPrivacy");
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
        // MdiStatusStrip
        // 
        MdiStatusStrip.AllowItemReorder = true;
        MdiStatusStrip.GripStyle = ToolStripGripStyle.Visible;
        MdiStatusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel4, toolStripStatusLabel2, toolStripStatusLabel3, toolStripProgressBar1 });
        resources.ApplyResources(MdiStatusStrip, "MdiStatusStrip");
        MdiStatusStrip.Name = "MdiStatusStrip";
        MdiStatusStrip.RenderMode = ToolStripRenderMode.Professional;
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
        Controls.Add(MdiStatusStrip);
        Controls.Add(MainToolbar);
        Controls.Add(MainMenu);
        DoubleBuffered = true;
        HelpButton = true;
        IsMdiContainer = true;
        MainMenuStrip = MainMenu;
        Name = "MainWindow";
        SizeGripStyle = SizeGripStyle.Show;
        FormClosing += MainWindow_FormClosing;
        MainToolbar.ResumeLayout(false);
        MainToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MdiError).EndInit();
        MainMenu.ResumeLayout(false);
        MainMenu.PerformLayout();
        MdiStatusStrip.ResumeLayout(false);
        MdiStatusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private HelpProvider MdiHelp;
    private ErrorProvider MdiError;
    private System.ComponentModel.BackgroundWorker MdiBkg;
    private StatusStrip MdiStatusStrip;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private ToolStripProgressBar toolStripProgressBar1;
    private MenuStrip MainMenu;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuFileQuit;
    private ToolStripMenuItem mnuView;
    private ToolStripMenuItem mnuTools;
    private ToolStripMenuItem mnuHelp;
    private ToolStripStatusLabel toolStripStatusLabel4;
    private ToolStripMenuItem mnuHelpOnline;
    private ToolStripMenuItem mnuHelpAbout;
    private ToolStripMenuItem mnuHelpGetFullVersion;
    private ToolStripMenuItem payAndRegisterToolStripMenuItem;
    private ToolStripMenuItem enterProductkeyToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem mnuViewSwitchLanguage;
    private ToolStripMenuItem mnuViewSwitchLanguageDe;
    private ToolStripMenuItem mnuViewSwitchLanguageEn;
    private ToolStripMenuItem mnuViewSwitchLanguageFi;
    private ToolStripMenuItem mnuViewSwitchLanguageUa;
    private ToolStripMenuItem mnuHelpToC;
    private ToolStripMenuItem mnuHelpPrivacy;
    private ToolStripMenuItem mnuWindow;
    private ToolStripMenuItem mnuFileJoinGame;
    private ToolStripMenuItem mnuCommunityEditPlayerProfile;
    private ToolStrip MainToolbar;
    private ToolStripButton tbbInitiate;
    private ToolStripButton tbbJoin;
    private ToolStripButton tbbEditPlayerProfile;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem mnuFileInitiateTournamentOnline;
    private ToolStripMenuItem mnuFileInitiateTournamentLocal;
    private ToolStripMenuItem mnuFilePractice;
    private ToolStripMenuItem mnuFileLoadSavegame;
    private ToolStripMenuItem mnuViewServerTraffic;
    private ToolStripMenuItem mnuViewApiMessages;
    private ToolStripMenuItem mnuToolsLevelDesigner;
    private ToolStripButton tbbViewServerTraffic;
    private ToolStripButton tbbViewApiMessageLog;
    private ToolStripMenuItem mnuViewShowGrid;
    private ToolStripMenuItem mnuToolsMaterials;
    private ToolStripMenuItem mnuToolsBossKey;
    private ToolStripMenuItem mnuFileSave;
    private ToolStripMenuItem toolStripMenuItem10;
    private ToolStripMenuItem mnuToolsAssetMgr;
    private ToolStripSeparator mnuViewSeparator;
    private ToolStripSeparator mnuToolsSeparator;
    private ToolStripMenuItem mnuCommunity;
    private ToolStripSeparator mnuCommunitySeparator;
    private ToolStripMenuItem mnuCommunityDiscord;
    private ToolStripMenuItem mnuCommunityForum;
    private ToolStripMenuItem mnuWindowClose;
    private ToolStripMenuItem mnuWindowArrange;
    private ToolStripMenuItem mnuWindowMinimizeAll;
    private ToolStripSeparator mnuWindowSeparator;
    private ToolStripSeparator mnuFileSeparator1;
    private ToolStripSeparator mnuFileSeparator2;
    private ToolStripMenuItem mnuFileOpenWorkspace;
    private ToolStripMenuItem mnuFileSaveAs;
    private ToolStripSeparator mnuFileSeparator3;
    private ToolStripMenuItem mnuViewStickToGrid;
}
