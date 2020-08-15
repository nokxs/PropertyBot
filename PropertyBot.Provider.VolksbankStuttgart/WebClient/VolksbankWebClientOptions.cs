using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClientOptions
    {
        internal VolksbankWebClientOptions(IEnumerable<string> geoSlses, int geoSlRadiusSearch, int limit, long customerId, int objectCategory)
        {
            GeoSls = geoSlses;
            GeoSlRadiusSearch = geoSlRadiusSearch;
            Limit = limit;
            CustomerId = customerId;
            ObjectCategory = objectCategory;
        }

        public IEnumerable<string> GeoSls { get; }

        public int GeoSlRadiusSearch { get; }
        
        public int Limit { get; }

        public long CustomerId { get; }

        public int ObjectCategory { get; }
    }
}
