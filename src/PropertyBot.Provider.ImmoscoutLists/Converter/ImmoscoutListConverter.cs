using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Entity;

namespace PropertyBot.Provider.ImmoscoutLists.Converter
{
    internal class ImmoscoutListConverter : IImmoscoutListConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoscoutListProperty> immoscoutListProperties)
        {
            return immoscoutListProperties.Select(ToProperty);
        }

        private Property ToProperty(ImmoscoutListProperty immoscoutListProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", immoscoutListProperty.Location},
                {"Zimmer", immoscoutListProperty.RoomCount.Format()},
                {"Wohnfläche", $"{immoscoutListProperty.LivingArea.Format()} m²"}
            };

            return new Property(
                immoscoutListProperty.Id,
                immoscoutListProperty.Description,
                immoscoutListProperty.ImageUri,
                DateTime.Now,
                immoscoutListProperty.Price,
                details,
                immoscoutListProperty.DetailsUri,
                MessageFormat.Html,
                "Immoscout List");
        }
    }
}
