using ScorchGore.Zeug;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScorchGore.Klassen
{
    internal class Audio
    {
        private ConcurrentDictionary<Geraeusche, Stream> geraeuschKatalog = new ConcurrentDictionary<Geraeusche, Stream>();
        private SoundPlayer soundPlayer = new SoundPlayer();

        public void GeraeuschAbspielen(Geraeusche welchesGeraeusch)
        {
            Task.Run(() =>
            {
                if(!this.geraeuschKatalog.ContainsKey(welchesGeraeusch))
                {
                    var audioDateiName = Audio.GetAudioDateiName(welchesGeraeusch);
                    var geraeuschDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(RessourcenKlasse), audioDateiName);
                    this.geraeuschKatalog.TryAdd(welchesGeraeusch, geraeuschDatei);
                }

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
