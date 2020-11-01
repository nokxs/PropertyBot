using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoXXL.Entity;

namespace PropertyBot.Provider.ImmoXXL.Converter
{
    internal class ImmoXXLPropertyConverter : IImmoXXLPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoXXLImmoProperty> properties)
        {
            return properties.Select(ToProperty);
        }

        private Property ToProperty(ImmoXXLImmoProperty immoXxlProperty)
        {
            return new Property(immoXxlProperty.Id,
                immoXxlProperty.Description,
                immoXxlProperty.ImageUrl,
                DateTime.Now,
                immoXxlProperty.Price,
                GetAdditionalDetails(immoXxlProperty),
                immoXxlProperty.DetailUrl,
                MessageFormat.Html,
                immoXxlProperty.ProviderName);
        }

        private IDictionary<string, string> GetAdditionalDetails(ImmoXXLImmoProperty immoXxlProperty)
        {
            return new Dictionary<string, string>
            {
                {"Ort", immoXxlProperty.Location},
                {"Typ", immoXxlProperty.PropertyType},
                {"Zimmer", immoXxlProperty.RoomCount},
                {"Wohnfläche", $"{immoXxlProperty.LivingArea} m²"}
            };
        }
    }
}
