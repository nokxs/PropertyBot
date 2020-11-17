using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common.Extensions;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.Converter
{
    internal class ImmosuchmaschineConverter : IImmosuchmaschineConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmosuchmaschineProperty> volksbankProperties)
        {
            return volksbankProperties.Select(ToProperty);
        }

        private Property ToProperty(ImmosuchmaschineProperty immosuchmaschineProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", immosuchmaschineProperty.Location},
                {"Zimmer", immosuchmaschineProperty.RoomCount.Format()},
                {"Wohnfläche", $"{immosuchmaschineProperty.LivingArea.Format()} m²"},
                {"Online seit", $"{immosuchmaschineProperty.DaysOnline} Tagen"},
            };

            return new Property(
                $"immmosuchmaschine_{immosuchmaschineProperty.Id}",
                immosuchmaschineProperty.Description,
                immosuchmaschineProperty.ImageUri,
                DateTime.Now, 
                immosuchmaschineProperty.Price,
                details,
                immosuchmaschineProperty.DetailsUri, 
                MessageFormat.Html,
                "Immosuchmaschine.de");
        }
    }
}
