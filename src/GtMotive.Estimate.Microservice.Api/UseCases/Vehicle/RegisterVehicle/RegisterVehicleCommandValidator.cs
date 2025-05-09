﻿using System;
using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle
{
    public class RegisterVehicleCommandValidator : AbstractValidator<RegisterVehicleCommand>
    {
        public RegisterVehicleCommandValidator()
        {
            RuleFor(x => x.Brand).NotEmpty().NotNull();
            RuleFor(x => x.Model).NotEmpty().NotNull();
            RuleFor(x => x.LicensePlate).NotEmpty();
            RuleFor(x => x.Year).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Year - 5); // Not older than 5 years
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.PricePerDay).NotEmpty();
        }
    }
}
