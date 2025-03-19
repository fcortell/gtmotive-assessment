using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    [CollectionDefinition(TestCollections.TestServer)]
    public class TestServerCollectionFixture : ICollectionFixture<GenericInfrastructureTestServerFixture>
    {
    }
}
