using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Crawler.ZVG.ZVG.Entity;

namespace Crawler.ZVG.ZVG.WebClient
{
    public class ZvgWebClient : IZvgWebClient
    {
        private readonly HttpClient _client;

        public ZvgWebClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://www.zvg.com") };
        }

        public async Task<ZvgRows> GetZvgObjects(ZvgWebClientOptions options)
        {
            var streamTask = _client.GetStreamAsync($"appl/termine.prg?act=getGridData&vt=&id_b={options.StateId}&ids={options.ObjectKindIds}&ido={options.CourtIds}&sort=a");
            return await JsonSerializer.DeserializeAsync<ZvgRows>(await streamTask);
        }
    }
}
