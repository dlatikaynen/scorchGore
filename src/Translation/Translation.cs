using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Resources;
using System.Reflection;

namespace ScorchGore.Translation;

internal static class Translation
{
    private static readonly Dictionary<uint, Dictionary<string, string>> _translations = [];  
    
    internal static string µ(uint µ)
    {
        if(_translations.Count == 0)
        {
            using var literalStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                typeof(ResourceProxy),
                InfrastructureConstants.LiteralsFilename
            )!;

            using var literalReader = new StreamReader(literalStream);
            var lineNr = 0;

            while (!literalReader.EndOfStream)
            {
                var line = literalReader.ReadLine();

                ++lineNr;
                if (line == null || line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var parts = line.Split('\t');

                if (parts.Length != 3)
                {
                    throw new InvalidDataException($"No trinity in line {lineNr}");
                }

                var lcid = parts[1].Trim().ToLowerInvariant();

                if (!((string[])["de", "en", "fi", "ua"]).Contains(lcid))
                {
                    throw new InvalidDataException($"Unknown language \"{lcid}\" in line {lineNr}");
                }

                if (string.IsNullOrWhiteSpace(parts[2]))
                {
                    throw new InvalidDataException($"Empty \"{lcid}\" in line {lineNr}");
                }

                if (uint.TryParse(parts[0], out var id))
                {
                    if (lcid == "de")
                    {
                        _translations.Add(id, []);
                    }

                    _translations[id].Add(lcid, parts[2].Trim());
                }
                else
                {
                    throw new InvalidDataException($"\"{parts[0]}\" is not a number in line {lineNr}");
                }
            }
        }

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
