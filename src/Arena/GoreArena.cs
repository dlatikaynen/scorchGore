﻿using ScorchGore.Classes;
using ScorchGore.Constants;
using ScorchGore.Sequencer;
using ScorchGore.Sound;

namespace ScorchGore.Arena;

public class GoreArena
{
    public LevelBeschreibung CurrentLevel = new();

    public frmArena? Target { get; set; }

    internal Sprite Player1 = new SpritePlayer(Brushes.YellowGreen);
    internal Sprite Player2 = new SpritePlayer(Brushes.MistyRose);

    private Sprite DranSeiender(int player) => player == 1 ? Player1 : Player2;
    private Sprite Gegner(int player) => player == 1 ? Player1 : Player2;

    private Materials Materials => CurrentLevel.Materials;

    public void Initialize(int levelNr)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.SetupBackbuffer((int)CurrentLevel.Width, (int)CurrentLevel.Height);
        LevelZeichner.Zeichne(Target.Image, CurrentLevel, Target.BackBuffer);

        Player1.AnchorX = CurrentLevel.SpielerPosition1.X;
        Player1.AnchorY = CurrentLevel.SpielerPosition1.Y;
        Player2.AnchorX = CurrentLevel.SpielerPosition2.X;
        Player2.AnchorY = CurrentLevel.SpielerPosition2.Y;
        Player1.Emplace(Target);
        Player2.Emplace(Target);
    }

    internal Treffer Shoot(int shooter, int opponent, SequencerCommand command)
    {
        if (command.Command == SequencerCommands.FIRE_IN_THE_HOLE)
        {
            var schussEingabe = new SchussEingabe();
            var rawArgs = command.Arguments.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (rawArgs.Length >= 2 && schussEingabe.Deserialisieren($"{rawArgs[0]},{rawArgs[1]}"))
            {
                return ClassicShoot(shooter, opponent, schussEingabe);
            }
        }

        return new();
    }

    private Treffer ClassicShoot(int shooter, int opponent, SchussEingabe aim)
    {
        double x, y;

        /* schiessen wir nach rechts (spieler 1) oder nach links (spieler 2)? */
        var lW = CurrentLevel.Width;
        var lH = CurrentLevel.Height;
        var dranSeiender = DranSeiender(shooter);
        var gegner = Gegner(opponent);
        var schussRichtung = shooter == 1 ? 1 : -1;
        var v = (float)aim.SchussKraft;
        var vSkaliert = 1.0f / (v * 0.5f);
        var mathWinkel = Math.PI * (180 - aim.SchussWinkel) / 180f;
        var muendungVerlassen = 3;
        var behandeltePixel = new HashSet<long>();
        var ausgangsPunktx = dranSeiender.AnchorX;
        var ausgangsPunkty = dranSeiender.AnchorY;
        var schussErgebnis = new Treffer
        {
            GespieltesLevel = CurrentLevel.LevelNummer,
            Ergebnis = SchussErgebnis.NixGetroffen
        };

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
            switch (aim.Trajektorie)
            {
                case TrajektorienArt.SinusDaempfer:
                    var powPow = Math.Pow(t, t);
                    x = v * -t;
                    y = v * Math.Sin(powPow) / Math.Pow(2, (powPow - Math.PI / 2.0));
                    break;

                case TrajektorienArt.Kubisch:
                    var tQuadrat = t * t;
                    x = v * Math.Cos(mathWinkel) * tQuadrat;
                    y = v * Math.Sin(mathWinkel) * t - PlatformerConstants.SchwerkraftFaktor * tQuadrat * t;
                    break;

                default:
                    /* standard: resultierender vektor aus schwerkraftrichtung und mündungsrichtung, parabolisch */
                    x = v * Math.Cos(mathWinkel) * t;
                    y = v * Math.Sin(mathWinkel) * t - PlatformerConstants.SchwerkraftFaktor * t * t;
                    break;
            }

            /* schuss zeichnen */
            var pixelX = ausgangsPunktx - (int)x * schussRichtung;
            var pixelY = ausgangsPunkty - (int)y;

            if (pixelY > 0 && pixelY < lH && pixelX > 0 && pixelX < lW)
            {
                var pixelFach = ((long)pixelY << 32) + pixelX;
                if (!behandeltePixel.Contains(pixelFach))
                {
                    var hitColor = Target!.Image.GetPixel(pixelX, pixelY).ToArgb();
                    if (muendungVerlassen > 0)
                    {
                        if (hitColor != dranSeiender.PrimaryBodyColor.ToArgb())
                        {
                            --muendungVerlassen;
                            if (muendungVerlassen == 0)
                            {
                                Audio.GeraeuschAbspielen(Geraeusche.SchussStart);
                            }
                        }
                    }
                    else
                    {
                        if (hitColor == gegner.PrimaryBodyColor.ToArgb())
                        {
                            return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.GegnerGekillt);
                        }
                        else if (hitColor != CurrentLevel.Materials.HimmelsfarbeAlsInt)
                        {
                            if (hitColor == dranSeiender.PrimaryBodyColor.ToArgb())
                            {
                                return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.SelbstErschossen);
                            }
                            else if(hitColor != Color.WhiteSmoke.ToArgb())
                            {
                                return schussErgebnis.Setzen(pixelX, pixelY, SchussErgebnis.BergGetroffen);
                            }
                        }

                        Target.Image.SetPixel(pixelX, pixelY, dranSeiender.PrimaryBodyColor);
                        behandeltePixel.Add(pixelFach);

                        Application.DoEvents();
                    }
                }
            }

            /* schuss ist links, rechts, oder unten rausgeflogen */
            if (pixelY > lH || pixelX < 0 || pixelX > lW)
            {
                break;
            }
        }

        return schussErgebnis;
    }
}
