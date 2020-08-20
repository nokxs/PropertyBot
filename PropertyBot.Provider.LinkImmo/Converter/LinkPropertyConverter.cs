using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.Converter
{
    internal class LinkPropertyConverter : ILinkPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<LinkProperty> properties)
        {
            return properties.Select(ToProperty);
        }

        private Property ToProperty(LinkProperty linkProperty)
        {
            return new Property(linkProperty.Id, linkProperty.Description, linkProperty.ImageUrl, DateTime.Now, linkProperty.Price, GetAdditionalDetails(linkProperty), linkProperty.DetailUrl, MessageFormat.Html);
        }

        private IDictionary<string, string> GetAdditionalDetails(LinkProperty linkProperty)
        {
            return new Dictionary<string, string>
            {
                {"Ort", linkProperty.Location},
                {"Typ", linkProperty.PropertyType},
                {"Zimmer", linkProperty.RoomCount},
                {"Wohnfläche", $"{linkProperty.LivingArea} m²"}
            };
        }
    }
}
