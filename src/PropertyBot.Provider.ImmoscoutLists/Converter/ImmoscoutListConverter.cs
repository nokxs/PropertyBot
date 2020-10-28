using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Entity;

namespace PropertyBot.Provider.ImmoscoutLists.Converter
{
    internal class ImmoscoutListConverter : IImmoscoutListConverter
    {
        public IEnumerable<Property> ToProperties(long clientId, IEnumerable<ImmoscoutListProperty> immoscoutListProperties)
        {
            return immoscoutListProperties.Select(property => ToProperty(clientId, property));
        }

        private Property ToProperty(long clientId, ImmoscoutListProperty immoscoutListProperty)
        {
            //var details = new Dictionary<string, string>
            //{
            //    {"Ort", immoscoutListProperty.Location},
            //    {"Zimmer", immoscoutListProperty.RoomCount.Format()},
            //    {"Wohnfläche", $"{immoscoutListProperty.LivingArea.Format()} m²"}
            //};

            //return new Property(
            //    immoscoutListProperty.Id,
            //    immoscoutListProperty.Description,
            //    immoscoutListProperty.ImageUri,
            //    DateTime.Now, 
            //    immoscoutListProperty.Price,
            //    details,
            //    new Uri($"https://{clientId}.flowfact-webparts.net/index.php/estates/{immoscoutListProperty.Id}"), 
            //    MessageFormat.Html,
            //    "Volksbank Neckar-Enz");
            return null;
        }
    }
}
