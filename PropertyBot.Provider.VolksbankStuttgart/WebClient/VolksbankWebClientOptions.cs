using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClientOptions
    {
        internal VolksbankWebClientOptions(IEnumerable<string> geoSls, int geoSlRadiusSearch, int limit, long customerId, int objectCategory)
        {
            GeoSl = geoSls;
            GeoSlRadiusSearch = geoSlRadiusSearch;
            Limit = limit;
            CustomerId = customerId;
            ObjectCategory = objectCategory;
        }

        public IEnumerable<string> GeoSl { get; }

        public int GeoSlRadiusSearch { get; }
        
        public int Limit { get; }

        public long CustomerId { get; }

        public int ObjectCategory { get; }
    }
}
