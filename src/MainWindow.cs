using ScorchGore.Configuration;
using ScorchGore.Forms;
using ScorchGore.Translation;

namespace Fso.ScorchGore;

public partial class MainWindow : Form
{
    private readonly frmOutputPane outputPane;
    private readonly frmApiMessages apiMessagePane;

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

    private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
    {

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

    private void mnuFileInitiateTournamentOnline_Click(object sender, EventArgs e)
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

            frmGame.DoSomething();
        };
    }

    private void mnuFileInitiateTournamentLocal_Click(object sender, EventArgs e)
    {
        // two players without internet connection, on the same computer
    }

    private void mnuFileJoinGame_Click(object sender, EventArgs e)
    {
        using var frmJoin = new frmJoinGame();

        if (frmJoin.ShowDialog(this) == DialogResult.OK)
        {
            var frmGame = new frmGame(frmJoin.JoinedSession)
            {
                MdiParent = this
            };

            frmGame.DoSomething();
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
    }
}
