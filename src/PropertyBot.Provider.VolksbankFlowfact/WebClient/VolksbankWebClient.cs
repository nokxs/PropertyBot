﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Common.Extensions;
using PropertyBot.Provider.VolksbankFlowfact.Entity;

namespace PropertyBot.Provider.VolksbankFlowfact.WebClient
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

            var rawPage = await GetRawPage(options, 1);
            var pageCount = GetPageCount(rawPage);
            properties.AddRange(ParseHtml(rawPage));

            for (int pageNr = 2; pageNr <= pageCount; pageNr++)
            {
                rawPage = await GetRawPage(options, pageNr);
                properties.AddRange(ParseHtml(rawPage));
            }

            return properties;
        }

        private async Task<string> GetRawPage(VolksbankWebClientOptions options, int pageNr)
        {
            return await _client.GetStringAsync($"https://{options.ClientId}.flowfact-webparts.net/index.php/estates?inputMask={options.InputMask}&page={pageNr}&zipTown={options.ZipTown}&lat={options.Latitude}&lng={options.Longitude}&radius={options.Radius}");
        }

        private IEnumerable<VolksbankProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//section[contains(@class, 'estate-view-grid')]");

            return propertyNodes?.Select(ConvertToProperty).ToList() ?? Enumerable.Empty<VolksbankProperty>();
        }

        private VolksbankProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.OuterHtml);

            return new VolksbankProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetType(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode));
        }

        private string GetId(HtmlNode node)
        {
            var estateNode = node.SelectSingleNode("//section[contains(@class, 'estate-view-grid')]");
            return estateNode?.Attributes.First(attribute => attribute.Name == "data-estate-id").Value;
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//h2[contains(@class, 'headline-tiles')]");
            return descriptionNode?.InnerText.Replace("\n", string.Empty).Replace("\t", string.Empty) ?? string.Empty;
        }

        private string GetType(HtmlNode node)
        {
            var typeNode = node.SelectSingleNode("//li[contains(@class, 'ion-home')]");
            return typeNode?.InnerText ?? string.Empty;
        }

        private string GetLocation(HtmlNode node)
        {
            var locationNode = node.SelectSingleNode("//li[contains(@class, 'ion-ios-location')]");
            return locationNode?.InnerText ?? string.Empty;
        }

        private int GetPrice(HtmlNode node)
        {
            var priceNode = node.SelectSingleNode("//div[contains(@class, 'estate-price')]");
            return (priceNode?.InnerText.Replace("EUR", string.Empty) ?? string.Empty).ToIntSafe();
        }

        private double GetLivingArea(HtmlNode node)
        {
            var detailsNode = node.SelectSingleNode("//li[contains(@class, 'ion-arrow-resize')]");
            var match = Regex.Match(detailsNode.InnerText ?? "", @"(\d*?(,|.)?(\d*)) m&sup2;");

            return match.Groups.Count >= 2 ? match.Groups[1].Value.ToDoubleSafe() : 0;
        }

        private double GetRoomCount(HtmlNode node)
        {
            var detailsNode = node.SelectSingleNode("//li[contains(@class, 'ion-arrow-resize')]");
            var match = Regex.Match(detailsNode.InnerText ?? "", @"(\d*?(,|.)?(\d*)) Zimmer");

            if (match?.Groups == null) {
                return 0;
            }

            return match.Groups.Count >= 2 ? match.Groups[1].Value.ToDoubleSafe() : 0;
        }
        
        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//div[contains(@class, 'estate-image')]/a/img");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "src")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png"; 
            return new Uri(imageUriString);
        }

        private int GetPageCount(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var pageNode = htmlDoc.DocumentNode.SelectSingleNode("//span[contains(@class, 'sum')]");
            return pageNode?.InnerText.ToIntSafe() ?? 1;
        }
    }
}
