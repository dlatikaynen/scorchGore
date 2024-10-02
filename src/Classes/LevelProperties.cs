using System.ComponentModel;

namespace ScorchGore.Classes;

internal class LevelProperties
{
    [Category("Naming")]
    [Description("The English translation of the level's name")]
    public string NameEn { get; set; } = string.Empty;

    [Category("Naming")]
    [Description("The German translation of the level's name")]
    public string NameDe { get; set; } = string.Empty;

    [Category("Naming")]
    [Description("The Finnish translation of the level's name")]
    public string NameFi { get; set; } = string.Empty;

    [Category("Naming")]
    [Description("The Ukrainian translation of the level's name")]
    public string NameUa { get; set; } = string.Empty;

    [Category("Basics")]
    [Description("The width of the level canvas' rectangular bounding box")]
    public uint Width { get; set; } = 640;

    [Category("Basics")]
    [Description("The height of the level canvas' rectangular bounding box")]
    public uint Height { get; set; } = 480;

    [Category("Basics")]
    [Description("Randomizer seed for procedural terrain generators")]
    public uint BergZufallszahl { get; set; } = 58008;

    [Category("Basics")]
    [Description("Activate to generate a mountain range")]
    public bool IsMountain { get; set; } = false;

    [Category("Basics")]
    [Description("Minimum mountain range height in percent of available height")]
    public uint BergMinHoeheProzent { get; set; } = 10;

    [Category("Basics")]
    [Description("Maximum mountain range height in percent of available height")]
    public uint BergMaxHoeheProzent { get; set; } = 39;

    [Category("Basics")]
    [Description("Mountain range ruggedness factor as a percentage of something I don't remember")]
    public uint BergRauhheitProzent { get; set; } = 19;

    [Category("Basics")]
    [Description("Activate to generate a cave roof")]
    public bool IsCave { get; set; } = false;

    [Category("Basics")]
    [Description("Cave roof minimum height measured from the top, in percent of available height")]
    public uint HoehleMinHoeheProzent { get; set; } = 13;

    [Category("Basics")]
    [Description("Cave roof maximum height measured from the top, in percent of available height")]
    public uint HoehleMaxHoeheProzent { get; set; } = 48;

    [Category("Basics")]
    [Description("Cave roof ruggedness factor as a percentage of something I don't remember")]
    public uint HoehleRauhheitProzent { get; set; } = 50;

    [Category("Colors")]
    [Description("Define the color of the mountain range")]
    public Color ColorMountain { get; set; } = Color.Empty;

    [Category("Colors")]
    [Description("Define the color of the cave roof")]
    public Color ColorCave { get; set; } = Color.Empty;
}
