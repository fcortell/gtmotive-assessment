using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Newtonsoft.Json;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public class RentVehicleTests : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        private readonly HttpClient _client;

        public RentVehicleTests(GenericInfrastructureTestServerFixture fixture)
        {
            if (fixture is null)
            {
                throw new ArgumentNullException(nameof(fixture));
            }

            _client = fixture.Server.CreateClient();
        }

        [Fact]
        public async Task RentVehicleShouldReturnSuccessStatusCode()
        {
            // Arrange
            var rentRequest = new RentVehicleInput
            {
                VehicleId = default(MongoDB.Bson.ObjectId).ToString(),
                PlannedStartDate = DateTime.UtcNow,
                PlannedEndDate = DateTime.UtcNow.AddDays(7),
                CustomerId = "111111P"
            };

            using var content = new StringContent(JsonConvert.SerializeObject(rentRequest), Encoding.UTF8, "application/json");
            var uri = new Uri("/api/Rental/RentVehicle", UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task RentVehicleShouldReturnBadRequestForMissingCustomerId()
        {
            // Arrange
            var rentRequest = new RentVehicleInput
            {
                VehicleId = default(MongoDB.Bson.ObjectId).ToString(),
                PlannedStartDate = DateTime.UtcNow,
                PlannedEndDate = DateTime.UtcNow.AddDays(7),
            };

            using var content = new StringContent(JsonConvert.SerializeObject(rentRequest), Encoding.UTF8, "application/json");
            var uri = new Uri("/api/Rental/RentVehicle", UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
