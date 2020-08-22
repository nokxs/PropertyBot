namespace PropertyBot.Provider.GutImmo.WebClient
{
    internal class GutImmoWebClientOptions
    {
        public GutImmoWebClientOptions(string buyIds, string categoryIds)
        {
            BuyIds = buyIds;
            CategoryIds = categoryIds;
        }

        public string BuyIds { get; }

        public string CategoryIds { get; }

    }
}
