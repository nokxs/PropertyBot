using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.Entity;

namespace PropertyBot.Provider.Base.ImmoXXL.Converter
{
    internal class ImmoXXLPropertyConverter : IImmoXXLPropertyConverter
    {
        private readonly string _providerName;

        public ImmoXXLPropertyConverter(string providerName)
        {
            _providerName = providerName;
        }

        public IEnumerable<Property> ToProperties(IEnumerable<ImmoXXLmmoProperty> properties)
        {
            return properties.Select(ToProperty);
        }

        private Property ToProperty(ImmoXXLmmoProperty immoXxlProperty)
        {
            return new Property(immoXxlProperty.Id,
                immoXxlProperty.Description,
                immoXxlProperty.ImageUrl,
                DateTime.Now,
                immoXxlProperty.Price,
                GetAdditionalDetails(immoXxlProperty),
                immoXxlProperty.DetailUrl,
                MessageFormat.Html,
                _providerName);
        }

        private IDictionary<string, string> GetAdditionalDetails(ImmoXXLmmoProperty immoXxlProperty)
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
