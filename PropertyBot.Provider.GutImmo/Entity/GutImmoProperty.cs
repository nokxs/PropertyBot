using System;

namespace PropertyBot.Provider.GutImmo.Entity
{
    internal class GutImmoProperty
    {
        public GutImmoProperty(string id, string roomCount, int livingArea, string propertyType, string description, string location, int price, Uri imageUrl, Uri detailUrl)
        {
            Id = id;
            RoomCount = roomCount;
            LivingArea = livingArea;
            PropertyType = propertyType;
            Description = description;
            Location = location;
            Price = price;
            ImageUrl = imageUrl;
            DetailUrl = detailUrl;
        }

        public string Id { get; }

        public string RoomCount { get; }

        public int LivingArea { get; }

        public string PropertyType { get; }

        public string Description { get; }

        public string Location { get; }

        public int Price { get; }

        public Uri ImageUrl { get; }

        public Uri DetailUrl { get; }
    }
}
