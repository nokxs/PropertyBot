using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PropertyBot.Common.Extensions;
using PropertyBot.Interface;

namespace PropertyBot.Persistence.MongoDB
{
    public class MongoDbPropertyDataProvider : IPropertyDataProvider
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Property> _collection;

        public void Init()
        {
            var user = EnvironmentConstants.MONGO_DB_USER.GetAsMandatoryEnvironmentVariable();
            var password = EnvironmentConstants.MONGO_DB_PASSWORD.GetAsMandatoryEnvironmentVariable();

            _client = new MongoClient($"mongodb://{user}:{password}@mongo");
            _database = _client.GetDatabase("propertyCrawler");
            _collection = _database.GetCollection<Property>("properties");
        }

        public bool Contains(Property property)
        {
            return _collection.Find(prop => prop.Id == property.Id)?.Any() ?? false;
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
