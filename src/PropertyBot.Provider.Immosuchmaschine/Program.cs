using System;
using System.Threading.Tasks;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.Immosuchmaschine
{
    public class Program
    {
        public static async Task Main(params string[] args)
        {
            var wc = new ImmosuchmaschineWebClient();
            var o = new ImmosuchmaschineClientOptions();

            var a = await wc.GetObjects(o);
        }
    }
}
