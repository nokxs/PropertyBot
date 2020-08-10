using System;
using System.Threading.Tasks;
using PropertyBot.Provider.KSK.Converter;
using PropertyBot.Provider.KSK.WebClient;

namespace PropertyBot.Provider.KSK
{
    public static class Program
    {
        public static async Task Main(string[] parameters)
        {
            Environment.SetEnvironmentVariable("PROVIDER_KSK_ZIPS", "71254,70563");
            Environment.SetEnvironmentVariable("PROVIDER_KSK_PERIMETERS_IN_KM", "15,10");


            var webClient = new KskWebClient();
            var converter = new KskEstateConverter();

            var client = new KskClient(webClient, converter);
            var properties = await client.GetProperties();
        }
    }
}
