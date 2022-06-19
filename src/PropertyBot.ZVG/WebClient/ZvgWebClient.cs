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
            var handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();
            handler.UseCookies = true;
            handler.UseDefaultCredentials = true;
            _client = new HttpClient(handler) { BaseAddress = new Uri("https://www.zvg.com") };
            _logger = logger;
        }

        public async Task<ZvgRows> GetObjects(ZvgWebClientOptions options)
        {
            await SetCookie();
            var url = $"appl/termine.prg?act=getGridData&vt=&id_b={options.StateId}&ids={options.ObjectKindIds}&ido={options.CourtIds}&sort=a";
            try {
                var streamTask = _client.GetStreamAsync(url);
                return await JsonSerializer.DeserializeAsync<ZvgRows>(await streamTask);
            } catch (Exception e) {
                _logger.LogCritical(e, $"Could not parse answer from ZVG ({_client.BaseAddress}{url})");
                return new ZvgRows();
            }
        }

        private async Task SetCookie()
        {
            var url = $"appl/cookie.prg";
            try {
                await _client.GetStreamAsync(url);
            } catch (Exception e) {
                _logger.LogCritical(e, $"Could not set ZVG Cookie from URL {url}");
                throw e;
            }
        }
    }
}
