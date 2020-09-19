using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Entity;

namespace PropertyBot.Provider.ZVG.Converter
{
    internal class ZvgObjectConverter : IZvgObjectConverter
    {
        private const string ImageUriRegex = "src='(.*)' style";
        private const string PriceRegex = "Verkehrswert:(.*)EURO";

        public IEnumerable<Property> ToProperties(ZvgRows zvgRows)
        {
            foreach (var zvgObject in zvgRows.Rows)
            {
                yield return ToProperty(zvgObject);
            }
        }

        private Property ToProperty(ZvgObject zvgObject)
        {
            var id = zvgObject.Id;
            var description = zvgObject.Data.Skip(1).First();
            var imageUri = GetImageUrl(zvgObject.Data.First());
            var addDate = DateTime.Parse(zvgObject.Data.Last(), new CultureInfo("de-DE"));
            var price = GetPrice(zvgObject.Data.Skip(1).First());
            var details = new Uri($"https://www.zvg.com/appl/termine.prg?act=getText&id={id}");
            var additionalDetails = new Dictionary<string, string>
            {
                {"Versteigerungszeit/ort", zvgObject.Data.Skip(2).First()} 
            };

            return new Property($"zvg-{id}", description, imageUri, addDate, price, additionalDetails, details, MessageFormat.Html, "ZVG");
        }

        private int GetPrice(string descriptionText)
        {
            var regexMatch = Regex.Match(descriptionText, PriceRegex);

            if (regexMatch.Captures.Any())
            {
                var priceString = regexMatch.Groups.Values.Last().Value.Trim();
                priceString = priceString.Replace(".", String.Empty);
                return int.Parse(priceString);
            }

            return 0;
        }

        private Uri GetImageUrl(string imageTagString)
        {
            var regexMatch = Regex.Match(imageTagString, ImageUriRegex);

            if (regexMatch.Captures.Any())
            {
                return new Uri(regexMatch.Groups.Values.Last().Value);
            }

            return new Uri("https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png");
        }
    }
}
