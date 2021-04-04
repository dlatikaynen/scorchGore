using ScorchGore.Klassen;
using System.Windows.Forms;

namespace ScorchGore.Benutzeroberflaeche
{
    public partial class LevelUebergang : Form
    {
        public LevelUebergang()
        {
            this.InitializeComponent();
        }

        public LevelUebergang(Treffer rundenErgebnis) : this()
        {
            var gespieltesLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(rundenErgebnis.GespieltesLevel);
            this.Ueberschrift.Text = $@"{ rundenErgebnis.ObsiegenderSpieler.Name } and { rundenErgebnis.GetroffenerSpieler.Name } on a Wrath of the Mild series of missions";
            this.AktuellesLevel.Text = $@"Level { rundenErgebnis.GespieltesLevel }: ""{ gespieltesLevel.LevelName }""";
            this.AktuellesLevelDetails.Text = $@"Being the { gespieltesLevel.LevelNummerInMission } level in the ""{ gespieltesLevel.MissionsName }"" mission";
            this.ErgebnisGewonnen.Text = $@"{ rundenErgebnis.ObsiegenderSpieler.Name } won, { rundenErgebnis.ObsiegenderSpieler.Lebenspunkte } HP left";
            if (rundenErgebnis.Ergebnis == SchussErgebnis.SelbstErschossen)
            {
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } n00bed themselves out";
            }
            else
            {
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } has been pwned";
            }

            var kommendesLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(rundenErgebnis.GespieltesLevel + 1);
            if (kommendesLevel == null)
            {
                this.KommendesLevel.Text = "Be at peace";
                this.KommendesLevelDetails.Text = "Congratulations, you completed all missions";
            }
            else
            {
                this.KommendesLevel.Text = $@"Level { rundenErgebnis.GespieltesLevel + 1 }: ""{ kommendesLevel.LevelName }""";
                this.KommendesLevelDetails.Text = $@"Being the { kommendesLevel.LevelNummerInMission } level in the ""{ kommendesLevel.MissionsName }"" mission";
            }
        }
    }
}
