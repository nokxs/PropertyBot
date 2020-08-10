using System;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG.Options
{
    internal class ZvgOptionsReader : IZvgOptionsReader
    {
        public ZvgWebClientOptions GetWebClientOptions()
        {
            //https://www.zvg.com/appl/termine.prg?act=getGridData&vt=&id_b=4&ids=159,114,49,86,105,&ido=35,4,5,49,&sort=a

            var stateId = Environment.GetEnvironmentVariable("PROVIDER_ZVG_STATE_ID");
            var courtIds = Environment.GetEnvironmentVariable("PROVIDER_ZVG_COURT_IDS");
            var objectKindIds = Environment.GetEnvironmentVariable("PROVIDER_ZVG_OBJECT_KIND_ID");

            stateId = "4";
            courtIds = "35,4,5,49";
            objectKindIds = "159,114,49,86,105";

            return new ZvgWebClientOptions(stateId, courtIds, objectKindIds);
        }
    }
}
