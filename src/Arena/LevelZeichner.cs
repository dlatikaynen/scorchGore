﻿using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Drawing.Drawing2D;

namespace ScorchGore.Arena;

internal static class LevelZeichner
{
    public static void Zeichne(Bitmap woBinIch, LevelBeschreibung levelBeschreibung, Graphics zeichenFlaeche)
    {
        var verfuegbareBergHoehe = levelBeschreibung.Height - GameLogicConstants.ObererRand;

        for (
            var obenUnten = ObenUnten.BergTeil;
            obenUnten <= (levelBeschreibung.IsCave ? ObenUnten.HoehlenTeil : ObenUnten.BergTeil);
            ++obenUnten
        )
        {
            var minimumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.MinHoeheProzent(obenUnten)) / 100M);
            var maximumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.MaxHoeheProzent(obenUnten)) / 100M);
            var steilHeit = Convert.ToInt32(5 + levelBeschreibung.RauhheitProzent(obenUnten));
            var rauhHeit = 10M - Convert.ToDecimal(levelBeschreibung.RauhheitProzent(obenUnten) / 20M);
            var zufallsZahl = new Random((int)levelBeschreibung.BergZufallszahl);
            var maximumHoehenunterschied = maximumHoehe - minimumHoehe;
            var aktuelleHoehe = Convert.ToDecimal(minimumHoehe + zufallsZahl.Next(maximumHoehenunterschied));
            var aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
            var aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
            var unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
            var zeichenAbschnitt = zeichenFlaeche.BeginContainer();
            if (obenUnten == ObenUnten.BergTeil)
            {
                /* den himmel zeichnen wir nur beim ersten mal */
                if(string.IsNullOrEmpty(levelBeschreibung.BackdropAssetKey) && !levelBeschreibung.ColorBackground.IsEmpty)
                {
                    var backBrush = levelBeschreibung.Materials.BuersteVonMedium(Medium.Himmel);

                    zeichenFlaeche.FillRectangle(backBrush, zeichenFlaeche.ClipBounds);
                }
            }
            else
            {
                ObenWirdUnten(woBinIch, zeichenFlaeche);
            }

            if (levelBeschreibung.IsMountain || levelBeschreibung.IsCave)
            {
                Plateau? binInPlateau = null;
                for (var bergX = 0; bergX < woBinIch.Width; bergX += 2)
                {
                    /* berg/stalaktitten höhenänderung berechnen */
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

                    /* berg/stalaktitten zeichnen */
                    var pixelHoehe = minimumHoehe + Convert.ToInt32(aktuelleHoehe);
                    if (binInPlateau == null)
                    {
                        if (levelBeschreibung.Plateaus.ContainsKey(bergX))
                        {
                            binInPlateau = levelBeschreibung.Plateaus[bergX];
                        }
                    }

                    if (binInPlateau != null)
                    {
                        if (binInPlateau.EndetX < bergX)
                        {
                            binInPlateau = null;
                        }
                        else
                        {
                            pixelHoehe = binInPlateau.Elevation;
                        }
                    }

                    zeichenFlaeche.FillRectangle(levelBeschreibung.Materials.Bergbuerste, bergX, (float)woBinIch.Height - pixelHoehe, 2f, (float)woBinIch.Height);

                    /* zacken in den berg/in die stalaktitten machen */
                    if (--unveraenderteSteigung <= 0)
                    {
                        aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
                        aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
                        unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
                    }
                }
            }

            zeichenFlaeche.EndContainer(zeichenAbschnitt);
        }

        if (levelBeschreibung.IstGeskriptet)
        {
            var zeichenAbschnitt = zeichenFlaeche.BeginContainer();
            ObenWirdUnten(woBinIch, zeichenFlaeche);
            zeichenFlaeche.ScaleTransform(2f, 2f);
            zeichenFlaeche.SmoothingMode = SmoothingMode.None;
            zeichenFlaeche.InterpolationMode = InterpolationMode.NearestNeighbor;
            zeichenFlaeche.PixelOffsetMode = PixelOffsetMode.Half;
            foreach (var architekturPfad in levelBeschreibung.BeschreibungsSkript.Pfade)
            {
                if (architekturPfad.terrainMaterial == Medium.Gras)
                {
                    /* gras kann immer nur linien folgen */
                    ZeichneGras(woBinIch, zeichenFlaeche, architekturPfad);
                }
                else
                {
                    switch (architekturPfad.zeichnungBefehl)
                    {
                        case ZeichnungsBefehl.Bogen:
                            break;

                        case ZeichnungsBefehl.Gummiband:
                            ZeichneGummiband(woBinIch, zeichenFlaeche, architekturPfad);
                            break;

                        case ZeichnungsBefehl.Kurva:
                            break;

                        case ZeichnungsBefehl.Ei:
                            ZeichneEi(woBinIch, zeichenFlaeche, architekturPfad);
                            break;

                        default:
                            ZeichnePfad(woBinIch, zeichenFlaeche, architekturPfad);
                            break;
                    }
                }
            }

            zeichenFlaeche.EndContainer(zeichenAbschnitt);
        }
    }

    private static void ObenWirdUnten(Bitmap woBinIch, Graphics zeichenFlaeche)
    {
        /* unterscheidung oben und unten machen wir durch koordinatentransformation,
         * das ist bequemer als alles umdrehen */
        zeichenFlaeche.ScaleTransform(1f, -1f);
        zeichenFlaeche.TranslateTransform(0f, -(float)woBinIch.Height);
    }

    private static void ZeichnePfad(Bitmap woBinIch, Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad)
    {
        var grafikPfad = AlsPfad(woBinIch, architekturPfad);
        if (architekturPfad.IstPunkt)
        {
            zeichenFlaeche.DrawLine(
                architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                grafikPfad.PathPoints[0],
                grafikPfad.PathPoints[0]
            );
        }
        else if (architekturPfad.IstLinie)
        {
            if (architekturPfad.IstRechteck)
            {
                if (architekturPfad.IstGefuellt)
                {
                    zeichenFlaeche.FillRectangle(
                        architekturPfad.Materials.BuersteVonMedium(architekturPfad.terrainMaterial),
                        grafikPfad.PathPoints[0].X,
                        grafikPfad.PathPoints[0].Y,
                        Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
                        Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
                    );
                }

                zeichenFlaeche.DrawRectangle(
                    architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                    grafikPfad.PathPoints[0].X,
                    grafikPfad.PathPoints[0].Y,
                    Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
                    Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
                );
            }
            else
            {
                zeichenFlaeche.DrawLine(
                    architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                    grafikPfad.PathPoints[0],
                    grafikPfad.PathPoints[1]
                );
            }
        }
        else
        {
            if (architekturPfad.IstGefuellt)
            {
                zeichenFlaeche.FillPath(
                    architekturPfad.Materials.BuersteVonMedium(architekturPfad.terrainMaterial),
                    grafikPfad
                );
            }
            else
            {
                zeichenFlaeche.DrawPath(
                    architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                    grafikPfad
                );
            }
        }
    }

    private static void ZeichneEi(Bitmap woBinIch, Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad)
    {
        var grafikPfad = AlsPfad(woBinIch, architekturPfad);
        if (architekturPfad.IstGefuellt)
        {
            zeichenFlaeche.FillEllipse(
                architekturPfad.Materials.BuersteVonMedium(architekturPfad.terrainMaterial),
                grafikPfad.PathPoints[0].X,
                grafikPfad.PathPoints[0].Y,
                Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
                Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
            );
        }

        zeichenFlaeche.DrawEllipse(
            architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
            grafikPfad.PathPoints[0].X,
            grafikPfad.PathPoints[0].Y,
            Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
            Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
        );
    }

    private static void ZeichneGummiband(Bitmap woBinIch, Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad)
    {
        var grafikPfad = AlsPfad(woBinIch, architekturPfad);
        if (architekturPfad.IstRechteck || architekturPfad.IstGefuellt)
        {
            /* gefüllt geht nur als geschlossene kurva */
            if (architekturPfad.IstGefuellt)
            {
                zeichenFlaeche.FillClosedCurve(
                    architekturPfad.Materials.BuersteVonMedium(architekturPfad.terrainMaterial),
                    grafikPfad.PathPoints,
                    FillMode.Alternate,
                    0.62f
                );
            }

            zeichenFlaeche.DrawClosedCurve(
                architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                grafikPfad.PathPoints,
                0.62f,
                FillMode.Alternate
            );
        }
        else
        {
            zeichenFlaeche.DrawCurve(
                architekturPfad.Materials.StiftVonMedium(architekturPfad.terrainMaterial, architekturPfad.StiftDicke),
                grafikPfad.PathPoints,
                0.62f
            );
        }
    }

    private static void ZeichneGras(Bitmap woBinIch, Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad)
    {
        PointF grasPunktGenau;
        var random = new Random();
        var grafikPfad = AlsPfad(woBinIch, architekturPfad);
        if (grafikPfad.PointCount == 2)
        {
            var sodeAnfang = grafikPfad.PathPoints[0];
            var sodeEndpkt = grafikPfad.PathPoints[1];
            var letztesBlatt = PointF.Empty;
            var ueberLappung = PointF.Empty;
            var ersterDurchlauf = true;
            foreach (var grasPunkt in LinienFolger.Bresenham(
                (int)sodeAnfang.X,
                (int)sodeAnfang.Y,
                (int)sodeEndpkt.X,
                (int)sodeEndpkt.Y
            ))
            {
                grasPunktGenau = new PointF(grasPunkt.X, grasPunkt.Y);
                if (ersterDurchlauf)
                {
                    letztesBlatt = sodeAnfang;
                    ersterDurchlauf = false;
                }
                else
                {
                    RechneBlattPosition(zeichenFlaeche, architekturPfad, random, grasPunktGenau, ref letztesBlatt, ref ueberLappung);
                }
            }

            ersterDurchlauf = true;
            foreach (var grasPunkt in LinienFolger.Bresenham(
                (int)sodeEndpkt.X,
                (int)sodeEndpkt.Y,
                (int)sodeAnfang.X,
                (int)sodeAnfang.Y
            ))
            {
                grasPunktGenau = new PointF(grasPunkt.X, grasPunkt.Y);
                if (ersterDurchlauf)
                {
                    letztesBlatt = sodeEndpkt;
                    ersterDurchlauf = false;
                }
                else
                {
                    RechneBlattPosition(zeichenFlaeche, architekturPfad, random, grasPunktGenau, ref letztesBlatt, ref ueberLappung);
                }
            }

            zeichenFlaeche.DrawPath(Pens.LimeGreen, grafikPfad);
        }
    }

    private static void RechneBlattPosition(Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad, Random random, PointF grasPunktGenau, ref PointF letztesBlatt, ref PointF ueberLappung)
    {
        var abstand = Abstand(letztesBlatt, grasPunktGenau);
        if (abstand < 6)
        {
            ueberLappung = grasPunktGenau;
        }
        else if (abstand > 8)
        {
            ZeichneBlatt(
                zeichenFlaeche,
                architekturPfad,
                random,
                grasPunktGenau,
                letztesBlatt
            );

            letztesBlatt = ueberLappung;
        }
    }

    private static float Abstand(PointF von, PointF bis) => (float)Math.Sqrt(Math.Pow(bis.Y - von.Y, 2) + Math.Pow(bis.X - von.X, 2));

    private static void ZeichneBlatt(Graphics zeichenFlaeche, LevelArchitekturPfad architekturPfad, Random random, PointF anfangsPunkt, PointF endPunkt)
    {
        var mittelPunkt = new PointF(
            anfangsPunkt.X + (endPunkt.X - anfangsPunkt.X) / 2f - 2 + random.Next(4),
            anfangsPunkt.Y - 11 + random.Next(4)
        );

        var umrissPfad = new GraphicsPath();
        umrissPfad.AddLine(anfangsPunkt, endPunkt);
        umrissPfad.AddBezier(
            anfangsPunkt.X,
            anfangsPunkt.Y,
            mittelPunkt.X - 2 + random.Next(4),
            mittelPunkt.Y - 2 + random.Next(4),
            mittelPunkt.X + 2 - random.Next(4),
            mittelPunkt.Y - 2 + random.Next(4),
            endPunkt.X,
            endPunkt.Y
        );

        umrissPfad.CloseFigure();
        var grasFarbton = random.Next(4);
        var grasStift = architekturPfad.Materials.GrasStift(grasFarbton);
        var grasBuerste = architekturPfad.Materials.GrasBuerste(grasFarbton);
        zeichenFlaeche.FillPath(grasBuerste, umrissPfad);
        zeichenFlaeche.DrawPath(grasStift, umrissPfad);

        /*
        zeichenFlaeche.DrawEllipse(Pens.LightSalmon, anfangsPunkt.X - 2, anfangsPunkt.Y - 2, 4, 4);
        zeichenFlaeche.DrawEllipse(Pens.LightSalmon, mittelPunkt.X - 2, mittelPunkt.Y - 2, 4, 4);
        zeichenFlaeche.DrawEllipse(Pens.LightSalmon, endPunkt.X - 2, endPunkt.Y - 2, 4, 4);
        */
    }

    private static GraphicsPath AlsPfad(Bitmap woBinIch, LevelArchitekturPfad architekturPfad)
    {
        return architekturPfad.AlsGrafikPfad(
            woBinIch.Width / 2,
            woBinIch.Height / 2
        );
    }
}
