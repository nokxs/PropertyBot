using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using PropertyBot.Interface;
using PropertyBot.Common.Extensions;

namespace PropertyBot.Persistence.MongoDB
{
    public class MongoDbSenderDataProvider : ISenderDataProvider
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public void Init()
        {
            var user = EnvironmentConstants.MONGO_DB_USER.GetAsMandatoryEnvironmentVariable();
            var password = EnvironmentConstants.MONGO_DB_PASSWORD.GetAsMandatoryEnvironmentVariable();

            _client = new MongoClient($"mongodb://{user}:{password}@mongo");
            _database = _client.GetDatabase("propertyCrawler");

            var pack = new ConventionPack {new IgnoreExtraElementsConvention(true)};
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public Task Add<TUser>(TUser user)
        {
            var collection = GetCollection<TUser>(user.GetType());
            return collection.InsertOneAsync(user);
        }

        public IEnumerable<TUser> GetAll<TUser>()
        {
            var collection = GetCollection<TUser>(typeof(TUser));
            return collection.Find(FilterDefinition<TUser>.Empty).ToList();
        }

        public bool Contains<TUser>(Func<TUser, bool> compareFunc)
        {
            //var collection = GetCollection<TUser>(typeof(TUser));
            ////var filter = Builders<TUser>.Filter.Exists(user => compareFunc(user));
            //var allUsers = collection.Find(FilterDefinition<TUser>.Empty).ToList();
            var allUsers = GetAll<TUser>();
            return allUsers.Any(compareFunc);
        }

        private IMongoCollection<TUser> GetCollection<TUser>(Type user)
        {
            return _database.GetCollection<TUser>(user.FullName);
        }
    }
}
