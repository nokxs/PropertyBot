namespace Crawler.Provider.ZVG.WebClient
{
    public class ZvgWebClientOptions
    {
        internal ZvgWebClientOptions(string stateId, string courtIds, string objectKindIds)
        {
            StateId = stateId;
            CourtIds = courtIds;
            ObjectKindIds = objectKindIds;
        }

        public string StateId { get; }

        public string CourtIds { get; }

        public string ObjectKindIds { get; }
    }
}
