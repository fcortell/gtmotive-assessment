namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle
{
    /// <summary>
    /// Represents the output data for the Rent Vehicle use case.
    /// </summary>
    public class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">The identifier of the rental.</param>
        public RentVehicleOutput(string rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets or sets the identifier of the rent.
        /// </summary>
        public string RentalId { get; set; }
    }
}
