using System.Collections.Generic;

namespace PropertyBot.Provider.Wunschimmo.WebClient
{
    internal class WunschimmoWebClientOptions
    {
        internal WunschimmoWebClientOptions(string region, int perimeterInKm, string objectType)
        {
            Region = region;
            PerimeterInKm = perimeterInKm;
            ObjectType = objectType;
        }

        public string Region { get; set; }

        public int PerimeterInKm { get; set; }

        public string ObjectType { get; set; }
    }
}
