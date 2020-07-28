using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Interface;
using MongoDB.Driver;

namespace Crawler.Persistence.MongoDB
{
    public class MongoDbDataProvider : IDataProvider
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Property> _collection;

        public void Init()
        {
            _client = new MongoClient("mongodb://mongo:27017"); // TODO: Do not hard code
            _database = _client.GetDatabase("property-crawler");
            _collection = _database.GetCollection<Property>("properties");
        }

        public Task<bool> Contains(Property property)
        {
            return _collection.Find(prop => prop.Id == property.Id).AnyAsync();
        }

        public Task Add(Property property)
        {
            return _collection.InsertOneAsync(property);
        }

        public Task AddMany(IEnumerable<Property> properties)
        {
            return _collection.InsertManyAsync(properties);
        }
    }
}
