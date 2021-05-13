using MongoDB.Bson.Serialization;
using Sweepstakes.Entities;
using System;

namespace Sweepstakes.Repositories.MongoDB
{
    /// <summary>
    /// Maps the application entities to BSON Documents.
    /// </summary>
    public static class EntityMapper
    {
        private static bool mapped = false;

        public static void Map()
        {
            if (mapped)
                return;
            mapped = true;

            BsonClassMap.RegisterClassMap<Sweepstake>(cm =>
            {
                cm.MapIdMember(c => c.Id);
                cm.MapMember(c => c.Name);
                cm.MapMember(c => c.Description);
                cm.MapMember(c => c.DrawDate);
                cm.MapMember(c => c.DrawnDate);
                cm.MapMember(c => c.Entrants);
                cm.MapMember(c => c.Winner);
            });
        }
    }
}
