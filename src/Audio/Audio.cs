using ScorchGore.Resources;
using System.Collections.Concurrent;
using System.Media;
using System.Reflection;

namespace ScorchGore.Audio;

internal class Audio
{
    private readonly ConcurrentDictionary<Geraeusche, Stream> geraeuschKatalog = new();
    private readonly SoundPlayer soundPlayer = new();

    public void AlleAudiosVorbereiten()
    {
        Task.Run(() =>
        {
            foreach (Geraeusche welchesAudio in Enum.GetValues(typeof(Geraeusche)))
            {
                AudioDateiVorladen(welchesAudio);
            }
        });
    }

    public void GeraeuschAbspielen(Geraeusche welchesGeraeusch)
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

    private void AudioDateiVorladen(Geraeusche welchesGeraeusch)
    {
        if (!geraeuschKatalog.ContainsKey(welchesGeraeusch))
        {
            var audioDateiName = GetAudioDateiName(welchesGeraeusch);
            var geraeuschDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                typeof(ResourceProxy),
                $@"Geraeusche.{audioDateiName}"
            );

            if (geraeuschDatei != null)
            {
                geraeuschKatalog.TryAdd(welchesGeraeusch, geraeuschDatei);
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
