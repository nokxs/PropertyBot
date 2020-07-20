using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.ZVG.Informer;
using Crawler.ZVG.ZVG.Converter;
using Crawler.ZVG.ZVG.Options;
using Crawler.ZVG.ZVG.WebClient;

namespace Crawler.ZVG.ZVG
{
    public class ZvgClient
    {
        private readonly IZvgWebClient _zvgWebClient;
        private readonly IZvgOptionsReader _optionsReader;
        private readonly IZvgObjectConverter _converter;

        public ZvgClient(IZvgWebClient zvgWebClient, IZvgOptionsReader optionsReader, IZvgObjectConverter converter)
        {
            _zvgWebClient = zvgWebClient;
            _optionsReader = optionsReader;
            _converter = converter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var options = _optionsReader.GetWebClientOptions();
            var rows = await _zvgWebClient.GetZvgObjects(options);
            return _converter.ToProperties(rows);
        }
    }
}
