using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;

namespace Multi_Planner.Services.Services
{

    public class MongoService
    {
        //TODO Hide Somewhere
        readonly string ConnectionString = "mongodb://127.0.0.1:27017/?gssapiServiceName=mongodb";

        public MongoService()
        {
            var mongoClient = new MongoClient("mongodb://127.0.0.1:27017/?gssapiServiceName=mongodb");
            var database = mongoClient.GetDatabase("Multi-Planner-DB");
            var collection = database.GetCollection<BsonDocument>("Users");

            var document = new BsonDocument()
                {
                    { "Name", "Test" },
                    { "qty", 100 },
                    { "tags", new BsonArray { "cotton" } },
                    { "size", new BsonDocument { { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } }
                };

            collection.InsertOne(document);
        }

        public void saveUser()
        {

        }

    }
}
