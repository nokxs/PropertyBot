using System;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Provider.ZVG.Converter;
using Crawler.Provider.ZVG.Options;
using Crawler.Provider.ZVG.WebClient;

namespace Crawler.Provider.ZVG
{
    //https://www.zvg.com/appl/termine.prg?act=getGridData&vt=&id_b=4&ids=159,114,49,86,105,&ido=35,4,5,49,&sort=a
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting");

            var webClient = new ZvgWebClient();
            var optionsReader = new ZvgOptionsReader();
            var converter = new ZvgObjectConverter();
            var zvgClient = new ZvgClient(webClient, optionsReader, converter);

            var properties = (await zvgClient.GetProperties()).ToList();
        }
    }
}
