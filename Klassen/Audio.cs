using ScorchGore.Zeug;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;

namespace ScorchGore.Klassen
{
    internal class Audio
    {
        private readonly ConcurrentDictionary<Geraeusche, Stream> geraeuschKatalog = new ConcurrentDictionary<Geraeusche, Stream>();
        private readonly SoundPlayer soundPlayer = new SoundPlayer();

        public void AlleAudiosVorbereiten()
        {
            Task.Run(() =>
            {
                foreach(Geraeusche welchesAudio in Enum.GetValues(typeof(Geraeusche)))
                {
                    this.AudioDateiVorladen(welchesAudio);
                }
            });
        }

        public void GeraeuschAbspielen(Geraeusche welchesGeraeusch)
        {
            Task.Run(() =>
            {
                this.AudioDateiVorladen(welchesGeraeusch);
                if (this.geraeuschKatalog.TryGetValue(welchesGeraeusch, out Stream audioDatei))
                {
                    audioDatei.Seek(0L, SeekOrigin.Begin);
                    lock (this.soundPlayer)
                    {
                        soundPlayer.Stream = audioDatei;
                        soundPlayer.Play();
                    }
                }
            });
        }

        private void AudioDateiVorladen(Geraeusche welchesGeraeusch)
        {
            if (!this.geraeuschKatalog.ContainsKey(welchesGeraeusch))
            {
                var audioDateiName = Audio.GetAudioDateiName(welchesGeraeusch);
                var geraeuschDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(RessourcenKlasse), audioDateiName);
                this.geraeuschKatalog.TryAdd(welchesGeraeusch, geraeuschDatei);
            }
        }

        private static string GetAudioDateiName(Geraeusche welcheDatei)
        {
            switch(welcheDatei)
            {
                case Geraeusche.SchussStart:
                    return "projectile-fired.wav";

                case Geraeusche.SchussEinschlag:
                    return "decay-crumble.wav";
            }

            return null;
        }
    }
}
