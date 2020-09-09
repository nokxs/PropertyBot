using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Common;
using PropertyBot.Provider.Wunschimmo.Entity;

namespace PropertyBot.Provider.Wunschimmo.WebClient
{
    internal class WunschimmoWebClient : IWunschimmoWebClient
    {
        private const string BaseUrl = "https://www.wunschimmo.de";

        private readonly HttpClient _client;

        public WunschimmoWebClient()
        {
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            _client.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("Mozilla/5.0"));
        }

        public async Task<IEnumerable<WunschimmoProperty>> GetObjects(WunschimmoWebClientOptions options)
        {
            var properties = new List<WunschimmoProperty>();

            var firstPage = await GetRawPage(options, 1);
            var pageCount = GetPageCount(firstPage);
            properties.AddRange(ParseHtml(firstPage));

            for (int pageNr = 2; pageNr <= pageCount; pageNr++)
            {
                var page = await GetRawPage(options, pageNr);
                properties.AddRange(ParseHtml(page));
            }

            return properties;
        }

        private async Task<string> GetRawPage(WunschimmoWebClientOptions options, int pageNr)
        {
            var requestUri = $"{BaseUrl}/suche/{options.Region}/{options.ObjectType}?page={pageNr}&umkreis={options.PerimeterInKm}";
            return await _client.GetStringAsync(requestUri);
        }

        private IEnumerable<WunschimmoProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'offer')]");
            var properties = propertyNodes.Select(ConvertToProperty).ToList();

            return properties;
        }

        private WunschimmoProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.InnerHtml);

            return new WunschimmoProperty(
                GetId(node),
                GetDescription(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetPropertyArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode),
                GetDetailsUri(htmlDoc.DocumentNode));
        }

        private int GetId(HtmlNode node)
        {
            return (node?.Attributes.First(attribute => attribute.Name == "data-object-id").Value).ToIntSafe();
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//h3[contains(@class, 'title')]");
            return descriptionNode?.InnerText ?? string.Empty;
        }

        private string GetLocation(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//p[contains(@class, 'm-b-0')]");
            var locationEndIndex = descriptionNode?.InnerText?.IndexOf(" &nbsp;&nbsp;", StringComparison.Ordinal) ?? 0;
            return descriptionNode?.InnerText?.Substring(0, locationEndIndex >= 0 ? locationEndIndex : descriptionNode.InnerText.Length).Trim() ?? string.Empty;
        }

        private int GetPrice(HtmlNode node)
        {
            var priceText= GetData(node, "Kaufpreis", "Verkehrswert");
            return (priceText?.Replace("€", string.Empty)).ToIntSafe();
        }

        private int GetLivingArea(HtmlNode node)
        {
            var livingAreaText = GetData(node, "Wohnfläche");
            return (livingAreaText?.Replace("m²", string.Empty)).ToIntSafe();
        }

        private int GetRoomCount(HtmlNode node)
        {
            var livingAreaText = GetData(node, "Zimmer");
            return livingAreaText.ToIntSafe();
        }

        private int GetPropertyArea(HtmlNode node)
        {
            var livingAreaText = GetData(node, "Grundstück");
            return (livingAreaText?.Replace("m²", string.Empty)).ToIntSafe();
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//img[contains(@class, 'img-responsive')]");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "data-original")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";
            return new Uri($"https:{imageUriString}");
        }

        private Uri GetDetailsUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//div[contains(@class, 'imageBox')]/a");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "href")?.Value ?? BaseUrl;
            return new Uri($"{BaseUrl}{imageUriString}");
        }

        private int GetPageCount(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var optionNodes = htmlDoc.DocumentNode.SelectNodes("//select[@id='page_select']/option");
            return optionNodes?.Count ?? 1;
        }

        private static string GetData(HtmlNode node, params string[] identifiers)
        {
            var dataNodes = node.SelectNodes("//dt[contains(@class, 'fw-500')]");
            var dataNode = dataNodes.SingleOrDefault(dn => identifiers.Any(identifier => dn.ParentNode.InnerText.Contains(identifier)));
            return dataNode?.InnerText;
        }
    }
}
