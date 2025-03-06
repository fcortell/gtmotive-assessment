using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Newtonsoft.Json;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public class RegisterVehicleTests : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        private readonly HttpClient _client;

        public RegisterVehicleTests(GenericInfrastructureTestServerFixture fixture)
        {
            if (fixture is null)
            {
                throw new ArgumentNullException(nameof(fixture));
            }

            _client = fixture.Server.CreateClient();
        }

        [Fact]
        public async Task RegisterVehicleShouldReturnSuccessStatusCode()
        {
            // Arrange
            var vehicle = new RegisterVehicleInput
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2021,
                PricePerDay = 10,
                Color = "Black",
                LicensePlate = "A888EK"
            };

            using var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");
            var uri = new Uri("/api/Vehicle/RegisterVehicle", UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task RegisterVehicleShouldReturnBadRequestStatusCodeForOldVehicle()
        {
            // Arrange
            var vehicle = new RegisterVehicleInput
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2015,
                PricePerDay = 10,
                Color = "Black",
                LicensePlate = "A888EK"
            };

            using var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");
            var uri = new Uri("/api/Vehicle/RegisterVehicle", UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task RegisterVehicleShouldReturnBadRequestForInvalidData()
        {
            // Arrange
            var vehicle = new RegisterVehicleInput
            {
                Brand = null,
                Model = "Corolla",
                Year = 2021,
                PricePerDay = 10,
                Color = "Black",
                LicensePlate = "A888EK"
            };

            using var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");
            var uri = new Uri("/api/Vehicle/RegisterVehicle", UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
