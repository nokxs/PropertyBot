using System;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.Immosuchmaschine
{
    public class Program
    {
        public static async Task Main(params string[] args)
        {
            var helper = new HtmlPaginationHelper();
            var wc = new ImmosuchmaschineWebClient(helper);
            var o = new ImmosuchmaschineClientOptions();

            var a = await wc.GetObjects(o);
        }
    }
}
