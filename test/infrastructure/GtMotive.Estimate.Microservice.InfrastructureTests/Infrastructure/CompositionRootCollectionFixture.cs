using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    [CollectionDefinition(TestCollections.Functional)]
    public class CompositionRootCollectionFixture : ICollectionFixture<CompositionRootTestFixture>
    {
    }
}
