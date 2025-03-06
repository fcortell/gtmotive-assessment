using System;
using GtMotive.Estimate.Microservice.Domain.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Factories
{
    public static class RentalFactory
    {
        public static Vehicle.Vehicle Create(VehicleDto vehicleDto)
        {
            return vehicleDto == null
                ? throw new ArgumentNullException(nameof(vehicleDto))
                : new Vehicle.Vehicle
                {
                    Brand = vehicleDto.Brand,
                    Model = vehicleDto.Model,
                    LicensePlate = vehicleDto.LicensePlate,
                    Color = vehicleDto.Color,
                    Year = vehicleDto.Year,
                    Description = vehicleDto.Description,
                    PricePerDay = vehicleDto.PricePerDay,
                    IsAvailable = vehicleDto.IsAvailable,
                    IsDeleted = vehicleDto.IsDeleted,
                    CreatedBy = vehicleDto.CreatedBy
                };
        }

        public static VehicleDto CreateDto(Vehicle.Vehicle vehicle)
        {
            return vehicle == null
                ? throw new ArgumentNullException(nameof(vehicle))
                : new VehicleDto
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    LicensePlate = vehicle.LicensePlate,
                    Color = vehicle.Color,
                    Year = vehicle.Year,
                    Description = vehicle.Description,
                    PricePerDay = vehicle.PricePerDay,
                    IsAvailable = vehicle.IsAvailable,
                    IsDeleted = vehicle.IsDeleted,
                    CreatedBy = vehicle.CreatedBy
                };
        }
    }
}
