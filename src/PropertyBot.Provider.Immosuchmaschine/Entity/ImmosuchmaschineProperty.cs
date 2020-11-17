using System;

namespace PropertyBot.Provider.OhneMakler.Entity
{
    internal record ImmosuchmaschineProperty
    {
        public ImmosuchmaschineProperty(string id, string description, string location, int price, double roomCount, double livingArea, int daysOnline, Uri imageUri, Uri detailsUri)
        {
            Id = id;
            Description = description;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            DaysOnline = daysOnline;
            ImageUri = imageUri;
            DetailsUri = detailsUri;
        }

        public string Id { get;  }

        public string Description { get; }

        public string Location { get; }

        public int Price { get; }

        public double RoomCount { get; }

        public double LivingArea { get; }

        public int DaysOnline { get; }

        public Uri ImageUri { get; }

        public Uri DetailsUri { get; }
    }
}
