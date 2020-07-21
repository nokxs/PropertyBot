using System;
using System.Collections.Generic;

namespace Crawler.Interface
{
    public class Property
    {
        public Property(string id, string description, Uri image, DateTime addDate, int price, IDictionary<string, string> additionalDetails, Uri details)
        {
            Id = id;
            Description = description;
            Image = image;
            AddDate = addDate;
            Price = price;
            AdditionalDetails = additionalDetails;
            Details = details;
        }

        public string Id { get; }

        public Uri Image { get; }

        public string Description { get; }

        public DateTime AddDate { get; }

        public int Price { get; }

        public Uri Details { get; }

        public IDictionary<string, string> AdditionalDetails { get;  }
    }
}