using CarAuctionApi.Tests.IntegrationTests.Abstractions;

namespace CarAuctionApi.Tests.IntegrationTests;

public class BaseIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory) : IClassFixture<IntegrationTestWebAppFactory>
{
    protected HttpClient httpClient { get; init; } = integrationTestWebAppFactory.CreateClient();
}
