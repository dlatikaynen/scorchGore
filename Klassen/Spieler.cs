﻿using ScorchGore.Klassen;
using System;
using System.Drawing;

namespace ScorchGore
{
    internal class Spieler : Sprite
    {
        public string Name;
        public Brush Farbe;

        public override int Breite => Main.spielerBreite;

        public override void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0)
        {
            /* das über dem spieler, wo er gefallen ist, wieder mit himmelsfarbe übermalen */
            var ueberMalenVonY = Math.Max(0, this.Y - Main.spielerBasisHoehe - fallProFrame);
            zeichenFlaeche.FillRectangle(
                Farbverwaltung.Himmelsbuerste,
                this.X - this.HalbeBreite,
                ueberMalenVonY,
                this.Breite,
                this.Y - ueberMalenVonY + 1
            );

            /* den spieler selbst neu zeichnen: ein gefüllter halbkreis mit rundung oben */
            zeichenFlaeche.FillPie(
                this.Farbe,
                this.X - this.HalbeBreite,
                this.Y - Main.spielerBasisHoehe + 1,
                this.Breite,
                2 * Main.spielerBasisHoehe,
                0f,
                -180f
            );
        }
    }
}