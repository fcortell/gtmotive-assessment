using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    public abstract class InfrastructureTestBase
    {
        protected InfrastructureTestBase(GenericInfrastructureTestServerFixture fixture)
        {
            Fixture = fixture;
        }

        protected GenericInfrastructureTestServerFixture Fixture { get; }
    }
}
