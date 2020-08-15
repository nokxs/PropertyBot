using System;

namespace PropertyBot.Provider.VolksbankStuttgart.Entity
{
    internal class VolksbankProperty
    {
        public VolksbankProperty(string description, string type, string location, int price, int roomCount, int livingArea, int propertyArea, Uri imageUri)
        {
            Description = description;
            Type = type;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            PropertyArea = propertyArea;
            ImageUri = imageUri;
        }

        public string Description { get; }

        public string Type { get; }

        public string Location { get; }

        public int Price { get; }

        public int RoomCount { get; }

        public int LivingArea { get; }

        public int PropertyArea { get; }

        public Uri ImageUri { get; }
    }
}
