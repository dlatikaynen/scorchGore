using ScorchGore.Configuration;

namespace ScorchGore.Translation;

internal static class Translation
{
    private static readonly Dictionary<uint, Dictionary<string, string>> _translations = new()
    {
        { 1, new() {
            {"de", "Datei" },
            {"en", "File" },
            {"fi", "Tiedosto" },
            {"ua", "Файл" }
        } },
        { 2, new()
        {
            { "de", "Shareware-Ausgabe" },
            { "en", "Shareware Edition" },
            { "fi", "Shareware painos" },
            { "ua", "шервер версія" }
        } },
        { 3, new()
        {
            { "de", "s·c·o·r·c·h·↑·g·o·r·e" },
            { "en", "s·c·o·r·c·h·↑·g·o·r·e" },
            { "fi", "s·c·o·r·c·h·↑·g·o·r·e" },
            { "ua", "s·c·o·r·c·h·↑·g·o·r·e" }
        } },
        { 4, new()
        {
            { "de", "Blaue Berge" },
            { "en", "Blue Mountains" },
            { "fi", "Siniset vuoret" },
            { "ua", "Сині гори" }
        } },
        { 5, new()
        {
            { "de", "Still und starr" },
            { "en", "Stealth and Silence" },
            { "fi", "Hiljaisuus²" },
            { "ua", "Zatychlo pid snihom" }
        } },
        { 6, new()
        {
            { "de", "Fallschirmjäger" },
            { "en", "Paratrouper" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 7, new()
        {
            { "de", "Zeitlos" },
            { "en", "Only Time" },
            { "fi", "TODO:" },
            { "ua", "Dzvonyat' dzvony" }
        } },
        { 8, new()
        {
            { "de", "Gift" },
            { "en", "Deadly Nightshade" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 9, new()
        {
            { "de", "Eigenes und Fremdes" },
            { "en", "Usses and Thems" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 10, new()
        {
            { "de", "Mittelgroße Alpträume" },
            { "en", "Mid-size Nightmares" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 11, new()
        {
            { "de", "Staffel 1: Wrath of the Mild" },
            { "en", "Instalment 1: Wrath of the Mild" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 12, new()
        {
            { "de", "Meine Level" },
            { "en", "My levels" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 13, new()
        {
            { "de", "Meine Mission" },
            { "en", "My mission" },
            { "fi", "TODO:" },
            { "ua", "TODO:" }
        } },
        { 14, new()
        {
            { "de", "Horror vacui" },
            { "en", "Horror vacui" },
            { "fi", "Horror vacui" },
            { "ua", "TODO:" }
        } }
    };
  
    internal static string µ(uint µ)
    {
        if (_translations.TryGetValue(µ, out var entry))
        {
            if (entry.TryGetValue(InstanceSettings.Language, out var literal))
            {
                return literal;
            }
        }

        return $"µ{µ}";
    }
}
