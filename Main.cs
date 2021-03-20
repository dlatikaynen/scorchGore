using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore
{
    public partial class Main : Form
    {
        private const int obererRand = 15;
        private const int spielerBreite = 30;
        private const int spielerBasisHoehe = 15;
        private const int spielerHalbeBreite = Main.spielerBreite / 2;

        private SpielPhase spielPhase;
        private Bitmap levelBild;
        private Spieler spielerEins;
        private Spieler spielerZwei;
        private Spieler dranSeiender;

        public Main()
        {
            this.InitializeComponent();
            this.spielPhase = SpielPhase.WeltErzeugen;
            this.WeltErzeugen.Show();
            var spielerNamen = SpielerNamen.ZufallsNamenspaar;
            this.spielerEins = new Spieler
            {
                Name = spielerNamen.Item1,
                Farbe = Brushes.YellowGreen,
                X = Main.spielerBreite,
                Y = Main.spielerBasisHoehe
            };

            this.spielerZwei = new Spieler
            {
                Name = spielerNamen.Item2,
                Farbe = Brushes.MistyRose,
                X = this.Width - Main.spielerBreite,
                Y = Main.spielerBasisHoehe
            };
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                if (this.spielPhase == SpielPhase.WeltErzeugen)
                {
                    this.spielPhase = SpielPhase.WeltWirdErzeugt;
                    this.ErzeugeDieWelt();
                    this.LevelSpielen();
                }                
                else if(this.spielPhase == SpielPhase.Schusseingabe)
                {
                    this.RundeAustragen();
                }
            }
        }

        private void ErzeugeDieWelt()
        {
            this.WeltErzeugen.Hide();
            this.ScorchGore.Hide();
            this.Copyright.Hide();
            this.PlayerNames.Text = $"{ this.spielerEins.Name } & { this.spielerZwei.Name }";
            this.PlayerNames.Show();
            this.SchussEingabefeld.Left = this.Width / 2 - this.SchussEingabefeld.Width / 2;
            this.levelBild = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            this.BackgroundImage = this.levelBild;
            /* berg-steilheit und rauhheit und höhenprofil mit zufallszahlen bestimmen */
            var verfuegbareBergHoehe = this.Height - Main.obererRand;
            var minimumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(this.MindesthoeheProzent.Value) / 100M);
            var maximumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(this.HoechstHoeheProzent.Value) / 100M);
            var steilHeit = Convert.ToInt32(5 + this.RauheitsfaktorProzent.Value);
            var rauhHeit = 10M - Convert.ToDecimal(this.RauheitsfaktorProzent.Value / 20M);
            var zufallsZahl = new Random();
            var maximumHoehenunterschied = maximumHoehe - minimumHoehe;
            var aktuelleHoehe = Convert.ToDecimal(minimumHoehe + zufallsZahl.Next(maximumHoehenunterschied));
            var aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
            var aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
            var unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
            using (var zeichenFlaeche = Graphics.FromImage(this.levelBild))
            {                
                zeichenFlaeche.FillRectangle(Brushes.DarkSlateGray, zeichenFlaeche.ClipBounds);
                for (var bergX = 0; bergX < this.Width; bergX += 2)
                {
                    /* berg höhenänderung berechnen */
                    var hoehenAenderung = 0M;
                    if (aktuelleRichtung)
                    {
                        hoehenAenderung += aktuelleSteilheit;
                    }
                    else
                    {
                        hoehenAenderung -= aktuelleSteilheit;
                    }

                    aktuelleHoehe += hoehenAenderung;
                    if (aktuelleHoehe < 0)
                    {
                        aktuelleRichtung = true;
                        aktuelleHoehe = aktuelleSteilheit / 2M;
                    }
                    else if (aktuelleHoehe > maximumHoehenunterschied)
                    {
                        aktuelleRichtung = false;
                        aktuelleHoehe = maximumHoehenunterschied - aktuelleSteilheit / 2M;
                    }

                    /* berg zeichnen */
                    var pixelHoehe = minimumHoehe + Convert.ToInt32(aktuelleHoehe);
                    zeichenFlaeche.FillRectangle(Brushes.SlateBlue, bergX, (float)this.Height - pixelHoehe, 2f, (float)this.Height);

                    /* zacken in den berg machen */
                    if (--unveraenderteSteigung <= 0)
                    {
                        this.Refresh();
                        aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
                        aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
                        unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
                    }
                }
            }

            this.Refresh();
            this.spielPhase = SpielPhase.SpielerFallenRundeBeginnt;
            this.SpielerFallen(this.spielerEins);
            this.SpielerFallen(this.spielerZwei);
        }

        private void SpielerFallen(Spieler fallenderSpieler)
        {
            try
            {
                using (var zeichenFlaeche = Graphics.FromImage(this.levelBild))
                {
                    var weiterFallen = true;
                    var himmelsFarbe = this.levelBild.GetPixel(1, 1);
                    while (weiterFallen)
                    {
                        this.SpielerZeichnen(zeichenFlaeche, fallenderSpieler);
                        this.Refresh();
                        for (
                            var schauenX = fallenderSpieler.X - Main.spielerHalbeBreite;
                            schauenX <= fallenderSpieler.X + Main.spielerHalbeBreite;
                            schauenX += 3
                        )
                        {
                            if (this.levelBild.GetPixel(schauenX, fallenderSpieler.Y + 1) != himmelsFarbe)
                            {
                                weiterFallen = false;
                                break;
                            }
                        }

                        if (weiterFallen)
                        {
                            fallenderSpieler.Y += 2;
                        }                        
                    }
                }
            }
            finally
            {
                this.Refresh();
            }
        }

        private void SpielerZeichnen(Graphics zeichenFlaeche, Spieler gezeichneterSpieler)
        {
            /* das über dem spieler, wo er gefallen ist, wieder mit himmelsfarbe übermalen */
            zeichenFlaeche.FillRectangle(
                Brushes.DarkSlateGray,
                gezeichneterSpieler.X - Main.spielerHalbeBreite,
                0,
                Main.spielerBreite,
                gezeichneterSpieler.Y
            );

            /* den spieler selbst neu zeichnen: ein gefüllter halbkreis mit rundung oben */
            zeichenFlaeche.FillPie(
                gezeichneterSpieler.Farbe,
                gezeichneterSpieler.X - Main.spielerHalbeBreite,
                gezeichneterSpieler.Y - Main.spielerBasisHoehe,
                Main.spielerBreite,
                2 * Main.spielerBasisHoehe,
                0f,
                -180f
            );
        }

        private void LevelSpielen()
        {
            this.dranSeiender = this.spielerEins;
            this.RundeVorbereiten();
        }

        private void RundeVorbereiten()
        {
            this.NameDesDranSeienden.Text = $"{ (object.ReferenceEquals(this.spielerEins,this.dranSeiender) ? "← " : string.Empty) }{ this.dranSeiender.Name }{ (object.ReferenceEquals(this.spielerZwei,this.dranSeiender) ? " →" : string.Empty) }";
            this.spielPhase = SpielPhase.Schusseingabe;
            this.SchussEingabefeld.Show();
        }

        private void RundeAustragen()
        {
            this.spielPhase = SpielPhase.SpielrundeAktiv;

            /* den dran seienden spieler nach winkel und stärke fragen */
            var schussEingabe = this.SchussAbfrage();

            /* den schuss ausführen und schauen (ob) was getroffen wurde */
            var schussErgebnis = this.Schiessen(schussEingabe);

            /* wenn keiner getroffen wurde, rollen tauschen,
                * der andere spieler ist dran */
            if (schussErgebnis != SchussErgebnis.GegnerGekillt)
            {
                this.dranSeiender = object.ReferenceEquals(this.dranSeiender, this.spielerEins) ? this.spielerZwei : this.spielerEins;
                /* falls ein berg getroffen wurde, kann es sein, dass der andere spieler
                 * den boden unter sich verloren hat, und tiefer fällt */
                if (schussErgebnis == SchussErgebnis.BergGetroffen)
                {
                    this.SpielerFallen(dranSeiender);
                }

                this.RundeVorbereiten();
            }
        }

        private SchussEingabe SchussAbfrage()
        {
            this.SchussEingabefeld.Hide();
            int.TryParse(this.Winkel.Text, out int winkelWert);
            int.TryParse(this.Ladung.Text, out int ladungWert);
            return new SchussEingabe
            {
                SchussWinkel = winkelWert,
                SchussKraft = ladungWert
            };
        }

        private SchussErgebnis Schiessen(SchussEingabe schussEingabe)
        {


            return SchussErgebnis.NichtGeschossen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}