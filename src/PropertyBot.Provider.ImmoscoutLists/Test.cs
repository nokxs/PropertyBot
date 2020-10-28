using System.Threading.Tasks;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    public static class Test
    {
        public static async Task Main(params string[] args)
        {
            var option = new ImmoscoutListWebClientOptions("14652716");
            var client = new ImmoscoutListWebClient();

            var result = await client.GetObjects(option);
        }
    }
}
