using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Base;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Shared;

namespace tortuga.MongoData.Entities.Service
{
    public class ConnectionHandler<T> where T : IMongoEntity
    {
        public IMongoCollection<T> MongoCollection { get; set; }

        public ConnectionHandler()
        {
            const string connectionString = "mongodb:localhost";

            var mongoClient = new MongoClient(connectionString);

            var db = mongoClient.GetDatabase("tortugadb");

            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}
