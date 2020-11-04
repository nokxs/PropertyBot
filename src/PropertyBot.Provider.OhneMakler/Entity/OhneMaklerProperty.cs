using System;

namespace PropertyBot.Provider.OhneMakler.Entity
{
    internal class OhneMaklerProperty
    {
        public OhneMaklerProperty(string id, string description, string type, string location, int price, double roomCount, double livingArea, Uri imageUri) {
            Id = id;
            Description = description;
            Type = type;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            ImageUri = imageUri;
        }

        public string Id { get;  }

        public string Description { get; }

        public string Type { get; }

        public string Location { get; }

        public int Price { get; }

        public double RoomCount { get; }

        public double LivingArea { get; }
        
        public Uri ImageUri { get; }
    }
}
