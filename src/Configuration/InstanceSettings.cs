using System.Globalization;
using System.Text;

namespace ScorchGore.Configuration;

internal static class InstanceSettings
{
    public static string Edition = "S"; // S...shareware F...full
    public static string Language = "en";
    public static string PlayerName = "";

    public static string GetSerialized()
    {
        var encodedEdition = Convert.ToBase64String(Encoding.ASCII.GetBytes(Edition));
        var encodedLanguage = Convert.ToBase64String(Encoding.ASCII.GetBytes(Language));
        var encodedPlayerName = Convert.ToBase64String(Encoding.ASCII.GetBytes(PlayerName));

        return string.Join(
            (char)6,
            encodedEdition,
            encodedLanguage,
            encodedPlayerName
        );
    }

    public static void DeserializeFrom(string raw)
    {
        var parts = raw.Split((char)6);

        if (parts.Length == 3)
        {
            Edition = Encoding.ASCII.GetString(Convert.FromBase64String(parts[0]));
            Language = Encoding.ASCII.GetString(Convert.FromBase64String(parts[1]));
            PlayerName = Encoding.ASCII.GetString(Convert.FromBase64String(parts[2]));
        }
    }

    public static void InitializeFromEnvironment()
    {
        Language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
    }
}
