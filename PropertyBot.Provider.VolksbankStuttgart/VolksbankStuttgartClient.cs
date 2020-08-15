using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Converter;
using PropertyBot.Provider.VolksbankStuttgart.WebClient;

namespace PropertyBot.Provider.VolksbankStuttgart
{
    public class VolksbankStuttgartClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _kskEstateConverter;

        internal VolksbankStuttgartClient(IVolksbankWebClient webClient, IVolksbankConverter kskEstateConverter)
        {
            _webClient = webClient;
            _kskEstateConverter = kskEstateConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            return null;
        }
    }
}
