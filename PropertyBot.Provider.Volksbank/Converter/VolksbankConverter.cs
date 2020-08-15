using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.Converter
{
    internal class VolksbankConverter : IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<VolksbankProperty> volksbankProperties)
        {
            return volksbankProperties.Select(ToProperty);
        }

        private Property ToProperty(VolksbankProperty volksbankProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", volksbankProperty.Location},
                {"Zimmer", volksbankProperty.RoomCount.ToString()},
                {"Wohnfläche", $"{volksbankProperty.LivingArea} m²"},
                {"Grundstücksfläche", $"{volksbankProperty.PropertyArea} m²"}
            };

            return new Property(
                volksbankProperty.Id.ToString(),
                volksbankProperty.Description,
                volksbankProperty.ImageUri,
                DateTime.Now, 
                volksbankProperty.Price,
                details,
                new Uri($"https://www.immopool.de/ASP/immo/obj/immoexpose.asp?Lasid=53048086&inetlfdnr={volksbankProperty.Id}"), 
                MessageFormat.Html);
        }
    }
}
