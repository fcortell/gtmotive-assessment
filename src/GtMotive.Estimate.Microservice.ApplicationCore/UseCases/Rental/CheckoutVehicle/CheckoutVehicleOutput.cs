namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle
{
    public class CheckoutVehicleOutput : IUseCaseOutput
    {
        public CheckoutVehicleOutput(string rentalId)
        {
            RentalId = rentalId;
        }

        public string RentalId { get; }
    }
}
