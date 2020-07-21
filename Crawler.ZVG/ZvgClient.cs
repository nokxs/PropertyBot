using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Interface;
using Crawler.Provider.ZVG.Converter;
using Crawler.Provider.ZVG.Options;
using Crawler.Provider.ZVG.WebClient;

namespace Crawler.Provider.ZVG
{
    public class ZvgClient : IPropertyProvider
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
