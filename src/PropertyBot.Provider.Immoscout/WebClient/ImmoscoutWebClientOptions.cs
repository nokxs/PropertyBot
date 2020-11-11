namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal class ImmoscoutWebClientOptions
    {
        public string Type { get; set; }
        
        public string Location { get; set; }

        public string Latitude { get; set; }
        
        public string Longitude { get; set; }
        
        public int Radius { get; set; }
    }
}
