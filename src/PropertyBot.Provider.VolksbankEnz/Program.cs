using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankEnz.WebClient;

namespace PropertyBot.Provider.VolksbankEnz
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var webClient = new VolksbankWebClient();
            var options = new VolksbankWebClientOptions(new []{"DA42D4E4-D160-44A1-A69E-246A39095EFE"});

            var result = await webClient.GetObjects(options);
        }
    }
}
