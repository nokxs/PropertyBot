using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Entity;

namespace PropertyBot.Provider.Wunschimmo.Converter
{
    internal class WunschimmoConverter : IWunschimmoConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<WunschimmoProperty> wunschimmoProperties)
        {
            return wunschimmoProperties.Select(ToProperty);
        }

        private Property ToProperty(WunschimmoProperty wunschimmoProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", wunschimmoProperty.Location},
                {"Zimmer", wunschimmoProperty.RoomCount.ToString()},
                {"Wohnfläche", $"{wunschimmoProperty.LivingArea} m²"},
                {"Grundstücksfläche", $"{wunschimmoProperty.PropertyArea} m²"}
            };

            return new Property(
                wunschimmoProperty.Id.ToString(),
                wunschimmoProperty.Description,
                wunschimmoProperty.ImageUri,
                DateTime.Now, 
                wunschimmoProperty.Price,
                details,
                wunschimmoProperty.DetailsUri, 
                MessageFormat.Html);
        }
    }
}
