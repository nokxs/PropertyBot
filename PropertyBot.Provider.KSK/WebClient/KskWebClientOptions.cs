namespace PropertyBot.Provider.KSK.WebClient
{
    internal class KskWebClientOptions
    {
        internal KskWebClientOptions(int zipRadiusSearch, int perimeterInKm, int limit, long regioClientId, string marketingUsageObjectType)
        {
            ZipRadiusSearch = zipRadiusSearch;
            PerimeterInKm = perimeterInKm;
            Limit = limit;
            RegioClientId = regioClientId;
            MarketingUsageObjectType = marketingUsageObjectType;
        }

        public int ZipRadiusSearch { get; }

        public int PerimeterInKm { get; }

        public int Limit { get; }

        public long RegioClientId { get; }

        public string MarketingUsageObjectType { get; }
    }
}
