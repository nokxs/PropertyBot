using System;
using System.Collections.Generic;

namespace PropertyBot.Interface
{
    public class Property
    {
        public Property(string id, string description, Uri imageUrl, DateTime addDate, int price, IDictionary<string, string> additionalDetails, Uri detailsUrl, MessageFormat messageFormat, string providerName)
        {
            Id = id;
            Description = description;
            ImageUrl = imageUrl;
            AddDate = addDate;
            Price = price;
            AdditionalDetails = additionalDetails;
            DetailsUrl = detailsUrl;
            MessageFormat = messageFormat;
            ProviderName = providerName;
        }

        public string Id { get; }

        public Uri ImageUrl { get; }

        public string Description { get; }

        public DateTime AddDate { get; }

        public int Price { get; }

        public Uri DetailsUrl { get; }

        public IDictionary<string, string> AdditionalDetails { get; }

        public MessageFormat MessageFormat { get; }

        public string ProviderName { get; }
    }
}