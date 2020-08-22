using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.Entity;

namespace PropertyBot.Provider.Base.ImmoXXL.Converter
{
    internal class ImmoXXLPropertyConverter : IImmoXXLPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoXXLmmoProperty> properties)
        {
            return properties.Select(ToProperty);
        }

        private Property ToProperty(ImmoXXLmmoProperty gutImmoProperty)
        {
            return new Property(gutImmoProperty.Id, gutImmoProperty.Description, gutImmoProperty.ImageUrl, DateTime.Now, gutImmoProperty.Price, GetAdditionalDetails(gutImmoProperty), gutImmoProperty.DetailUrl, MessageFormat.Html);
        }

        private IDictionary<string, string> GetAdditionalDetails(ImmoXXLmmoProperty gutImmoProperty)
        {
            return new Dictionary<string, string>
            {
                {"Ort", gutImmoProperty.Location},
                {"Typ", gutImmoProperty.PropertyType},
                {"Zimmer", gutImmoProperty.RoomCount},
                {"Wohnfläche", $"{gutImmoProperty.LivingArea} m²"}
            };
        }
    }
}
