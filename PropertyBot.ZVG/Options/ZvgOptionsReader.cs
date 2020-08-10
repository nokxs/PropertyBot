using PropertyBot.Common;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG.Options
{
    internal class ZvgOptionsReader : IZvgOptionsReader
    {
        public ZvgWebClientOptions GetWebClientOptions()
        {
            var stateId = EnvironmentConstants.PROVIDER_ZVG_STATE_ID.GetAsOptionalEnvironmentVariable("4"); // default is "Baden-Württemberg"
            var courtIds = EnvironmentConstants.PROVIDER_ZVG_COURT_IDS.GetAsOptionalEnvironmentVariable("49"); // default is "Stuttgart"
            var objectKindIds = EnvironmentConstants.PROVIDER_ZVG_OBJECT_KIND_ID.GetAsOptionalEnvironmentVariable("4"); // default is "Einfamilienhaus"

            return new ZvgWebClientOptions(stateId, courtIds, objectKindIds);
        }
    }
}
