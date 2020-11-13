using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using PropertyBot.Common.Extensions;
using PropertyBot.Common.Logging;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal class ImmoscoutWebClient : IImmoscoutWebClient
    {
        private readonly ILogger<ImmoscoutWebClient> _logger;
        private const string InvalidPage = "--- Invalid Result ---";

        private readonly HttpClient _client;

        public ImmoscoutWebClient(ILogger<ImmoscoutWebClient> logger)
        {
            _logger = logger;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0");
            _client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            _client.DefaultRequestHeaders.Add("Accept-Language", "de,en-US;q=0.7,en;q=0.3");
            _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
        }

        public async Task<WebClientResult> GetObjects(ImmoscoutWebClientOptions options, int pageNumber)
        {
            _logger.LogDebug($"Retrieving properties for page '{pageNumber}' with the following options: {options}");

            var rawPage = await GetRawPage(options, pageNumber);

            if (rawPage != InvalidPage)
            {
                var pageCount = GetPageCount(rawPage);
                var properties = ParseHtml(rawPage).ToList();
                var nextPageNumber = pageCount == pageNumber ? 1 : ++pageNumber;
                _logger.LogInfo($"Found {properties.Count} properties");
                return new WebClientResult(nextPageNumber, properties);
            }

            _logger.LogWarning($"Retrieving properties was not successful. Received an invalid page.");
            return new WebClientResult(1, Enumerable.Empty<ImmoscoutProperty>());
        }

        private async Task<string> GetRawPage(ImmoscoutWebClientOptions options, int pageNr)
        {
            var response = await _client.GetAsync($"https://www.immobilienscout24.de/Suche/radius/{options.Type}?centerofsearchaddress={options.Location};;;;&geocoordinates={options.Latitude};{options.Longitude};{options.Radius}&pagenumber={pageNr}");

            if (response.IsSuccessStatusCode)
            {
                var rawPage = await response.Content.ReadAsStringAsync();
                return rawPage.Contains("Mensch aus Fleisch und Blut") ? InvalidPage : rawPage;
            }

            return InvalidPage;
        }

        private IEnumerable<ImmoscoutProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'result-list__listing')]");

            return propertyNodes?.Select(ConvertToProperty).ToList() ?? Enumerable.Empty<ImmoscoutProperty>();
        }

        private ImmoscoutProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.OuterHtml);

            return new ImmoscoutProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetPlotArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode),
                GetDetailsUri(htmlDoc.DocumentNode));
        }

        private string GetId(HtmlNode node)
        {
            var id = node.ChildNodes.First().Attributes.First(attribute => attribute.Name == "data-id").Value;
            return $"immoscout_{id}";
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//h5[contains(@class, 'result-list-entry__brand-title')]");
            return HttpUtility.HtmlDecode(descriptionNode?.InnerText.RemoveRNT() ?? string.Empty);
        }

        private string GetLocation(HtmlNode node)
        {
            var locationNode = node.SelectSingleNode("//button[contains(@class, 'result-list-entry__map-link')]");
            return locationNode?.InnerText ?? string.Empty;
        }

        private int GetPrice(HtmlNode node)
        {
            var primaryNode = node.SelectSingleNode("//dl[contains(@class, 'result-list-entry__primary-criterion')]/dt[contains(text(), 'Kaufpreis')]");
            if (primaryNode == null)
            {
                primaryNode = node.SelectSingleNode("//dl[contains(@class, 'result-list-entry__primary-criterion')]/dt[contains(text(), 'Preis')]");
            }

            return primaryNode?.PreviousSibling.InnerText.ToIntSafe() ?? 0;
        }

        private double GetLivingArea(HtmlNode node)
        {
            var primaryNode = node.SelectSingleNode("//dl[contains(@class, 'result-list-entry__primary-criterion')]/dt[contains(text(), 'Wohnfläche')]");
            return primaryNode.PreviousSibling.InnerText.Replace("m²", string.Empty).ToDoubleSafe();
        }

        private double GetPlotArea(HtmlNode node)
        {
            var primaryNode = node.SelectSingleNode("//dl[contains(@class, 'result-list-entry__primary-criterion')]/dt[contains(text(), 'Grundstück')]");
            return primaryNode.PreviousSibling.InnerText.Replace("m²", string.Empty).ToDoubleSafe();
        }

        private double GetRoomCount(HtmlNode node)
        {
            var primaryNode = node.SelectSingleNode("//dl[contains(@class, 'result-list-entry__primary-criterion')]/dd/span/span[contains(@class, 'onlyLarge')]");
            return primaryNode.PreviousSibling.InnerText.Replace("Zi.", string.Empty).ToDoubleSafe();
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//img[contains(@class, 'gallery__image')]");
            var imageUriString = GetImageUriString(imageNode) ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";

            return new Uri(imageUriString);
        }

        private static string GetImageUriString(HtmlNode imageNode)
        {
            var imageUri = imageNode?.Attributes.First(attribute => attribute.Name == "src" || attribute.Name == "data-lazy-src")?.Value;
            return imageUri?.Substring(0, imageUri.IndexOf("/ORIG", StringComparison.Ordinal));
        }

        private Uri GetDetailsUri(HtmlNode node)
        {
            var linkNode = node.SelectSingleNode("//a[contains(@class, 'result-list-entry__brand-logo-container')]");
            var uri = linkNode?.Attributes.First(attribute => attribute.Name == "href").Value ?? string.Empty;
            return new Uri($"https://www.immobilienscout24.de{uri}");
        }

        private int GetPageCount(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var pageNode = htmlDoc.DocumentNode.SelectNodes("//select[contains(@class, 'select')]/option");
            return pageNode?.Count ?? 1;
        }
    }
}
