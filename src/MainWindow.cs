using ScorchGore.Configuration;

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
        if(complainAlready)
        {
            if(mnuViewSwitchLanguageDe.Checked && language == "de")
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
}
