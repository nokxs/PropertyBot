using System;
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

        public async Task<Root> GetZvgObjects(KskWebClientOptions options)
        {
            //var message = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri =
            //        new Uri("https://www.kskbb.de/content/myif/ksk-boeblingen/work/filiale/de/home/misc/vps/gate/_jcr_content.bin/sip/api"),
            //    Content = new StringContent("{\"route\":\"estate\",\"page\":1,\"zip_city_estate_id\":\"71277\",\"marketing_usage_object_type\":\"buy_residential_flat\",\"perimeter\":\"25\",\"sort_by\":\"distance_asc\",\"limit\":\"1000\",\"regio_client_id\":\"60350130\",\"return_data\":\"overview\"}")
            //};

            //var result = await _client.SendAsync(message);

            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://www.kskbb.de/content/myif/ksk-boeblingen/work/filiale/de/home/misc/vps/gate/_jcr_content.bin/sip/api"))
            {
                request.Content = new StringContent("{\"route\":\"estate\",\"page\":1,\"zip_city_estate_id\":\"71277\",\"marketing_usage_object_type\":\"buy_residential_flat\",\"perimeter\":\"25\",\"sort_by\":\"distance_asc\",\"limit\":\"9\",\"regio_client_id\":\"60350130\",\"return_data\":\"overview\"}");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var result = await _client.SendAsync(request);
                var resultString = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Root>(resultString);
            }
        }
    }
}
