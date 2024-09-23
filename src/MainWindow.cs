using ScorchGore.Configuration;
using ScorchGore.Forms;
using ScorchGore.Translation;

namespace Fso.ScorchGore;

public partial class MainWindow : Form
{
    private readonly frmOutputPane outputPane;
    private readonly frmApiMessages apiMessagePane;
    private bool isFirstActivate = true;

    public MainWindow()
    {
        InitializeComponent();
        outputPane = new frmOutputPane()
        {
            MdiParent = this
        };

        apiMessagePane = new frmApiMessages()
        {
            MdiParent = this
        };

    }
    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        if(!isFirstActivate)
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

        var sharewarePart = InstanceSettings.Edition == "S"
            ? $" | {Translation.µ(2).ToUpper()}" // SHAREWARE EDITION
            : string.Empty;

        if (Program.WhichInstanceAmI > 1)
        {
            Text = $"{Translation.µ(3)} (#{Program.WhichInstanceAmI}){sharewarePart}"; // scorchgore
        }
        else
        {
            Text = $"{Translation.µ(3)}{sharewarePart}"; // scorchgore
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

        ApplyTranslation(language);
    }

    private void ApplyTranslation(string lcid)
    {
        InstanceSettings.Language = lcid;
        mnuFile.Text = Translation.µ(1); /* File */
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
}
