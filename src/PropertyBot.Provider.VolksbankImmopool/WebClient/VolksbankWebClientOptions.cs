using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankImmopool.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public IEnumerable<string> GeoSl { get; set; }

        public IEnumerable<int> radiusInKm { get; set; }

        public int Limit { get; set; }

        public IEnumerable<int> CustomerId { get; set; }

        public int ObjectCategory { get; set; }
    }
}
