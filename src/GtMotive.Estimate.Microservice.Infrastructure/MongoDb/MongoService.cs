using System;
using GtMotive.Estimate.Microservice.Domain.Rental;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService : IMongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            MongoClient = new MongoClient(options.Value.ConnectionString);

            RegisterBsonClasses();
        }

        public MongoClient MongoClient { get; }

        private static void RegisterBsonClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(x =>
                {
                    x.AutoMap();
                    x.MapIdMember(y => y.Id).SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId));
                    x.MapProperty(y => y.LicensePlate).SetIsRequired(true);
                    x.MapProperty(y => y.Model).SetIsRequired(true);
                    x.MapProperty(y => y.Brand).SetIsRequired(true);
                    x.MapProperty(y => y.PricePerDay).SetIsRequired(true);
                    x.MapProperty(y => y.Year).SetIsRequired(true);
                    x.MapProperty(y => y.Color).SetIsRequired(true);
                    x.MapProperty(y => y.CreatedAt).SetIsRequired(true).SetDefaultValue(DateTime.Now);
                    x.MapProperty(y => y.CreatedBy).SetIsRequired(true);
                    x.MapProperty(y => y.ModifiedBy).SetIsRequired(true);
                    x.MapProperty(y => y.Description).SetIsRequired(false);
                    x.MapProperty(y => y.IsDeleted).SetIsRequired(true).SetDefaultValue(false);
                    x.MapProperty(y => y.IsAvailable).SetIsRequired(true).SetDefaultValue(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Rental)))
            {
                BsonClassMap.RegisterClassMap<Rental>(x =>
                {
                    x.AutoMap();
                    x.MapIdProperty(y => y.Id).SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId));
                    x.MapProperty(y => y.VehicleId).SetIsRequired(true).SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId));
                    x.MapProperty(y => y.CustomerId).SetIsRequired(true);
                    x.MapProperty(y => y.StartDate).SetIsRequired(true).SetDefaultValue(DateTime.Now);
                    x.MapProperty(y => y.ModifiedAt).SetIsRequired(true);
                    x.MapProperty(y => y.CreatedAt).SetIsRequired(true).SetDefaultValue(DateTime.Now);
                    x.MapProperty(y => y.EndDate).SetIsRequired(false).SetIgnoreIfNull(true);
                    x.MapProperty(y => y.Comment).SetIgnoreIfNull(true);
                });
            }
        }
    }
}
