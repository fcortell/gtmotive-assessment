using System;
using GtMotive.Estimate.Microservice.Domain.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle.Vehicle Create(VehicleDto vehicleDto)
        {
            return vehicleDto == null
                ? throw new ArgumentNullException(nameof(vehicleDto))
                : new Vehicle.Vehicle
                {
                    Id = vehicleDto.Id,
                    Brand = vehicleDto.Brand,
                    Model = vehicleDto.Model,
                    Year = vehicleDto.Year,
                    LicensePlate = vehicleDto.LicensePlate,
                    Color = vehicleDto.Color,
                };
        }

        public static VehicleDto CreateDto(Vehicle.Vehicle vehicle)
        {
            return vehicle == null
                ? throw new ArgumentNullException(nameof(vehicle))
                : new VehicleDto
                {
                    Id = vehicle.Id,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    LicensePlate = vehicle.LicensePlate,
                    Color = vehicle.Color
                };
        }
    }
}
