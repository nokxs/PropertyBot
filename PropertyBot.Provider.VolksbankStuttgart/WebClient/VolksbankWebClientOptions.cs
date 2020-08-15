using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClientOptions
    {
        internal VolksbankWebClientOptions(IEnumerable<string> geoSlses, IEnumerable<int> geoSlRadiusSearch, int limit, IEnumerable<int> customerIds, int objectCategory)
        {
            GeoSls = geoSlses;
            GeoSlRadiusSearch = geoSlRadiusSearch;
            Limit = limit;
            CustomerIds = customerIds;
            ObjectCategory = objectCategory;
        }

        public IEnumerable<string> GeoSls { get; }

        public IEnumerable<int> GeoSlRadiusSearch { get; }
        
        public int Limit { get; }

        public IEnumerable<int> CustomerIds { get; }

        public int ObjectCategory { get; }
    }
}
