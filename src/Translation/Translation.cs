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
