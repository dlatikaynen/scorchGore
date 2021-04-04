using ScorchGore.Klassen;
using System.Windows.Forms;

namespace ScorchGore.Benutzeroberflaeche
{
    public partial class UebungNocheinmal : Form
    {
        public UebungNocheinmal()
        {
            this.InitializeComponent();
        }

        public UebungNocheinmal(Treffer rundenErgebnis) : this()
        {
            this.ErgebnisGewonnen.Text = $@"{ rundenErgebnis.ObsiegenderSpieler.Name } won, { rundenErgebnis.ObsiegenderSpieler.Lebenspunkte } HP left";
            if (rundenErgebnis.Ergebnis == SchussErgebnis.SelbstErschossen)
            {
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } n00bed themselves out";
            }
            else
            {
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } has been pwned";
            }
        }
    }
}
