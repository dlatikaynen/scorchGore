namespace ScorchGore.Constants;

internal class GameLogicConstants
{
    internal const int SpielerBreite = 30;
    internal const int SpielerBasisHoehe = 15;
    internal const int ObererRand = 15;
    internal const int MaxOomph = 269;
}

public enum SSP
{
    None,
    Stone,
    Scissors,
    Paper,
    Well
}

public enum GameState
{
    Unknown,
    GameEngine,
    MyTurn,
    OpponentsTurn
}

public enum ZeichnungsBefehl
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

internal enum Waffengattung
{
    Pixelkanone
}

internal enum TrajektorienArt
{
    Parabolisch,
    Kubisch,
    Spiralenfoermig,
    Kreisfoermig,
    Brachistochron,
    SinusDaempfer, // y = |Sin(x^x)/2^(x^x-pi/2)/pi|
    Schwarm
}

internal enum SpielPhase
{
    StartBildschirm,
    WeltErzeugen,
    AufMitspielerWarten,
    WeltWirdErzeugt,
    SpielerFallenRundeBeginnt,
    Schusseingabe,
    SpielrundeAktiv,
    AufOnlineSchussWarten
}

public enum SchussErgebnis
{
    NichtGeschossen = 0,
    NixGetroffen = 1,
    BergGetroffen = 2,
    GegnerGekillt = 3,
    SelbstErschossen = 4
}

public enum ObenUnten
{
    BergTeil,
    HoehlenTeil
}

public enum Medium
{
    Berg,
    Himmel,
    Erde,
    Gras,
    Wasser,
    Eis,
    Schnee,
    Lava,
    Sand,
    Stahl
}

internal enum GoodieWirkung
{
    Sauerstoff_Leben,
    GanzesHerz,
    HalbesHerz,
    RechtsHerz,
    Hohlesherz,
    Chrom_Dreifachschuss
}
