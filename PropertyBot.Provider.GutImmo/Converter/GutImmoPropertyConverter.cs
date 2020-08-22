using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.GutImmo.Entity;

namespace PropertyBot.Provider.GutImmo.Converter
{
    internal class GutImmoPropertyConverter : IGutImmoPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<GutImmoProperty> properties)
        {
            return properties.Select(ToProperty);
        }

        private Property ToProperty(GutImmoProperty gutImmoProperty)
        {
            return new Property(gutImmoProperty.Id, gutImmoProperty.Description, gutImmoProperty.ImageUrl, DateTime.Now, gutImmoProperty.Price, GetAdditionalDetails(gutImmoProperty), gutImmoProperty.DetailUrl, MessageFormat.Html);
        }

        private IDictionary<string, string> GetAdditionalDetails(GutImmoProperty gutImmoProperty)
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
