using System;
using System.Threading.Tasks;
using PropertyBot.Provider.Immoscout.WebClient;

namespace PropertyBot.Provider.Immoscout
{
    public static class Program
    {
        public static async Task Main(params string[] args)
        {
            var options = new ImmoscoutWebClientOptions
            {
                Latitude = "48.82434",
                Longitude = "9.06856",
                Location = "Ditzingen;71254",
                Radius = 20,
                Type = "haus-kaufen"
            };
            var wc = new ImmoscoutWebClient();

            var a = await wc.GetObjects(options, 1);
        }
    }
}
