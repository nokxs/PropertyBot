namespace PropertyBot.Provider.VolksbankImmopool.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public string GeoSl { get; set; }

        public int RadiusInKm { get; set; }

        public int Limit { get; set; }

        public int CustomerId { get; set; }

        public int ObjectCategory { get; set; }
    }
}
