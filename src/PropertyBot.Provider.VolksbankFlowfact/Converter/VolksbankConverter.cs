using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Entity;

namespace PropertyBot.Provider.VolksbankFlowfact.Converter
{
    internal class VolksbankConverter : IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(long clientId, IEnumerable<VolksbankProperty> volksbankProperties)
        {
            return volksbankProperties.Select(property => ToProperty(clientId, property));
        }

        private Property ToProperty(long clientId, VolksbankProperty volksbankProperty)
        {
            var details = new Dictionary<string, string>
            {
                {"Ort", volksbankProperty.Location},
                {"Zimmer", volksbankProperty.RoomCount.Format()},
                {"Wohnfläche", $"{volksbankProperty.LivingArea.Format()} m²"}
            };

            return new Property(
                volksbankProperty.Id,
                volksbankProperty.Description,
                volksbankProperty.ImageUri,
                DateTime.Now, 
                volksbankProperty.Price,
                details,
                new Uri($"https://{clientId}.flowfact-webparts.net/index.php/estates/{volksbankProperty.Id}"), 
                MessageFormat.Html,
                "Volksbank Neckar-Enz");
        }
    }
}
