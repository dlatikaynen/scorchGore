namespace ScorchGore.Aufzaehlungen
{
    internal enum ZeichnungsBefehl
    {
        /// <summary>
        /// pfad ist default.
        /// ein punkt ist ein pfad mit nur einer koordinate.
        /// eine linie ist ein pfad mit nur zwei koordinaten.
        /// ein rechteck ist ein pfad mit nur zwei koordinaten und B suffix.
        /// ein gefülltes rechteck ist ein pfad mit nur zwei koordinaten und F suffix.
        /// ein kreis ist ein ei mit quadratischer umschreibung.
        /// </summary>
        Pfad, 
        Bogen,
        Ei,
        Gummiband,
        Kurva
    }
}
