using ScorchGore.Aufzaehlungen;
using ScorchGore.Klassen;
using ScorchGore.OnlineMultiplayer;
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
        private const float schwerkraftFaktor = 9.81f / 2.0f;

        private SpielPhase spielPhase;
        private Bitmap levelBild;
        private Spieler spielerEins;
        private Spieler spielerZwei;
        private Spieler dranSeiender;
        private Spieler meinSpieler;
        private Audio Audio = new Audio();
        private MultiplayerCloud MultiplayerCloud = new MultiplayerCloud();
        
        private Bitmap ausgangsZustand;

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

        internal Spieler Gegner => object.ReferenceEquals(this.dranSeiender, this.spielerEins) ? this.spielerZwei : this.spielerEins;

        private async void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                if (this.spielPhase == SpielPhase.WeltErzeugen)
                {
                    this.KampfStarten();
                }                
                else if(this.spielPhase == SpielPhase.Schusseingabe)
                {
                    var schussEingabe = await this.SchussEingeben();
                    if (schussEingabe != null)
                    {
                        this.RundeAustragen(schussEingabe);
                    }
                }

                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void StartOffline_Click(object sender, EventArgs e) => this.KampfStarten();

        private async void StartCloud_Click(object sender, EventArgs e)
        {
            this.spielPhase = SpielPhase.AufMitspielerWarten;
            this.WeltErzeugen.Hide();
            this.SpielerNamenZeigen();
            this.CloudVerbindung.Show();
            var mitspielerGefunden = false;
            do
            {
                var warteZustand = new LevelBeschreibung
                {
                    MitspielerStatus = MitspielerFindenStatus.Wartend,
                    BergZufallszahl = this.MultiplayerCloud.BergZufallszahl,
                    BergMinHoeheProzent = this.MindesthoeheProzent.Value,
                    BergMaxHoeheProzent = this.HoechstHoeheProzent.Value,
                    BergRauhheitProzent = this.RauheitsfaktorProzent.Value
                };

                warteZustand = await this.MultiplayerCloud.MitspielerFinden(warteZustand);
                switch(warteZustand.MitspielerStatus)
                {
                    case MitspielerFindenStatus.HeloGesagt:
                        this.MitspielerFindenFortschritt.Value = 0;
                        break;

                    case MitspielerFindenStatus.Wartend:
                        this.MitspielerFindenFortschritt.Value = new Random().Next(this.MitspielerFindenFortschritt.Maximum);
                        await Task.Delay(1500);
                        break;

                    case MitspielerFindenStatus.AndererNimmtBeiMirTeil:
                        mitspielerGefunden = true;
                        this.meinSpieler = this.spielerEins;
                        break;

                    case MitspielerFindenStatus.IchNehmeBeiAnderemTeil:
                        /* in dem fall müssen wir die werte vom anderen übernehmen,
                         * damit wir das gleiche level haben wir er */
                        mitspielerGefunden = true;
                        this.meinSpieler = this.spielerZwei;
                        this.MultiplayerCloud.BergZufallszahl = warteZustand.BergZufallszahl;
                        this.MindesthoeheProzent.Value = warteZustand.BergMinHoeheProzent;
                        this.HoechstHoeheProzent.Value = warteZustand.BergMaxHoeheProzent;
                        this.RauheitsfaktorProzent.Value = warteZustand.BergRauhheitProzent;
                        break;
                }
            } while (!mitspielerGefunden);

            this.CloudVerbindung.Hide();
            this.KampfStarten();
        }

        private void KampfStarten()
        {
            this.spielPhase = SpielPhase.WeltWirdErzeugt;
            this.ErzeugeDieWelt();
            this.LevelSpielen();
        }

        private void SpielerNamenZeigen()
        {
            this.PlayerNames.Text = $"{ this.spielerEins.Name } & { this.spielerZwei.Name }";
            this.PlayerNames.Show();
        }

        private void ErzeugeDieWelt()
        {
            this.WeltErzeugen.Hide();
            this.ScorchGore.Hide();
            this.Copyright.Hide();
            this.SpielerNamenZeigen();
            this.SchussEingabefeld.Left = this.Width / 2 - this.SchussEingabefeld.Width / 2;
            this.levelBild = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            this.ausgangsZustand = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            this.BackgroundImage = this.levelBild;
            /* berg-steilheit und rauhheit und höhenprofil mit zufallszahlen bestimmen */
            var verfuegbareBergHoehe = this.Height - Main.obererRand;
            var minimumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(this.MindesthoeheProzent.Value) / 100M);
            var maximumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(this.HoechstHoeheProzent.Value) / 100M);
            var steilHeit = Convert.ToInt32(5 + this.RauheitsfaktorProzent.Value);
            var rauhHeit = 10M - Convert.ToDecimal(this.RauheitsfaktorProzent.Value / 20M);
            var zufallsZahl = new Random(MultiplayerCloud.BergZufallszahl);
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
                        for (
                            var schauenX = fallenderSpieler.X - Main.spielerHalbeBreite;
                            schauenX <= fallenderSpieler.X + Main.spielerHalbeBreite;
                            schauenX += 3
                        )
                        {
                            if (this.levelBild.GetPixel(schauenX, fallenderSpieler.Y + 1) != himmelsFarbe)
                            {
                                weiterFallen = false;
                                return;
                            }
                        }

                        if (weiterFallen)
                        {
                            fallenderSpieler.Y += 2;
                        }

                        this.SpielerZeichnen(zeichenFlaeche, fallenderSpieler);
                        this.Refresh();
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
                gezeichneterSpieler.Y - Main.spielerBasisHoehe + 1,
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

        private async void RundeVorbereiten()
        {
            this.NameDesDranSeienden.Text = $"{ (object.ReferenceEquals(this.spielerEins,this.dranSeiender) ? "← " : string.Empty) }{ this.dranSeiender.Name }{ (object.ReferenceEquals(this.spielerZwei,this.dranSeiender) ? " →" : string.Empty) }";
            this.Winkel.Text = this.Ladung.Text = string.Empty;
            if (this.meinSpieler == null || this.dranSeiender == this.meinSpieler)
            {
                this.spielPhase = SpielPhase.Schusseingabe;
                this.SchussEingabefeld.Show();
                this.Winkel.Focus();
            }
            else
            {
                /* warten, bis der andere spieler online was gemacht hat */
                this.spielPhase = SpielPhase.AufOnlineSchussWarten;
                this.AufGegnerWarten.Show();
                var schussEingabe = await this.MultiplayerCloud.AufGegnerSchussWarten();
                this.AufGegnerWarten.Hide();
                this.RundeAustragen(schussEingabe);
            }
        }

        private async Task<SchussEingabe> SchussEingeben()
        {
            var schussEingabe = this.SchussBefehlLesen();
            if (schussEingabe == null)
            {
                /* eingabe zweifelhaft, feld wechseln */
                if (this.Winkel.ContainsFocus)
                {
                    this.Ladung.Focus();
                    this.Ladung.SelectAll();
                }
                else
                {
                    this.Winkel.Focus();
                    this.Winkel.SelectAll();
                }
            }
            else
            {
                /* eingabe gültig, weiter gehts */
                this.SchussEingabefeld.Hide();
                if (this.MultiplayerCloud.IsOnlineGame)
                {
                    await this.MultiplayerCloud.SchussMelden(schussEingabe);
                }
            }

            return schussEingabe;
        }

        private SchussEingabe SchussBefehlLesen()
        {
            var schussEingabe = new SchussEingabe();
            var winkelText = this.Winkel.Text.Trim().ToLowerInvariant();
            if(schussEingabe.Deserialisieren($"{ winkelText },{ this.Ladung.Text }"))
            {
                return schussEingabe;
            }
            else
            {
                return null;
            }
        }

        private void RundeAustragen(SchussEingabe schussEingabe)
        {
            this.spielPhase = SpielPhase.SpielrundeAktiv;

            /* den schuss ausführen und schauen (ob) was getroffen wurde */
            this.AusgangszustandSichern();
            var schussErgebnis = this.Schiessen(schussEingabe);

            /* wenn keiner getroffen wurde, rollen tauschen,
             * der andere spieler ist dran */
            if (schussErgebnis == SchussErgebnis.GegnerGekillt)
            {
                this.Audio.GeraeuschAbspielen(Geraeusche.SchussEinschlag);
            }
            else
            {
                this.AusgangszustandWiederherstellen();
                this.Refresh();

                /* falls ein berg getroffen wurde, kann es sein, dass der andere spieler
                 * den boden unter sich verloren hat, und tiefer fällt */
                if (schussErgebnis == SchussErgebnis.BergGetroffen)
                {
                    Audio.GeraeuschAbspielen(Geraeusche.SchussEinschlag);
                    this.SpielerFallen(this.Gegner);
                }

                /* spieler wechseln sich jetzt ab */
                this.dranSeiender = this.Gegner;
                this.RundeVorbereiten();
            }
        }

        private SchussEingabe SchussAbfrage()
        {
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
            double x, y;

            /* schiessen wir nach rechts (spieler 1) oder nach links (spieler 2)? */
            var schussRichtung = object.ReferenceEquals(this.dranSeiender, this.spielerEins) ? 1 : -1;
            var v = (float)schussEingabe.SchussKraft;
            var vSkaliert = 1.0f / (v * 0.5f); 
            var mathWinkel = Math.PI * (float)(180 - schussEingabe.SchussWinkel) / 180f;
            var muendungVerlassen = false;
            var behandeltePixel = new List<long>();

            /* von hier nach dort x laufen lassen */
            for (
                var t = 0.0f;
                ;
                t += vSkaliert
            )
            {
                /* formel für die schuss-parabel mit schwerkraft

                    x = v * cos(winkel) * t;
                    y = v * sin(winkel) * t - 0.5g * t²;

                    x --> t² und y --> t³ macht eine coole, brauchbare,
                    akzelerierende hyperbolische flugbahn!

                */
                switch(schussEingabe.Trajektorie)
                {
                    case TrajektorienArt.SinusDaempfer:
                        var powPow = Math.Pow(t, t);
                        x = v * -t;
                        y = v * Math.Sin(powPow) / Math.Pow(2, (powPow - Math.PI / 2.0));
                        break;

                    case TrajektorienArt.Kubisch:
                        var tQuadrat = t * t;
                        x = v * Math.Cos(mathWinkel) * tQuadrat;
                        y = v * Math.Sin(mathWinkel) * t - Main.schwerkraftFaktor * tQuadrat * t;
                        break;

                    default:
                        x = v * Math.Cos(mathWinkel) * t;
                        y = v * Math.Sin(mathWinkel) * t - Main.schwerkraftFaktor * t * t;
                        break;
                }

                /* schuss zeichnen */
                var pixelX = this.dranSeiender.X - (int)x * schussRichtung;
                var pixelY = this.dranSeiender.Y - (int)y;
                if (pixelY > 0 && pixelY < this.levelBild.Height && pixelX > 0 && pixelX < this.levelBild.Width)
                {
                    var pixelFach = ((long)pixelY << 32) + (long)pixelX;
                    if (!behandeltePixel.Contains(pixelFach))
                    {
                        var hitColor = this.levelBild.GetPixel(pixelX, pixelY).ToArgb();
                        if (muendungVerlassen == false)
                        {
                            if (hitColor != ((SolidBrush)this.dranSeiender.Farbe).Color.ToArgb())
                            {
                                this.Audio.GeraeuschAbspielen(Geraeusche.SchussStart);
                                muendungVerlassen = true;
                            }
                        }
                        else
                        {
                            if (hitColor == ((SolidBrush)this.Gegner.Farbe).Color.ToArgb())
                            {
                                return SchussErgebnis.GegnerGekillt;
                            }
                            else if (hitColor != Color.DarkSlateGray.ToArgb())
                            {
                                if (hitColor == ((SolidBrush)this.dranSeiender.Farbe).Color.ToArgb())
                                {
                                    return SchussErgebnis.SelbstErschossen;
                                }
                                else
                                {
                                    return SchussErgebnis.BergGetroffen;
                                }
                            }

                            this.levelBild.SetPixel(pixelX, pixelY, ((SolidBrush)this.dranSeiender.Farbe).Color);
                            behandeltePixel.Add(pixelFach);
                        }
                    }
                }

                this.Refresh();

                /* schuss ist links, rechts, oder unten rausgeflogen */
                if (pixelY > this.levelBild.Height || pixelX < 0 || pixelX > this.levelBild.Width)
                {
                    break;
                }
            }

            return SchussErgebnis.NixGetroffen;
        }

        private void AusgangszustandSichern()
        {
            using (var bildKopieren = Graphics.FromImage(this.ausgangsZustand))
            {
                bildKopieren.DrawImageUnscaled(this.levelBild, 0, 0);
            }
        }

        private void AusgangszustandWiederherstellen()
        {
            using (var bildKopieren = Graphics.FromImage(this.levelBild))
            {
                bildKopieren.DrawImageUnscaled(this.ausgangsZustand, 0, 0);
            }
        } 
    }
}