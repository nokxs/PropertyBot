using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Converter;
using PropertyBot.Provider.ZVG.Options;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG
{
    internal class ZvgClient : IPropertyProvider
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
