using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClient : IVolksbankWebClient
    {
        private readonly HttpClient _client;

        public VolksbankWebClient()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options)
        {
            var properties = new List<VolksbankProperty>();
            var resultString = await GetRawPage(options);

            return null;
        }

        private async Task<string> GetRawPage(VolksbankWebClientOptions options)
        {
            var content = new Dictionary<string, string>
            {
                {"kdnr", options.CustomerId.ToString()},
                {"version", "3"},
                {"pageSize", options.Limit.ToString()},
                {"pageIndex", options.ObjectCategory.ToString()},
                {"objkat", }, // house
                {"geosl", options.GeoSl},
                {"umkreis", options.GeoSlRadiusSearch.ToString()},
                {"sortOrder", "0_1"}
            };

            var result = await _client.PostAsync("https://cs.immopool.de/CS/getListe", new FormUrlEncodedContent(content));
            return await result.Content.ReadAsStringAsync();
        }
    }
}
