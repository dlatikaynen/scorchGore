using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Forms;
using ScorchGore.Leved;
using ScorchGore.Platform;
using Xlat = ScorchGore.Translation.Translation;

namespace Fso.ScorchGore;

public partial class MainWindow : Form
{
    internal static bool ShowGrid;

    private readonly frmOutputPane outputPane;
    private readonly frmApiMessages apiMessagePane;
    private readonly frmLevelManager levelManager;
    private readonly frmMaterials materialsManager;
    private readonly frmAssets assetsManager;

    private bool isFirstActivate = true;

    public MainWindow()
    {
        InitializeComponent();
        outputPane = new()
        {
            MdiParent = this
        };

        apiMessagePane = new()
        {
            MdiParent = this
        };

        levelManager = new()
        {
            MdiParent = this
        };

        materialsManager = new()
        {
            MdiParent = this
        };

        assetsManager = new()
        {
            MdiParent = this
        };

        ShowGrid = mnuViewShowGrid.Checked;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        if (!isFirstActivate)
        {
            return;
        }

        isFirstActivate = false;

        // https://stackoverflow.com/a/23124456/1132334
        var handle = outputPane.Handle;

        outputPane.Hide();
        if (handle == apiMessagePane.Handle)
        {
            throw new InvalidOperationException($"{handle}=={Handle}");
        }

        apiMessagePane.Hide();
    }

    public bool Prepare()
    {
        SetLanguageMenuState(InstanceSettings.Language, complainAlready: false);
        Xlat.RegisterForTranslation(MainWindow_TranslationChanged);

        var sharewarePart = InstanceSettings.Edition == "S"
            ? $" | {Xlat.µ(2).ToUpper()}" // SHAREWARE EDITION
            : string.Empty;

        if (Program.WhichInstanceAmI > 1)
        {
            Text = $"{Xlat.µ(3)} (#{Program.WhichInstanceAmI}){sharewarePart}"; // scorchgore
        }
        else
        {
            Text = $"{Xlat.µ(3)}{sharewarePart}"; // scorchgore
        }

        return true;
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void mnuViewSwitchLanguageDe_Click(object sender, EventArgs e) => SetLanguageMenuState("de");
    private void mnuViewSwitchLanguageEn_Click(object sender, EventArgs e) => SetLanguageMenuState("en");
    private void mnuViewSwitchLanguageFi_Click(object sender, EventArgs e) => SetLanguageMenuState("fi");
    private void mnuViewSwitchLanguageUa_Click(object sender, EventArgs e) => SetLanguageMenuState("ua");

    private void SetLanguageMenuState(string language, bool complainAlready = true)
    {
        if (complainAlready)
        {
            if (mnuViewSwitchLanguageDe.Checked && language == "de")
            {
                NotGermanEnough();

                return;
            }
            else if (mnuViewSwitchLanguageEn.Checked && language == "en")
            {
                NotEnglishEnough();

                return;
            }
            else if (mnuViewSwitchLanguageFi.Checked && language == "fi")
            {
                NotFinnishEnough();

                return;

            }
            else if (mnuViewSwitchLanguageUa.Checked && language == "ua")
            {
                NotUkrainianEnough();

                return;
            }
        }

        switch (language)
        {
            case "de":
                mnuViewSwitchLanguageEn.Checked = false;
                mnuViewSwitchLanguageUa.Checked = false;
                mnuViewSwitchLanguageFi.Checked = false;
                mnuViewSwitchLanguageDe.Checked = true;

                break;

            case "fi":
                mnuViewSwitchLanguageEn.Checked = false;
                mnuViewSwitchLanguageUa.Checked = false;
                mnuViewSwitchLanguageDe.Checked = false;
                mnuViewSwitchLanguageFi.Checked = true;

                break;

            case "ua":
                mnuViewSwitchLanguageEn.Checked = false;
                mnuViewSwitchLanguageFi.Checked = false;
                mnuViewSwitchLanguageDe.Checked = false;
                mnuViewSwitchLanguageUa.Checked = true;

                break;

            default:
                mnuViewSwitchLanguageUa.Checked = false;
                mnuViewSwitchLanguageFi.Checked = false;
                mnuViewSwitchLanguageDe.Checked = false;
                mnuViewSwitchLanguageEn.Checked = true;

                break;
        }

        if (InstanceSettings.Language != language)
        {
            InstanceSettings.Language = language;
            Xlat.OnTranslationChanged(new());
        }
    }

    private void NotGermanEnough()
    {
        using var alreadyGerman = new frmAlreadyGerman();

        alreadyGerman.ShowDialog(this);
    }

    private void NotEnglishEnough()
    {
        using var alreadyBritish = new frmAlreadyEnglish();

        alreadyBritish.ShowDialog(this);
    }

    private void NotUkrainianEnough()
    {
        using var alreadyUkrainian = new frmAlreadyUkrainian();

        alreadyUkrainian.ShowDialog(this);
    }

    private void NotFinnishEnough()
    {
        using var alreadyFinnish = new frmAlreadyFinnish();

        alreadyFinnish.ShowDialog(this);
    }

    private void MainWindow_TranslationChanged(object sender, Xlat.TranslationChangedEventArgs e)
    {
        mnuFile.Text = Xlat.µ(1); /* File */
        mnuView.Text = Xlat.µ(90); /* View */
        mnuTools.Text = Xlat.µ(91); /* Tools */
        mnuCommunity.Text = Xlat.µ(92); /* Community */
        mnuWindow.Text = Xlat.µ(93); /* Window */
        mnuHelp.Text = Xlat.µ(94); /* Help */
        mnuToolsBossKey.Text = Xlat.µ(89); // Boss key
    }

    private void mnuFilePractice_Click(object sender, EventArgs e)
    {
        var frmGame = new frmGame(new())
        {
            MdiParent = this
        };

        frmGame.Show(this);
    }

    private async void mnuFileInitiateTournamentOnline_Click(object sender, EventArgs e)
    {
        if (!EnsurePlayername(this))
        {
            return;
        }

        using var frmInitiate = new frmInitiateGame();

        if (frmInitiate.ShowDialog(this) == DialogResult.OK)
        {
            var frmGame = new frmGame(frmInitiate.NewGame)
            {
                MdiParent = this
            };

            await frmGame.DoSomething();
        };
    }

    private void mnuFileInitiateTournamentLocal_Click(object sender, EventArgs e)
    {
        // two players without internet connection, on the same computer
    }

    private async void mnuFileJoinGame_Click(object sender, EventArgs e)
    {
        using var frmJoin = new frmJoinGame();

        if (frmJoin.ShowDialog(this) == DialogResult.OK)
        {
            var frmGame = new frmGame(frmJoin.JoinedSession)
            {
                MdiParent = this
            };

            await frmGame.DoSomething();
        }
    }

    private void mnuCommunityEditPlayerProfile_Click(object sender, EventArgs e)
    {
        using var playerProfile = new frmEditPlayerProfile();

        if (playerProfile.ShowDialog(this) == DialogResult.OK)
        {
            // update?
        }
    }

    private static bool EnsurePlayername(Form owner)
    {
        if (string.IsNullOrWhiteSpace(InstanceSettings.PlayerName))
        {
            using var namePlayer = new frmEditPlayerProfile();

            return namePlayer.ShowDialog(owner) == DialogResult.OK;
        }

        return true;
    }

    private void tbbInitiate_Click(object sender, EventArgs e)
    {
        mnuFileInitiateTournamentOnline_Click(sender, e);
    }

    private void tbbJoin_Click(object sender, EventArgs e)
    {
        mnuFileJoinGame_Click(sender, e);
    }

    private void ttbEditPlayerProfile_Click(object sender, EventArgs e)
    {
        mnuCommunityEditPlayerProfile_Click(sender, e);
    }

    private void mnuViewServerTraffic_Click(object sender, EventArgs e)
    {
        if (outputPane.Visible)
        {
            outputPane.BringToFront();
        }
        else
        {
            outputPane.Show();
        }

        if (outputPane.WindowState == FormWindowState.Minimized)
        {
            outputPane.WindowState = FormWindowState.Normal;
        }
    }

    private void mnuViewApiMessages_Click(object sender, EventArgs e)
    {
        if (apiMessagePane.Visible)
        {
            apiMessagePane.BringToFront();
        }
        else
        {
            apiMessagePane.Show();
        }

        if (apiMessagePane.WindowState == FormWindowState.Minimized)
        {
            apiMessagePane.WindowState = FormWindowState.Normal;
        }
    }

    private void mnuHelpAbout_Click(object sender, EventArgs e)
    {
        new frmAbout().ShowDialog(this);
    }

    private void tbbViewServerTraffic_Click(object sender, EventArgs e)
    {
        mnuViewServerTraffic_Click(sender, e);
    }

    private void tbbViewApiMessageLog_Click(object sender, EventArgs e)
    {
        mnuViewApiMessages_Click(sender, e);
    }

    private void mnuToolsLevelDesigner_Click(object sender, EventArgs e)
    {
        if (levelManager.Visible)
        {
            levelManager.BringToFront();
        }
        else
        {
            levelManager.MdiParent = this;
            levelManager.Show();
        }
    }

    private void mnuToolsMaterials_Click(object sender, EventArgs e)
    {
        if (materialsManager.Visible)
        {
            materialsManager.BringToFront();
        }
        else
        {
            materialsManager.MdiParent = this;
            materialsManager.Show();
        }
    }

    private void mnuToolsAssetMgr_Click(object sender, EventArgs e)
    {
        if (assetsManager.Visible)
        {
            assetsManager.BringToFront();
        }
        else
        {
            assetsManager.MdiParent = this;
            assetsManager.Show();
        }
    }

    private void mnuViewShowGrid_Click(object sender, EventArgs e)
    {
        ShowGrid = mnuViewShowGrid.Checked;
    }

    private void mnuToolsBossKey_Click(object sender, EventArgs e)
    {
        PlatformWindows.RunScr();
    }

    private void mnuFileSave_Click(object sender, EventArgs e)
    {
        DesignWorkspace.EnsureDesignWorkspace();
        DesignWorkspace.SaveWorkspace();
    }

    /// <summary>
    /// Prevent accidential loss of unsaved data
    /// </summary>
    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.ApplicationExitCall)
        {
            return;
        }

        if (DesignWorkspace.HasUnsavedData)
        {
            var decision = new frmUnsavedData().ShowDialog(this);

            if (decision == DialogResult.Yes)
            {
                DesignWorkspace.SaveWorkspace();
            }
            else if (decision != DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

    private void mnuCommunityDiscord_Click(object sender, EventArgs e)
    {
        PlatformWindows.OpenUrlInBrowser(InfrastructureConstants.CommunityUrl);
    }
}
