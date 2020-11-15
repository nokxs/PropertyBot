using System;

namespace PropertyBot.Provider.OhneMakler.Entity
{
    internal class ImmosuchmaschineProperty
    {
        public ImmosuchmaschineProperty(string id, string description, string type, string location, int price, double roomCount, double livingArea, double plotArea, Uri imageUri, Uri detailsUri) {
            Id = id;
            Description = description;
            Type = type;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            PlotArea = plotArea;
            ImageUri = imageUri;
            DetailsUri = detailsUri;
        }

        public string Id { get;  }

        public string Description { get; }

        public string Type { get; }

        public string Location { get; }

        public int Price { get; }

        public double RoomCount { get; }

        public double LivingArea { get; }

        public double PlotArea { get; }

        public Uri ImageUri { get; }

        public Uri DetailsUri { get; }
    }
}
