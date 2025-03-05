using GtMotive.Estimate.Microservice.Domain.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : MongoRepository<Vehicle>, IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository(IMongoService mongoClient)
            : base(mongoClient)
        {
            _vehicles = mongoClient.MongoClient.GetDatabase("GTMotive").GetCollection<Vehicle>("Vehicles");
        }

        public bool MarkVehicleAsAvailable(string id)
        {
            return _vehicles.UpdateOne(v => v.Id == id, Builders<Vehicle>.Update.Set(v => v.IsAvailable, true)).IsAcknowledged;
        }

        public bool MarkVehicleAsRented(string id)
        {
            return _vehicles.UpdateOne(v => v.Id == id, Builders<Vehicle>.Update.Set(v => v.IsAvailable, false)).IsAcknowledged;
        }
    }
}
