using ScorchGore.Aufzaehlungen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal static class LevelZeichner
    {
        public static void Zeichne(Control woBinIch, Bitmap levelBild, LevelBeschreibung levelBeschreibung, Graphics zeichenFlaeche)
        {
            var verfuegbareBergHoehe = woBinIch.Height - Main.obererRand;
            for (
                var obenUnten = ObenUnten.BergTeil;
                obenUnten <= (levelBeschreibung.IstHoehle ? ObenUnten.HoehlenTeil : ObenUnten.BergTeil);
                ++obenUnten
            )
            {
                var minimumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.MinHoeheProzent(obenUnten)) / 100M);
                var maximumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.MaxHoeheProzent(obenUnten)) / 100M);
                var steilHeit = Convert.ToInt32(5 + levelBeschreibung.RauhheitProzent(obenUnten));
                var rauhHeit = 10M - Convert.ToDecimal(levelBeschreibung.RauhheitProzent(obenUnten) / 20M);
                var zufallsZahl = new Random(levelBeschreibung.BergZufallszahl);
                var maximumHoehenunterschied = maximumHoehe - minimumHoehe;
                var aktuelleHoehe = Convert.ToDecimal(minimumHoehe + zufallsZahl.Next(maximumHoehenunterschied));
                var aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
                var aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
                var unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
                var zeichenAbschnitt = zeichenFlaeche.BeginContainer();
                if (obenUnten == ObenUnten.BergTeil)
                {
                    /* den himmel zeichnen wir nur beim ersten mal */
                    zeichenFlaeche.FillRectangle(Farbverwaltung.Himmelsbuerste, zeichenFlaeche.ClipBounds);
                }
                else
                {
                    LevelZeichner.ObenWirdUnten(woBinIch, zeichenFlaeche);
                }

                if (levelBeschreibung.IstBerg || levelBeschreibung.IstHoehle)
                {
                    Plateau binInPlateau = null;
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

                        zeichenFlaeche.FillRectangle(Farbverwaltung.Bergbuerste, bergX, (float)woBinIch.Height - pixelHoehe, 2f, (float)woBinIch.Height);

                        /* zacken in den berg/in die stalaktitten machen */
                        if (--unveraenderteSteigung <= 0)
                        {
                            woBinIch.Refresh();
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
                LevelZeichner.ObenWirdUnten(woBinIch, zeichenFlaeche);
                zeichenFlaeche.ScaleTransform(2f, 2f);
                zeichenFlaeche.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                zeichenFlaeche.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                zeichenFlaeche.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                foreach (var architekturPfad in levelBeschreibung.BeschreibungsSkript.Pfade)
                {
                    switch (architekturPfad.zeichnungBefehl)
                    {
                        case ZeichnungsBefehl.Bogen:
                        case ZeichnungsBefehl.Ellipse:
                        case ZeichnungsBefehl.Gummiband:
                        case ZeichnungsBefehl.Kurve:

                            break;

                        default:
                            var grafikPfad = architekturPfad.AlsGrafikPfad(
                                woBinIch.ClientSize.Width / 2,
                                woBinIch.ClientSize.Height / 2
                            );

                            if (architekturPfad.IstPunkt)
                            {
                                zeichenFlaeche.DrawLine(
                                    Farbverwaltung.StiftVonMedium(architekturPfad.terrainMaterial),
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
                                            Farbverwaltung.BuersteVonMedium(architekturPfad.terrainMaterial),
                                            grafikPfad.PathPoints[0].X,
                                            grafikPfad.PathPoints[0].Y,
                                            Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
                                            Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
                                        );
                                    }

                                    zeichenFlaeche.DrawRectangle(
                                        Farbverwaltung.StiftVonMedium(architekturPfad.terrainMaterial),
                                        grafikPfad.PathPoints[0].X,
                                        grafikPfad.PathPoints[0].Y,
                                        Math.Abs(grafikPfad.PathPoints[1].X - grafikPfad.PathPoints[0].X) + 1,
                                        Math.Abs(grafikPfad.PathPoints[1].Y - grafikPfad.PathPoints[0].Y) + 1
                                    );
                                }
                                else
                                {
                                    zeichenFlaeche.DrawLine(
                                        Farbverwaltung.StiftVonMedium(architekturPfad.terrainMaterial),
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
                                        Farbverwaltung.BuersteVonMedium(architekturPfad.terrainMaterial),
                                        grafikPfad
                                    );
                                }
                                else
                                {
                                    zeichenFlaeche.DrawPath(
                                        Farbverwaltung.StiftVonMedium(architekturPfad.terrainMaterial),
                                        grafikPfad
                                    );
                                }
                            }

                            break;
                    }
                }

                zeichenFlaeche.EndContainer(zeichenAbschnitt);
            }
        }

        private static void ObenWirdUnten(Control woBinIch, Graphics zeichenFlaeche)
        {
            /* unterscheidung oben und unten machen wir durch koordinatentransformation,
             * das ist bequemer als alles umdrehen */
            zeichenFlaeche.ScaleTransform(1f, -1f);
            zeichenFlaeche.TranslateTransform(0f, -(float)woBinIch.Height);
        }
    }
}
