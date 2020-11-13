namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal record ImmoscoutWebClientOptions
    {
        public string Type { get; set; }

        public string Location { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Radius { get; set; }
    }
}
