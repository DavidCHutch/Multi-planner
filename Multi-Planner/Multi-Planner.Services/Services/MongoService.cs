using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System.Threading.Tasks;
using log4net;

namespace Multi_Planner.Services.Services
{

    public class MongoService : IMongoService
    {
        //TODO Get from somewhere secure
        readonly string ConnectionString = "mongodb://127.0.0.1:27017/?gssapiServiceName=mongodb";
        readonly string DatabaseName = "Multi-Planner-DB";

        readonly ILog Log;
        readonly MongoClient client;
        readonly IMongoDatabase database;

        public MongoService(ILog log)
        {
            Log = log;
            client = new MongoClient(ConnectionString);
            database = client.GetDatabase(DatabaseName);
        }

        public async Task<bool> InsertItem(string collectionName, BsonDocument document)
        {
            try
            {
                Log.Info("Attepmting to insert item into " + collectionName + " in database.");

                var collection = database.GetCollection<BsonDocument>(collectionName);

                await collection.InsertOneAsync(document);

                Log.Info("Item inserted into " + collectionName + " in database.");
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("Exception while inserting item into " + collectionName + " in the database.", ex);

                return false;
            }
        }
    }

    //TODO move this somewhere else
    public class Collections
    {
        public readonly static string Users = "Users";
    }
}
