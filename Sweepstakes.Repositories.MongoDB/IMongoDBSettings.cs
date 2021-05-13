using System;

namespace Sweepstakes.Repositories.MongoDB
{
    public interface IMongoDBSettings
    {
        string SweepstakesCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
