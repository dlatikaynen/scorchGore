using ScorchGore.Configuration;
using ScorchGore.Forms;
using ScorchGore.Translation;
using System.Runtime.CompilerServices;

namespace Fso.ScorchGore;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public bool Prepare()
    {
        SetLanguageMenuState(InstanceSettings.Language, complainAlready: false);

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
        mnuFile.Text = Translation.�(1); /* File */
    }

    private static void NotGermanEnough()
    {

    }

    private static void NotEnglishEnough()
    {

    }

    private static void NotUkrainianEnough()
    {

    }

    private static void NotFinnishEnough()
    {

    }

    private void mnuFileNewGamePracticeLocal_Click(object sender, EventArgs e)
    {
        var frmGame = new frmGame
        {
            MdiParent = this
        };

        frmGame.Show();
    }

    private void mnuFileNewGameTournamentOnline_Click(object sender, EventArgs e)
    {
        using var frmInitiate = new frmInitiateGame();

        if (frmInitiate.ShowDialog() == DialogResult.OK)
        {
            var frmGame = new frmGame
            {
                MdiParent = this
            };

            frmGame.Show();
            frmGame.Immerse();
        };
    }

    private void joinGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var frmJoin = new frmJoinGame();

        if (frmJoin.ShowDialog() == DialogResult.OK)
        {
            var frmGame = new frmGame
            {
                MdiParent = this
            };

            frmGame.Show();
            frmGame.Immerse();
        }
    }
}