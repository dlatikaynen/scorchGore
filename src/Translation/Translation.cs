using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Resources;
using System.Reflection;

namespace ScorchGore.Translation;

internal static class Translation
{
    private static readonly Dictionary<uint, Dictionary<string, string>> _translations = [];
    private static readonly object TranslationChangedEventRoot = new();

    public delegate void TranslationChangedEventHandler(object sender, TranslationChangedEventArgs e);

    public class TranslationChangedEventArgs : EventArgs { }

    internal static event TranslationChangedEventHandler? TranslationChanged;

    internal static void OnTranslationChanged(TranslationChangedEventArgs e)
    {
        TranslationChanged?.Invoke(TranslationChangedEventRoot, e);
    }

    internal static string µ(uint µ, params string[] args)
    {
        return GetSpecificTranslation(InstanceSettings.Language, µ, args);
    }

    internal static string GetSpecificTranslation(string lcid, uint µ, params string[] args)
    {
        EnsureTranslationsLoaded();

        if (_translations.TryGetValue(µ, out var entry))
        {
            if (entry.TryGetValue(lcid, out var literal))
            {
                if (args.Length == 0)
                {
                    return literal;
                }
                else
                {
                    return string.Format(literal, args);
                }
            }
        }

        return $"µ{µ}";
    }

    private static void EnsureTranslationsLoaded()
    {
        if (_translations.Count == 0)
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
                if (line == null || line.StartsWith('#') || string.IsNullOrWhiteSpace(line))
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
    }

    internal static void RegisterForTranslation(TranslationChangedEventHandler translate)
    {
        // call once for initial translation
        translate(TranslationChangedEventRoot, new());

        // register to be called back whenever the language setting changes
        TranslationChanged += translate;
    }

    public class Dynaµte(uint literal, Action<string> setter, string[]? args = null)
    {
        private uint µ => literal;
        private string[]? Arguments => args;

        public void Update()
        {
            if (args?.Length > 0)
            {
                setter(Translation.µ(µ, args));
            }
            else
            {
                setter(Translation.µ(µ));
            }
        }
    }

    public static void TranslateTreeview(TreeView treeView, TreeNode? node = null)
    {
        if (node == null)
        {
            foreach (TreeNode rootNode in treeView.Nodes)
            {
                TranslateTreeview(treeView, rootNode);
            }
        }
        else
        {
            if (node.Tag is Dynaµte dyn)
            {
                dyn.Update();
            }

            foreach (TreeNode cnode in node.Nodes)
            {
                TranslateTreeview(treeView, cnode);
            }
        }
    }
}
