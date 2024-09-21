using ScorchGore.Resources;
using System.Collections.Concurrent;
using System.Media;
using System.Reflection;

namespace ScorchGore.Sound;

internal static class Audio
{
    private static readonly ConcurrentDictionary<Geraeusche, Stream> geraeuschKatalog = new();
    private static readonly SoundPlayer soundPlayer = new();

    public static void AlleAudiosVorbereiten()
    {
        Task.Run(() =>
        {
            foreach (Geraeusche welchesAudio in Enum.GetValues(typeof(Geraeusche)))
            {
                AudioDateiVorladen(welchesAudio);
            }
        });
    }

    public static void GeraeuschAbspielen(Geraeusche welchesGeraeusch)
    {
        Task.Run(() =>
        {
            AudioDateiVorladen(welchesGeraeusch);
            if (geraeuschKatalog.TryGetValue(welchesGeraeusch, out Stream? audioDatei) && audioDatei != null)
            {
                audioDatei.Seek(0L, SeekOrigin.Begin);
                lock (soundPlayer)
                {
                    soundPlayer.Stream = audioDatei;
                    soundPlayer.Play();
                }
            }
        });
    }

    private static void AudioDateiVorladen(Geraeusche welchesGeraeusch)
    {
        if (!geraeuschKatalog.ContainsKey(welchesGeraeusch))
        {
            var audioDateiName = GetAudioDateiName(welchesGeraeusch);

            if (audioDateiName != null)
            {
                var geraeuschDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    typeof(ResourceProxy),
                    audioDateiName
                );

                if (geraeuschDatei != null)
                {
                    geraeuschKatalog.TryAdd(welchesGeraeusch, geraeuschDatei);
                }
            }
        }
    }

    private static string? GetAudioDateiName(Geraeusche welcheDatei)
    {
        switch (welcheDatei)
        {
            case Geraeusche.SchussStart:
                return "projectile-fired.wav";

            case Geraeusche.SchussEinschlag:
                return "decay-crumble.wav";
        }

        return null;
    }
}
