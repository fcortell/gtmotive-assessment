using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle
{
    public class RegisterVehicleCommandValidator : AbstractValidator<RegisterVehicleCommand>
    {
        public RegisterVehicleCommandValidator()
        {
            RuleFor(x => x.Brand).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.LicensePlate).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.PricePerDay).NotEmpty();
        }
    }
}
