using MongoDB.Bson;
using Multi_Planner.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Planner.Services.Interfaces
{
    public interface IMongoService
    {
        Task<bool> InsertItem(string collectionName, BsonDocument document);
    }
}
