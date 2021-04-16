﻿using ScorchGore.Zeug;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ScorchGore.Klassen
{
    internal class LevelBeschreibungsSkript
    {
        private const string kommentarPrefix = @"//";

        public List<LevelArchitekturPfad> Pfade { get; protected set; }

        public LevelBeschreibungsSkript()
        {
            this.Pfade = new List<LevelArchitekturPfad>();
        }

        internal static LevelBeschreibungsSkript Laden(LevelBeschreibung levelBeschreibung)
        {
            var levelSkript = new LevelBeschreibungsSkript();
            levelSkript.LevelDateiLaden(levelBeschreibung.LevelNummer);

            return levelSkript;
        }

        private void LevelDateiLaden(int levelNummer)
        {
            var levelDateiName = this.GetLevelDateiname(levelNummer);
            if (levelDateiName != null)
            {
                using (var levelDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    typeof(RessourcenKlasse),
                    $@"Levels.{ levelDateiName }"
                ))
                {
                    using (var levelReader = new StreamReader(levelDatei))
                    {
                        string levelZeile;
                        while(!string.IsNullOrEmpty((levelZeile = levelReader.ReadLine())))
                        {
                            if (!levelZeile.Trim().StartsWith(kommentarPrefix))
                            {
                                this.Pfade.Add(LevelArchitekturPfad.AusLevelDatei(levelZeile));
                            }
                        }
                    }
                }
            }
        }

        private string GetLevelDateiname(int levelNummer) => $@"Level{ levelNummer.ToString().PadLeft(3, '0') }.dat";

        internal class LevelArchitekturPfad
        {
            protected internal readonly List<Point> promilleKoordinaten;

            public LevelArchitekturPfad() => this.promilleKoordinaten = new List<Point>();

            public GraphicsPath AlsGrafikPfad()
            {
                var grafikPfad = new GraphicsPath();
                if (this.promilleKoordinaten.Any())
                {
                    grafikPfad.AddLines(this.promilleKoordinaten.ToArray());
                }

                grafikPfad.CloseAllFigures();
                return grafikPfad;
            }

            internal static LevelArchitekturPfad AusLevelDatei(string levelZeile)
            {
                var architekturPfad = new LevelArchitekturPfad();
                var geleseneKoordinaten = levelZeile.Split(';').Select(koordinatenPaar =>
                {
                    var koordinatenTeile = koordinatenPaar.Split(',');
                    return new Point(int.Parse(koordinatenTeile[0]), int.Parse(koordinatenTeile[1]));
                });

                architekturPfad.promilleKoordinaten.AddRange(geleseneKoordinaten);
                return architekturPfad;
            }
        }
    }
}