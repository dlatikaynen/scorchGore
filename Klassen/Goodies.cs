using ScorchGore.Aufzaehlungen;
using ScorchGore.Zeug;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;

namespace ScorchGore.Klassen
{
    internal class Goodies
    {
        private readonly ConcurrentDictionary<GoodieWirkung, Image> goodieKatalog = new ConcurrentDictionary<GoodieWirkung, Image>();

        public void AlleGoodiesVorbereiten()
        {
            Task.Run(() =>
            {
                foreach (GoodieWirkung welchesGoodie in Enum.GetValues(typeof(GoodieWirkung)))
                {
                    this.GoodieVorladen(welchesGoodie);
                }
            });
        }

        public Image BildHolen(GoodieWirkung welchesGoodie)
        {
            this.GoodieVorladen(welchesGoodie);
            if (this.goodieKatalog.TryGetValue(welchesGoodie, out Image goodieBild))
            {
                return goodieBild;
            }

            return new Bitmap(24, 24);
        }
        
        private void GoodieVorladen(GoodieWirkung welchesGoodie)
        {
            if (!this.goodieKatalog.ContainsKey(welchesGoodie))
            {
                var goodieDateiName = Goodies.GetGoodieDateiName(welchesGoodie);
                if (goodieDateiName != null)
                {
                    using (var goodieDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                        typeof(RessourcenKlasse),
                        $@"{ nameof(Goodies) }.{ goodieDateiName }"
                    ))
                    {
                        var goodieBild = Image.FromStream(goodieDatei);
                        this.goodieKatalog.TryAdd(welchesGoodie, goodieBild);
                    }
                }
            }
        }

        private static string GetGoodieDateiName(GoodieWirkung welchesGoodie)
        {
            switch (welchesGoodie)
            {
                case GoodieWirkung.Chrom_Dreifachschuss:
                    return "chel-cr.png";

                case GoodieWirkung.Hohlesherz:
                case GoodieWirkung.HalbesHerz:
                case GoodieWirkung.RechtsHerz:
                case GoodieWirkung.GanzesHerz:
                    return $"{ welchesGoodie.ToString().ToLowerInvariant() }.png";
            }

            return null;
        }
    }
}
