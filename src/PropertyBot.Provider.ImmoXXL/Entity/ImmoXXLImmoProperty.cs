using System;

namespace PropertyBot.Provider.ImmoXXL.Entity
{
    internal class ImmoXXLImmoProperty
    {
        public ImmoXXLImmoProperty(string id, string roomCount, int livingArea, string propertyType, string description, string location, int price, Uri imageUrl, Uri detailUrl, string providerName)
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
            ProviderName = providerName;
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

        public string ProviderName { get; }
    }
}
