using System;

namespace PropertyBot.Provider.Immoscout.Entity
{
    internal class ImmoscoutProperty
    {
        public ImmoscoutProperty(string id, string description, string location, int price, double roomCount, double livingArea, double plotArea, Uri imageUri, Uri detailsUri)
        {
            Id = id;
            Description = description;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            PlotArea = plotArea;
            ImageUri = imageUri;
            DetailsUri = detailsUri;
        }

        public string Id { get; }

        public string Description { get; }

        public string Location { get; }

        public int Price { get; }

        public double RoomCount { get; }

        public double LivingArea { get; }
        
        public double PlotArea { get; }
        
        public Uri ImageUri { get; }

        public Uri DetailsUri { get; }
    }
}
