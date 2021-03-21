using ScorchGore.Aufzaehlungen;

namespace ScorchGore.Klassen
{
    internal class LevelBeschreibung
    {
        public MitspielerFindenStatus MitspielerStatus { get; set; }
        public int BergZufallszahl { get; set; }
        public int BergMinHoeheProzent { get; set; }
        public int BergMaxHoeheProzent { get; set; }
        public int BergRauhheitProzent { get; set; }
    }
}
