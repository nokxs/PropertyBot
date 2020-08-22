namespace PropertyBot.Provider.LinkImmo.WebClient
{
    internal class LinkImmoWebClientOptions
    {
        public LinkImmoWebClientOptions(string buyIds, string categoryIds)
        {
            BuyIds = buyIds;
            CategoryIds = categoryIds;
        }

        public string BuyIds { get; }

        public string CategoryIds { get; }

    }
}
