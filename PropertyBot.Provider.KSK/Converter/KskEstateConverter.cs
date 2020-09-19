using System;
using System.Collections.Generic;
using System.Linq;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.KSK.Entity;

namespace PropertyBot.Provider.KSK.Converter
{
    internal class KskEstateConverter : IKskEstateConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<Estate> estates)
        {
            foreach (var estate in estates)
            {
                var id = estate.Id;
                var description = CreateDescription(estate);
                var imageUrl = GetImageUri(estate);
                var addDate = DateTime.Parse(estate.Sip.Created);
                var price = estate.Preise.Kaufpreis ?? "0";
                var detailsUrl = new Uri($"https://www.kskbb.de/de/home/privatkunden/immobilien/detailansicht.html?eid={estate.Id}");
                var additionalDetails = GetAdditionalDetails(estate);
                
                yield return new Property(id, description, imageUrl, addDate, price.ToInt(), additionalDetails, detailsUrl, MessageFormat.Html, "Kreissparkasse");
            }
        }

        private IDictionary<string, string> GetAdditionalDetails(Estate estate)
        {
            return new Dictionary<string, string>
            {
                {"Ort", $"{estate.Geo.Plz} {estate.Geo.Ort}"},
                {"Courtage", estate.Preise.AussenCourtage},
                {"Wohnfläche", $"{estate.Flaechen.Wohnflaeche} m²"},
                {"Grundstücksfläche", $"{estate.Flaechen.Grundstuecksflaeche} m²"},
                {"Zimmer", estate.Flaechen.AnzahlZimmer},
                {"Baujahr", estate.ZustandAngaben.Baujahr},
                {"Modernisierung", estate.ZustandAngaben.Letztemodernisierung},
                {"Anbieter", estate.Anbieter.Firma},
            };
        }

        private Uri GetImageUri(Estate estate)
        {
            var images = estate.Sip.Images;

            if (images.Any())
            {
                return new Uri(images.First().Formats.M);
            }

            return new Uri("https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png");
        }

        private string CreateDescription(Estate estate)
        {
            return $"<b>{estate.Freitexte.Objekttitel}</b>";
        }
    }
}
