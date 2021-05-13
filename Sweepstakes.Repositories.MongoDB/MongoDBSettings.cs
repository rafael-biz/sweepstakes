using Sweepstakes.Repositories.MongoDB;

namespace Sweepstakes.Repositories
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string SweepstakesCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
