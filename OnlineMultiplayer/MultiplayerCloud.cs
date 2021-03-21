using ScorchGore.Aufzaehlungen;
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
        }

        internal async Task<MitspielerFindenStatus> MitspielerFinden()
        {
            var findenAntwort = await this.RoundTrip(
                "HELO",
                new Tuple<string, string>("u", this.ownPlayerID.ToString("N").ToLowerInvariant())
            );

            // siehe MitspielerFinden.csx cloud function script
            switch(findenAntwort.ToLowerInvariant())
            {
                case "heloed":
                    return MitspielerFindenStatus.HeloGesagt;

                case "waiting":
                    return MitspielerFindenStatus.Wartend;

                case "joined":
                    return MitspielerFindenStatus.AndererNimmtBeiMirTeil;
            }

            if(findenAntwort.StartsWith("joined,"))
            {
                this.joinedSessionID = Guid.Parse(findenAntwort.Split(',')[1]);
                return MitspielerFindenStatus.IchNehmeBeiAnderemTeil;
            }

            return MitspielerFindenStatus.Wartend;
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
