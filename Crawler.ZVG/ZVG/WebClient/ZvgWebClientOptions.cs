namespace Crawler.ZVG.ZVG.WebClient
{
    public class ZvgWebClientOptions
    {
        public ZvgWebClientOptions(string stateId, string courtIds, string objectKindIds)
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
