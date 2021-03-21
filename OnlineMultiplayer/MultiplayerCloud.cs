using ScorchGore.Aufzaehlungen;
using ScorchGore.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScorchGore.OnlineMultiplayer
{
    internal class MultiplayerCloud
    {
        private const string cloudBaseUrl = "https://scorchgore.azurewebsites.net/api/MitspielerFinden?code=eFNAC9zQeVCnpJ7WaDtoG5aWfMR2plCtKl3saUninKMJ/cOsj/fPNA==";

        private Guid ownPlayerID;
        private Guid joinedSessionID;

        public MultiplayerCloud()
        {
            this.ownPlayerID = Guid.NewGuid();
            this.joinedSessionID = Guid.Empty;
            this.BergZufallszahl = (int)(DateTime.Now.Ticks % (long)int.MaxValue);
            this.IsOnlineGame = false;
        }

        internal int BergZufallszahl { get; set; }
        internal bool IsOnlineGame { get; private set; }

        internal async Task<LevelBeschreibung> MitspielerFinden(LevelBeschreibung meineLevelBeschreibung)
        {
            /* reihenfolge der levelbecshreibungs-werte und rückgabewerte:
             * siehe MitspielerFinden.csx cloud function skript */
            var levelParameter = $@"{ meineLevelBeschreibung.BergZufallszahl },{ meineLevelBeschreibung.BergMinHoeheProzent },{ meineLevelBeschreibung.BergMaxHoeheProzent },{ meineLevelBeschreibung.BergRauhheitProzent }";
            var findenAntwort = await this.RoundTrip(
                "HELO",
                new Tuple<string, string>("u", this.ownPlayerID.ToString("N").ToLowerInvariant()),
                new Tuple<string, string>("lp", levelParameter)
            );

            switch(findenAntwort.ToLowerInvariant())
            {
                case "heloed":
                    meineLevelBeschreibung.MitspielerStatus = MitspielerFindenStatus.HeloGesagt;
                    break;

                case "waiting":
                    meineLevelBeschreibung.MitspielerStatus = MitspielerFindenStatus.Wartend;
                    break;
                    
                case "allured":
                    meineLevelBeschreibung.MitspielerStatus = MitspielerFindenStatus.AndererNimmtBeiMirTeil;
                    break;
            }

            if(findenAntwort.StartsWith("joined,"))
            {
                /* in dem fall müssen wir die berg-erzeugungswerte vom anderen übernehmen,
                 * damit unsere level gleich ausschauen */
                var bestandTeile = findenAntwort.Split(',');
                meineLevelBeschreibung.MitspielerStatus = MitspielerFindenStatus.IchNehmeBeiAnderemTeil;
                this.joinedSessionID = Guid.Parse(bestandTeile[1]);
                meineLevelBeschreibung.BergZufallszahl = int.Parse(bestandTeile[2]);
                meineLevelBeschreibung.BergMinHoeheProzent = int.Parse(bestandTeile[3]);
                meineLevelBeschreibung.BergMaxHoeheProzent = int.Parse(bestandTeile[4]);
                meineLevelBeschreibung.BergRauhheitProzent = int.Parse(bestandTeile[5]);
            }

            this.IsOnlineGame = meineLevelBeschreibung.MitspielerStatus == MitspielerFindenStatus.AndererNimmtBeiMirTeil || meineLevelBeschreibung.MitspielerStatus == MitspielerFindenStatus.IchNehmeBeiAnderemTeil;

            return meineLevelBeschreibung;
        }

        private async Task<string> RoundTrip(string verb, params Tuple<string,string>[] parameters)
        {
            var parameterString = string.Empty;
            foreach(var parameter in parameters)
            {
                parameterString = $@"{ parameterString }&{ parameter.Item1 }={ parameter.Item2 }";
            }

            return await new WebClient().DownloadStringTaskAsync($@"{ MultiplayerCloud.cloudBaseUrl }&v={ verb }{ parameterString }");
        }

    }
}
