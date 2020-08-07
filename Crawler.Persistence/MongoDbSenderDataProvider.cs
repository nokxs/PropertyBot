using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Crawler.Interface;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Crawler.Persistence.MongoDB
{
    public class MongoDbSenderDataProvider : ISenderDataProvider
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public void Init()
        {
            _client = new MongoClient("mongodb://crawler:crawlerPassword@mongo"); // TODO: Do not hard code
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
