using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using PropertyBot.Provider.KSK.Entity;

namespace PropertyBot.Provider.KSK.WebClient
{
    internal class KskWebClient : IKskWebClient
    {
        private readonly HttpClient _client;

        public KskWebClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Estate>> GetObjects(KskWebClientOptions options)
        {
            var estates = new List<Estate>();

            foreach (var marketingUsageObjectType in options.MarketingUsageObjectType)
            {
                var firstPage = await GetPage(options, 1, marketingUsageObjectType);

                estates.AddRange(firstPage.Embedded.Estate);

                for (int page = 2; page <= firstPage.PageCount; page++)
                {
                    var pageContent = await GetPage(options, page, marketingUsageObjectType);
                    estates.AddRange(pageContent.Embedded.Estate);
                }
            }
            
            return estates;
        }

        public async Task<Root> GetPage(KskWebClientOptions options, int page, string marketingUsageObjectType)
        {
            var resultString = await GetRawPage(options, page, marketingUsageObjectType);
            return JsonSerializer.Deserialize<Root>(resultString);
        }

        private async Task<string> GetRawPage(KskWebClientOptions options, int page, string marketingUsageObjectType)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"),
                "https://www.kskbb.de/content/myif/ksk-boeblingen/work/filiale/de/home/misc/vps/gate/_jcr_content.bin/sip/api");
            request.Content = new StringContent(
                $"{{\"route\":\"estate\",\"page\":\"{page}\",\"zip_city_estate_id\":\"{options.ZipRadiusSearch}\",\"marketing_usage_object_type\":\"{marketingUsageObjectType}\",\"perimeter\":\"{options.PerimeterInKm}\",\"sort_by\":\"distance_asc\",\"limit\":\"{options.Limit}\",\"regio_client_id\":\"{options.RegioClientId}\",\"return_data\":\"overview\"}}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var result = await _client.SendAsync(request);
            var resultString = await result.Content.ReadAsStringAsync();

            if (resultString.StartsWith("{\"pending"))
            {
                return await GetRawPage(options, page, marketingUsageObjectType);
            }

            return resultString;
        }
    }
}
