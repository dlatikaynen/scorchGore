namespace ScorchGore.Aufzaehlungen
{
    internal enum ZeichnungsBefehl
    {
        /// <summary>
        /// pfad ist default. ein punkt ist ein pfad mit nur einer koordinate. eine linie ist ein pfad mit nur zwei koordinaten.
        /// </summary>
        Pfad, 
        Bogen,
        Ellipse,
        Gummiband,
        Kurve,
        Rechteck
    }
}
