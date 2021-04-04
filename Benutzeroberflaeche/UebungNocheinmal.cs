using ScorchGore.Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } noobed themselves out";
            }
            else
            {
                this.ErgebnisBesiegt.Text = $"{ rundenErgebnis.GetroffenerSpieler.Name } was defeated";
            }
        }
    }
}
