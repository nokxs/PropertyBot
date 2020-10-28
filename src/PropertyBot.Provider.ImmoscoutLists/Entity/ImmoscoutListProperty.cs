using System;

namespace PropertyBot.Provider.ImmoscoutLists.Entity
{
    internal class ImmoscoutListProperty
    {
        public ImmoscoutListProperty(string id, string description, string location, int price, double roomCount, double livingArea, Uri imageUri, Uri detailsUri)
        {
            Id = id;
            Description = description;
            Location = location;
            Price = price;
            RoomCount = roomCount;
            LivingArea = livingArea;
            ImageUri = imageUri;
            DetailsUri = detailsUri;
        }

        private string Id { get; }

        private string Description { get; }

        private string Location { get; }

        private int Price { get; }

        private double RoomCount { get; }

        private double LivingArea { get; }

        private Uri ImageUri { get; }

        private Uri DetailsUri { get; }
    }
}
