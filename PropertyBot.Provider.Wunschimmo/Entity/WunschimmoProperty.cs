using System;

namespace PropertyBot.Provider.Wunschimmo.Entity
{
    internal class WunschimmoProperty
    {
        public WunschimmoProperty(long id, string description, string location, int price, int roomCount, int livingArea, int propertyArea, Uri imageUri, Uri detailsUri) {
            Id = id;
            Description = description;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            PropertyArea = propertyArea;
            ImageUri = imageUri;
            DetailsUri = detailsUri;
        }

        public long Id { get;  }

        public string Description { get; }
        
        public string Location { get; }

        public int Price { get; }

        public int RoomCount { get; }

        public int LivingArea { get; }

        public int PropertyArea { get; }

        public Uri ImageUri { get; }

        public Uri DetailsUri { get; }
    }
}
