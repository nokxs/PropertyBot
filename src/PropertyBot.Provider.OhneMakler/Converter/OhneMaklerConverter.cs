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
        public IEnumerable<Property> ToProperties(IEnumerable<OhneMaklerProperty> volksbankProperties)
        {
            return volksbankProperties.Select(ToProperty);
        }

        private Property ToProperty(OhneMaklerProperty ohneMaklerProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", ohneMaklerProperty.Location},
                {"Zimmer", ohneMaklerProperty.RoomCount.Format()},
                {"Wohnfläche", $"{ohneMaklerProperty.LivingArea.Format()} m²"},
                {"Grundstücksfläche", $"{ohneMaklerProperty.PlotArea.Format()} m²"},
                {"Typ", ohneMaklerProperty.Type}
            };

            return new Property(
                ohneMaklerProperty.Id,
                ohneMaklerProperty.Description,
                ohneMaklerProperty.ImageUri,
                DateTime.Now, 
                ohneMaklerProperty.Price,
                details,
                ohneMaklerProperty.DetailsUri, 
                MessageFormat.Html,
                "Ohne-Makler.net");
        }
    }
}
