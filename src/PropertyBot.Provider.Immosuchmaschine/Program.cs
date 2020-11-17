using System;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Common.Settings;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.Immosuchmaschine
{
    public class Program
    {
        public static async Task Main(params string[] args)
        {
            var helper = new HtmlPaginationHelper();
            var wc = new ImmosuchmaschineWebClient(helper);
            var o = await new SettingsReader<ImmosuchmaschineClientOptions>().ReadSettings("providers/Immosuchmaschine.yml");

            var a = await wc.GetObjects(o.Settings.First());
        }
    }
}
