using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sweepstakes.Entities;
using System;
using System.Collections.Generic;

namespace Sweepstakes.Repositories.MongoDB
{
    public sealed class SweepstakeRepository : ISweepstakeRepository
    {
        private readonly IMongoCollection<Sweepstake> collection;

        public SweepstakeRepository(IOptions<MongoDBSettings> options)
        {
            IMongoDBSettings settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            collection = database.GetCollection<Sweepstake>(settings.SweepstakesCollectionName);
        }

        public Sweepstake Get(string sweepstakeId)
        {
            return collection.Find(s => s.Id == sweepstakeId).FirstOrDefault();
        }

        public IEnumerable<Sweepstake> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }

        public void Insert(Sweepstake sweepstake)
        {
            collection.InsertOne(sweepstake);
        }

        public void Update(Sweepstake sweepstake)
        {
            collection.ReplaceOne(s=> s.Id == sweepstake.Id, sweepstake);
        }
    }
}
