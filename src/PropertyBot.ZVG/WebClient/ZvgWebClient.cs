using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Provider.ZVG.Entity;

namespace PropertyBot.Provider.ZVG.WebClient
{
    internal class ZvgWebClient : IZvgWebClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<ZvgClient> _logger;

        public ZvgWebClient(
            ILogger<ZvgClient> logger)
        {
            _client = new HttpClient { BaseAddress = new Uri("https://www.zvg.com") };
            _logger = logger;
        }

        public async Task<ZvgRows> GetObjects(ZvgWebClientOptions options)
        {
            try {
                var streamTask = _client.GetStreamAsync($"appl/termine.prg?act=getGridData&vt=&id_b={options.StateId}&ids={options.ObjectKindIds}&ido={options.CourtIds}&sort=a");
                return await JsonSerializer.DeserializeAsync<ZvgRows>(await streamTask);
            } catch (Exception e) {
                _logger.LogCritical(e, "Could not parse answer from ZVG");
                return new ZvgRows();
            }
        }
    }
}
