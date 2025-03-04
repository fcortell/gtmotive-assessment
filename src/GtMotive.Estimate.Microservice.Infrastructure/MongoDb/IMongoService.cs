using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public interface IMongoService
    {
        MongoClient MongoClient { get; }
    }
}
