using System.Threading.Tasks;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    public static class Program
    {
        public static async Task Main(params string[] args)
        {
            var wc = new OhneMaklerWebClient();
            var o = new OhneMaklerClientOptions
            {
                Location = "Ditzingen",
                State = 1,
                MarketingType = "SELL",
                ObjectType = "HAUS",
                Radius = 25
            };
            
            var a = await wc.GetObjects(o);
        }
    }
}
