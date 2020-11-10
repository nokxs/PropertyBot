using System.Threading.Tasks;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal interface IImmoscoutWebClient
    {
        public Task<WebClientResult> GetObjects(ImmoscoutWebClientOptions options, int firstPage);
    }
}