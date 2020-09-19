namespace PropertyBot.Provider.Base.ImmoXXL.WebClient
{
    public class ImmoXXLWebClientOptions
    {
        public ImmoXXLWebClientOptions(string baseUri, string buyIds, string categoryIds)
        {
            BaseUri = baseUri;
            BuyIds = buyIds;
            CategoryIds = categoryIds;
        }

        public string BaseUri { get; }

        public string BuyIds { get; }

        public string CategoryIds { get; }

    }
}
