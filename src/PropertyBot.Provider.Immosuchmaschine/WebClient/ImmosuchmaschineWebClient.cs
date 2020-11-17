using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Common;
using PropertyBot.Common.Extensions;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.WebClient
{
    internal class ImmosuchmaschineWebClient : IImmosuchmaschineWebClient
    {
        private readonly IHtmlPaginationHelper _paginationHelper;
        private readonly HttpClient _client;

        public ImmosuchmaschineWebClient(IHtmlPaginationHelper paginationHelper)
        {
            _paginationHelper = paginationHelper;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<ImmosuchmaschineProperty>> GetObjects(ImmosuchmaschineClientOptions options) =>
            await _paginationHelper.GetPaginatedObjects(GetRawPage, ParseHtml, GetPageCount, options);

        private async Task<string> GetRawPage(ImmosuchmaschineClientOptions options, int pageNr)
        {
            return await _client.GetStringAsync($"https://www.immosuchmaschine.de/suche/?form_page=search&newsearch=1{GetDistricts(options.DistrictIds)}{GetMuncipals(options.MuncipalIds)}{GetProvinces(options.ProvinceIds)}&objpay_type={options.Type}&price_from={options.PriceFrom.ToSetString()}&price_to={options.PriceTo.ToSetString()}&size_from={options.SizeFrom.ToSetString()}&size_to={options.SizeTo.ToSetString()}&site={pageNr}");
        }

        private string GetDistricts(IEnumerable<string> values) => GetUrlParameter(values, "district_id");

        private string GetMuncipals(IEnumerable<string> values) => GetUrlParameter(values, "muni_id");

        private string GetProvinces(IEnumerable<string> values) => GetUrlParameter(values, "province_id");

        private string GetUrlParameter(IEnumerable<string> values, string argument)
        {
            var sb = new StringBuilder();

            foreach (var value in values)
            {
                sb.Append($"&{argument}[]={value}");
            }
            return sb.ToString();
        }

        private IEnumerable<ImmosuchmaschineProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@class, 'result-list')]/li");

            return propertyNodes?.Where(node => node.Id != string.Empty).Select(ConvertToProperty).ToList() ?? Enumerable.Empty<ImmosuchmaschineProperty>();
        }

        private ImmosuchmaschineProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.OuterHtml);

            return new ImmosuchmaschineProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetDaysOnline(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode),
                GetDetailsUri(htmlDoc.DocumentNode));
        }

        private string GetId(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//li[contains(@class, 'block_item')]");
            return idNode.Id;
        }

        private string GetDescription(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//h3/a[contains(@class, 'objectLink')]");
            return idNode?.InnerText.RemoveRNT();
        }

        private string GetLocation(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//span[contains(@class, 'data_zipcity_text')]");
            var text = descriptionNode?.InnerText.RemoveRNT() ?? string.Empty;
            var separatorId = text.IndexOf("•", StringComparison.Ordinal);
            return separatorId > 0 ? text.Substring(0, separatorId - 1) : text;
        }

        private int GetPrice(HtmlNode node)
        {
            var priceNode = node.SelectSingleNode("//div[contains(@class, 'data_price')]/dl/dd/span");

            var priceText = priceNode?.InnerText ?? string.Empty;
            return priceText.RemoveContent("&euro;", "&nbsp;", "€", ",-").ToIntSafe();
        }

        private double GetLivingArea(HtmlNode node)
        {
            var dataNode = node.SelectSingleNode("//div[contains(@class, 'data_size')]/dl/dd");
            return dataNode?.InnerText.RemoveContent("m²", "m&#178;").ToDoubleSafe() ?? 0;
        }

        private double GetRoomCount(HtmlNode node)
        {
            var dataNode = node.SelectSingleNode("//div[contains(@class, 'data_rooms')]/dl/dd");
            return dataNode?.InnerText.ToDoubleSafe() ?? 0;
        }

        private int GetDaysOnline(HtmlNode node)
        {
            var dataNode = node.SelectSingleNode("//span[contains(@class, 'data_created')]");
            return dataNode?.InnerText.RemoveContent("vor", "Tagen").ToIntSafe() ?? 0;
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//img[contains(@class, 'img-responsive')]");
            var uriString = imageNode?.Attributes.First(attribute => attribute.Name == "src" || attribute.Name == "data-original")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";
            return new Uri(uriString);
        }

        private Uri GetDetailsUri(HtmlNode node)
        {
            var detailsNode = node.SelectSingleNode("//a[contains(@class, 'objectLink')]");
            var uriString = detailsNode?.Attributes.First(attribute => attribute.Name == "href")?.Value ?? string.Empty;
            return new Uri(uriString);
        }

        private int GetPageCount(string htmlString)
        {
            const int resultsPerPage = 7;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var objectCountText = htmlDoc.DocumentNode.SelectSingleNode("//h1[contains(@id, 'header1')]")?.InnerText ?? string.Empty;
            var firstSpaceIndex = objectCountText.IndexOf(" ", StringComparison.Ordinal);

            if (firstSpaceIndex > 0)
            {
                var objectCount = objectCountText.Substring(0, firstSpaceIndex).ToIntSafe();
                return objectCount > 0 ? (int)Math.Ceiling((double) objectCount / resultsPerPage) : 1;
            }

            return 1;
        }
    }
}
