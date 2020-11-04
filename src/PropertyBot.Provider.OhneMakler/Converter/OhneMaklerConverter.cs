using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.Converter
{
    internal class OhneMaklerConverter : IOhneMaklerConverter
    {
        public IEnumerable<Property> ToProperties(long clientId, IEnumerable<OhneMaklerProperty> volksbankProperties)
        {
            return volksbankProperties.Select(property => ToProperty(clientId, property));
        }

        private Property ToProperty(long clientId, OhneMaklerProperty ohneMaklerProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", ohneMaklerProperty.Location},
                {"Zimmer", ohneMaklerProperty.RoomCount.Format()},
                {"Wohnfläche", $"{ohneMaklerProperty.LivingArea.Format()} m²"}
            };

            return new Property(
                ohneMaklerProperty.Id,
                ohneMaklerProperty.Description,
                ohneMaklerProperty.ImageUri,
                DateTime.Now, 
                ohneMaklerProperty.Price,
                details,
                new Uri($"https://{clientId}.flowfact-webparts.net/index.php/estates/{ohneMaklerProperty.Id}"), 
                MessageFormat.Html,
                "Volksbank Flowfact");
        }
    }
}
