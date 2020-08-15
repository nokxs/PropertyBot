using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClientOptions
    {
        internal VolksbankWebClientOptions(string geoSl, int geoSlRadiusSearch, int limit, long customerId, int objectCategory)
        {
            GeoSl = geoSl;
            GeoSlRadiusSearch = geoSlRadiusSearch;
            Limit = limit;
            CustomerId = customerId;
            ObjectCategory = objectCategory;
        }

        public string GeoSl { get; }

        public int GeoSlRadiusSearch { get; }
        
        public int Limit { get; }

        public long CustomerId { get; }

        public int ObjectCategory { get; }
    }
}
