using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.Converter
{
    internal class ImmoscouttConverter : IImmoscoutConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoscoutProperty> immoscoutListProperties)
        {
            return immoscoutListProperties.Select(ToProperty);
        }

        private Property ToProperty(ImmoscoutProperty immoscoutProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", immoscoutProperty.Location},
                {"Zimmer", immoscoutProperty.RoomCount.Format()},
                {"Wohnfläche", $"{immoscoutProperty.LivingArea.Format()} m²"},
                {"Grundstücksfläche", $"{immoscoutProperty.PlotArea.Format()} m²"}
            };

            return new Property(
                immoscoutProperty.Id,
                immoscoutProperty.Description,
                immoscoutProperty.ImageUri,
                DateTime.Now,
                immoscoutProperty.Price,
                details,
                immoscoutProperty.DetailsUri,
                MessageFormat.Html,
                "Immobilienscout24");
        }
    }
}
