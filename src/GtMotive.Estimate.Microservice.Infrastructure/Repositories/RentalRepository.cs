using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rental;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : MongoRepository<Rental>, IRentalRepository
    {
        private readonly IMongoCollection<Rental> _dbContext;

        public RentalRepository(IMongoService mongoService)
            : base(mongoService)
        {
            if (mongoService == null)
            {
                throw new ArgumentNullException(string.Empty);
            }

            _dbContext = mongoService.MongoClient.GetDatabase("GTMotive").GetCollection<Rental>("Rentals");
        }

        public async Task AddAsync(Rental rental)
        {
            await _dbContext.InsertOneAsync(rental);
        }

        public async Task<List<Rental>> GetAllAsync() => await _dbContext.Find(x => true).ToListAsync();

        public async Task<Rental> GetActiveRentalByCustomer(string customerId)
        {
            return await _dbContext.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public async Task Update(Rental rental)
        {
            if (rental is not null)
            {
                var filter = Builders<Rental>.Filter.Eq("Id", rental.Id);

                var update = Builders<Rental>.Update
                    .Set(x => x.StartDate, rental.StartDate)
                    .Set(x => x.EndDate, rental.EndDate)
                    .Set(x => x.ModifiedAt, DateTime.Now)
                    .Set(x => x.Comment, rental.Comment)
                    .Set(x => x.VehicleId, rental.VehicleId)
                    .Set(x => x.CustomerId, rental.CustomerId);
                await _dbContext.UpdateOneAsync(filter, update);
            }

            return;
        }

        public async Task<List<Rental>> GetScheduledRentalsByVehicle(string vehicleId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Find(x => x.VehicleId == vehicleId && x.StartDate >= startDate && x.EndDate <= endDate).ToListAsync();
        }
    }
}
