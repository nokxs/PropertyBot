namespace PropertyBot.Provider.VolksbankFlowfact.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public string InputMask { get; set; }

        public long ClientId { get; set; }

        public string ZipTown { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Radius { get; set; }
    }
}
