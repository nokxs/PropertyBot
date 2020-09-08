using System.Threading.Tasks;
using PropertyBot.Provider.Wunschimmo.WebClient;

namespace PropertyBot.Provider.Wunschimmo
{
    public class Program
    {
        public static async Task Main(string[] parameters)
        {
            var webClient = new WunschimmoWebClient();
            var options = new WunschimmoWebClientOptions("baden-wuerttemberg,ludwigsburg,ditzingen", 40, "haus-kaufen");

            var result = await webClient.GetObjects(options);
        }
    }
}
