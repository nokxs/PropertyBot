using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankStuttgart.WebClient;

namespace PropertyBot.Provider.VolksbankStuttgart
{
    public static class Program
    {
        static async Task Main(string[] param)
        {
            var webClient = new VolksbankWebClient();
            var webClientOptions = new VolksbankWebClientOptions("004008001011000000", 10, 100, 144298);

            var result = await webClient.GetObjects(webClientOptions);
        }
    }
}
