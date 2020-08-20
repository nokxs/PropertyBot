using System.Threading.Tasks;
using PropertyBot.Provider.LinkImmo.WebClient;

namespace PropertyBot.Provider.LinkImmo
{
    public static class Program
    {
        public static async Task Main(string[] parameters)
        {
            var webClient = new LinkImmoWebClient();
            var options = new LinkImmoWebClientOptions("1", "200");

            var result = await webClient.GetObjects(options);
        }
    }
}
