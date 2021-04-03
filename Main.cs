using ScorchGore.Aufzaehlungen;
using ScorchGore.Klassen;
using ScorchGore.OnlineMultiplayer;
using ScorchGore.Steuerelemente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore
{
    public partial class Main : Form
    {
        internal const int spielerBreite = 30;
        internal const int spielerBasisHoehe = 15;
        internal const int obererRand = 15;

        private const int spielerHalbeBreite = Main.spielerBreite / 2;
        private const float schwerkraftFaktor = 9.81f / 2.0f;

        private bool mitMausVerschieben;
        private Point mitMausVerschiebenAnfang;

        private SpielPhase spielPhase;
        private Hauptmenuepunkt hauptMenuePunkt = Hauptmenuepunkt.StartMission;
        private Bitmap levelBild;
        private int aktuelleLevelNummer;
        private readonly Spieler spielerEins;
        private readonly Spieler spielerZwei;
        private Spieler dranSeiender;
        private Spieler meinSpieler;
        private readonly Audio Audio = new Audio();
        private readonly Goodies Goodies = new Goodies();
        private readonly MultiplayerCloud MultiplayerCloud = new MultiplayerCloud();
        
        private Bitmap ausgangsZustand;

        public Main()
        {
            this.InitializeComponent();
            this.Audio.AlleAudiosVorbereiten();
            this.Goodies.AlleGoodiesVorbereiten();
            this.levelBild = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            var spielerNamen = SpielerNamen.ZufallsNamenspaar;
            this.spielerEins = new Spieler(this, this.levelBild)
            {
                Name = spielerNamen.Item1,
                Farbe = Brushes.YellowGreen,
                X = Main.spielerBreite,
                Y = Main.spielerBasisHoehe
            };

            this.spielerZwei = new Spieler(this, this.levelBild)
            {
                Name = spielerNamen.Item2,
                Farbe = Brushes.MistyRose,
                X = this.Width - Main.spielerBreite,
                Y = Main.spielerBasisHoehe
            };

            this.spielPhase = SpielPhase.StartBildschirm;
            this.aktuelleLevelNummer = 0;
        }

        internal Spieler Gegner => object.ReferenceEquals(this.dranSeiender, this.spielerEins) ? this.spielerZwei : this.spielerEins;

        #region Menue
        private async void MenueStartUebungsspielLabel_Click(object sender, EventArgs e)
        {
            this.SetzeSchlange(this.MenueUebungsspielSchlange);
            await Task.Delay(150);
            this.MenueWegraeumen();
            this.UebungsspielVorbereiten();
        }

        private async void MenueStartMissionLabel_Click(object sender, EventArgs e)
        {
            this.SetzeSchlange(this.MenueMissionSchlange);
            await Task.Delay(150);
            this.MenueWegraeumen();
            this.MissionVorbereiten();
        }

        private async void MenueEinstellungenLabel_Click(object sender, EventArgs e)
        {
            this.SetzeSchlange(this.MenueEinstellungenSchlange);
            await Task.Delay(150);

        }

        private async void MenueBeendenLabel_Click(object sender, EventArgs e)
        {
            this.SetzeSchlange(this.MenueBeendenSchlange);
            await Task.Delay(150);
            Application.Exit();
        }

        private void MenueUebungsspielSchlange_Click(object sender, EventArgs e) => this.MenueStartUebungsspielLabel_Click(sender, e);
        private void MenueMissionSchlange_Click(object sender, EventArgs e) => this.MenueStartMissionLabel_Click(sender, e);
        private void MenueEinstellungenSchlange_Click(object sender, EventArgs e) => this.MenueEinstellungenLabel_Click(sender, e);
        private void MenueBeendenSchlange_Click(object sender, EventArgs e) => this.MenueBeendenLabel_Click(sender, e);

        private void SetzeSchlange(PictureBox schlangenMenue)
        {
            var bildQuelle = new ComponentResourceManager(typeof(Main));
            var schlangenBild = ((Image)(bildQuelle.GetObject($"{ nameof(MenueMissionSchlange) }.{ nameof(Image) }")));
            this.MenueBeendenSchlange.Image = object.ReferenceEquals(schlangenMenue, this.MenueBeendenSchlange) ? schlangenBild : null;
            this.MenueEinstellungenSchlange.Image = object.ReferenceEquals(schlangenMenue, this.MenueEinstellungenSchlange) ? schlangenBild : null;
            this.MenueMissionSchlange.Image = object.ReferenceEquals(schlangenMenue, this.MenueMissionSchlange) ? schlangenBild : null;
            this.MenueUebungsspielSchlange.Image = object.ReferenceEquals(schlangenMenue, this.MenueUebungsspielSchlange) ? schlangenBild : null;
        }

        private void MenueSchlangeSetzen()
        {
            switch (this.hauptMenuePunkt)
            {
                case Hauptmenuepunkt.StartUebung:
                    this.SetzeSchlange(this.MenueUebungsspielSchlange);
                    break;

                case Hauptmenuepunkt.StartMission:
                    this.SetzeSchlange(this.MenueMissionSchlange);
                    break;

                case Hauptmenuepunkt.Einstellungen:
                    this.SetzeSchlange(this.MenueEinstellungenSchlange);
                    break;

                case Hauptmenuepunkt.Beenden:
                    this.SetzeSchlange(this.MenueBeendenSchlange);
                    break;
            }
        }

        private void HauptMenueAuswahl()
        {
            switch (this.hauptMenuePunkt)
            {
                case Hauptmenuepunkt.StartUebung:
                    this.MenueUebungsspielSchlange_Click(this, null);
                    break;

                case Hauptmenuepunkt.StartMission:
                    this.MenueMissionSchlange_Click(this, null);
                    break;

                case Hauptmenuepunkt.Einstellungen:
                    this.MenueEinstellungenSchlange_Click(this, null);
                    break;

                case Hauptmenuepunkt.Beenden:
                    this.MenueBeendenSchlange_Click(this, null);
                    break;
            }
        }

        private void MenueWegraeumen()
        {
            this.MenueStartUebungsspielLabel.Hide();
            this.MenueStartMissionLabel.Hide();
            this.MenueEinstellungenLabel.Hide();
            this.MenueBeendenLabel.Hide();
            this.MenueUebungsspielSchlange.Hide();
            this.MenueMissionSchlange.Hide();
            this.MenueEinstellungenSchlange.Hide();
            this.MenueBeendenSchlange.Hide();
        }
        #endregion

        private void UebungsspielVorbereiten()
        {
            this.spielPhase = SpielPhase.WeltErzeugen;
            this.aktuelleLevelNummer = 0;
            this.WeltErzeugen.Center(this);
            this.WeltErzeugen.Show();
        }

        private void MissionVorbereiten()
        {
            this.spielPhase = SpielPhase.WeltErzeugen;
            this.aktuelleLevelNummer = 1;

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return))
            {
                e.Handled = e.SuppressKeyPress = true;
                this.BeginInvoke(new Action(async () =>
                {
                    /* im invoke, damit die kacke nicht immer so nervtötend piepst */
                    if (this.spielPhase == SpielPhase.StartBildschirm)
                    {
                        this.HauptMenueAuswahl();
                    }
                    else if (this.spielPhase == SpielPhase.WeltErzeugen)
                    {
                        this.KampfStarten();
                    }
                    else if (this.spielPhase == SpielPhase.Schusseingabe)
                    {
                        var schussEingabe = await this.SchussEingeben();
                        if (schussEingabe != null)
                        {
                            this.RundeAustragen(schussEingabe);
                        }
                    }
                }));
            }
            else if (e.KeyCode == Keys.Left && this.spielPhase == SpielPhase.SpielrundeAktiv)
            {
                this.FahrenSpieler(-1);
            }
            else if (e.KeyCode == Keys.Right && this.spielPhase == SpielPhase.SpielrundeAktiv)
            {
                this.FahrenSpieler(1);
            }
            else if (e.KeyCode == Keys.Up && this.spielPhase == SpielPhase.StartBildschirm)
            {
                --this.hauptMenuePunkt;
                if (this.hauptMenuePunkt == Hauptmenuepunkt.UNTERLAUF)
                {
                    this.hauptMenuePunkt = Hauptmenuepunkt.UEBERLAUF - 1;
                }

                this.MenueSchlangeSetzen();
            }
            else if (e.KeyCode == Keys.Down && this.spielPhase == SpielPhase.StartBildschirm)
            {
                ++this.hauptMenuePunkt;
                if (this.hauptMenuePunkt == Hauptmenuepunkt.UEBERLAUF)
                {
                    this.hauptMenuePunkt = Hauptmenuepunkt.UNTERLAUF + 1;
                }

                this.MenueSchlangeSetzen();
            }
        }

        private void FahrenSpieler(int richtung)
        {
            this.dranSeiender.X += richtung;
            using (var zeichnung = Graphics.FromImage(this.levelBild))
            {
                this.dranSeiender.Zeichnen(zeichnung);
                this.SpielerFallen(this.dranSeiender);
                this.Refresh();
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
            this.ausgangsZustand = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            this.BackgroundImage = this.levelBild;
            LevelBeschreibung levelBeschreibung;
            if (this.aktuelleLevelNummer == 0)
            {
                /* berg-steilheit und rauhheit und höhenprofil mit zufallszahlen bestimmen */
                levelBeschreibung = new LevelBeschreibung
                {
                    BergZufallszahl = MultiplayerCloud.BergZufallszahl,
                    BergMinHoeheProzent = this.MindesthoeheProzent.Value,
                    BergMaxHoeheProzent = this.HoechstHoeheProzent.Value,
                    BergRauhheitProzent = this.RauheitsfaktorProzent.Value
                };
            }
            else
            {
                levelBeschreibung = LevelSequenzierer.ErzeugeLevelBeschreibung(this.aktuelleLevelNummer);
            }

            using (var zeichenFlaeche = Graphics.FromImage(this.levelBild))
            {
                LevelZeichner.Zeichne(this, this.levelBild, levelBeschreibung, zeichenFlaeche);
                var goodie = new Goodie(this, this.levelBild, this.Goodies, GoodieWirkung.Chrom_Dreifachschuss)
                {
                    X = 166
                };

                goodie.FallenLassen(zeichenFlaeche);
            }

            this.Refresh();
            this.spielPhase = SpielPhase.SpielerFallenRundeBeginnt;
            this.AusgangszustandSichern();
            this.SpielerFallen(this.spielerEins);
            this.SpielerFallen(this.spielerZwei);
        }

        private void SpielerFallen(Spieler fallenderSpieler)
        {
            try
            {
                using (var zeichenFlaeche = Graphics.FromImage(this.levelBild))
                {
                    fallenderSpieler.FallenLassen(zeichenFlaeche);
                }
            }
            finally
            {
                this.Refresh();
            }
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
            var schussErgebnis = this.Schiessen(schussEingabe);

            /* wenn keiner getroffen wurde, rollen tauschen,
             * der andere spieler ist dran */
            if (schussErgebnis.Ergebnis == SchussErgebnis.GegnerGekillt)
            {
                this.Audio.GeraeuschAbspielen(Geraeusche.SchussEinschlag);
            }
            else
            {
                /* falls ein berg getroffen wurde, kann es sein, dass der andere spieler
                 * den boden unter sich verloren hat, und tiefer fällt */
                var koennteFallen = false;
                if (schussErgebnis.Ergebnis == SchussErgebnis.BergGetroffen)
                {
                    Audio.GeraeuschAbspielen(Geraeusche.SchussEinschlag);
                    this.Noobsplosion(schussErgebnis.EinschlagsKoordinateX, schussErgebnis.EinschlagsKoordinateY);
                    koennteFallen = true;
                }

                this.AusgangszustandWiederherstellen();
                if(koennteFallen)
                {
                    using (var zeichenFlaeche = Graphics.FromImage(this.levelBild))
                    {
                        this.dranSeiender.Zeichnen(zeichenFlaeche);
                        this.Gegner.Zeichnen(zeichenFlaeche);
                    }

                    this.SpielerFallen(this.Gegner);
                    this.SpielerFallen(this.dranSeiender);
                }
                else
                {
                    this.Refresh();
                }

                /* spieler wechseln sich jetzt ab */
                this.dranSeiender = this.Gegner;
                this.RundeVorbereiten();
            }
        }

        private Treffer Schiessen(SchussEingabe schussEingabe)
        {
            double x, y;

            /* schiessen wir nach rechts (spieler 1) oder nach links (spieler 2)? */
            var schussRichtung = object.ReferenceEquals(this.dranSeiender, this.spielerEins) ? 1 : -1;
            var v = (float)schussEingabe.SchussKraft;
            var vSkaliert = 1.0f / (v * 0.5f); 
            var mathWinkel = Math.PI * (float)(180 - schussEingabe.SchussWinkel) / 180f;
            var muendungVerlassen = false;
            var behandeltePixel = new List<long>();
            var ausgangsPunktx = this.dranSeiender.X;
            var ausgangsPunkty = this.dranSeiender.Y;
            var schussErgebnis = new Treffer { Ergebnis = SchussErgebnis.NixGetroffen };

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
                var pixelX = ausgangsPunktx - (int)x * schussRichtung;
                var pixelY = ausgangsPunkty - (int)y;
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
                                return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.GegnerGekillt);
                            }
                            else if (hitColor != Farbverwaltung.HimmelsfarbeAlsInt)
                            {
                                if (hitColor == ((SolidBrush)this.dranSeiender.Farbe).Color.ToArgb())
                                {
                                    return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.SelbstErschossen);
                                }
                                else
                                {
                                    return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.BergGetroffen);
                                }
                            }

                            this.levelBild.SetPixel(pixelX, pixelY, ((SolidBrush)this.dranSeiender.Farbe).Color);
                            behandeltePixel.Add(pixelFach);
                        }
                    }
                }

                Application.DoEvents();
                this.Refresh();

                /* schuss ist links, rechts, oder unten rausgeflogen */
                if (pixelY > this.levelBild.Height || pixelX < 0 || pixelX > this.levelBild.Width)
                {
                    break;
                }
            }

            return schussErgebnis;
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

        private void Noobsplosion(int pixelX, int pixelY)
        {
            const int explosionsRadius = 50;
            var hangRutschung = new Hangrutschung(this);
            using (var zeichnung = Graphics.FromImage(this.levelBild))
            {
                var durchMesser = 2 * explosionsRadius;
                for (var explosionsBreite = 1; explosionsBreite < durchMesser; explosionsBreite += 2)
                {
                    zeichnung.DrawEllipse(Pens.Red, pixelX - explosionsBreite / 2, pixelY - explosionsBreite / 2, explosionsBreite, explosionsBreite);
                    this.Refresh();
                }

                zeichnung.FillEllipse(Farbverwaltung.Himmelsbuerste, pixelX - 50, pixelY - 50, 100, 100);
                hangRutschung.Bergsturz(
                    this.levelBild, 
                    pixelX - explosionsRadius, 
                    pixelX + explosionsRadius, 
                    pixelY, 
                    explosionsRadius
                );

                hangRutschung.Zeichnen(zeichnung, mitAnimation: true);
            }

            using (var bildKopieren = Graphics.FromImage(this.ausgangsZustand))
            {
                bildKopieren.FillEllipse(Farbverwaltung.Himmelsbuerste, pixelX - 50, pixelY - 50, 100, 100);
                hangRutschung.Zeichnen(bildKopieren, mitAnimation: false);
            }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            this.mitMausVerschieben = true;
            this.mitMausVerschiebenAnfang = e.Location;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mitMausVerschieben)
            {
                this.Location = new Point(
                    (this.Location.X - this.mitMausVerschiebenAnfang.X) + e.X,
                    (this.Location.Y - this.mitMausVerschiebenAnfang.Y) + e.Y
                );

                this.Update();
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            this.mitMausVerschieben = false;
        }
    }
}