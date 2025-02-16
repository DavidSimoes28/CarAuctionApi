using CarAuctionApi.Dtos;
using CarAuctionApi.Tests.IntegrationTests.Abstractions;
using System.Net;
using System.Net.Http.Json;

namespace CarAuctionApi.Tests.IntegrationTests;

public class AuctionEndpointsTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : BaseIntegrationTest(integrationTestWebAppFactory)
{
    [Fact]
    public async Task Shoud_ReturnOk_WhenStartValidAuction()
    {
        var input = new VehicleDto
        {
            Id = 100,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        await httpClient.PostAsJsonAsync("api/vehicles", input);

        var response = await httpClient.PostAsJsonAsync($"api/auctions/start", new AuctionDto { VehicleId = input.Id });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnBadResquest_WhenStartInvalidAuction()
    {
        var response = await httpClient.PostAsJsonAsync($"api/auctions/start", new AuctionDto { VehicleId = -1 });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnOk_WhenPlaceBidInValidAuction()
    {
        var input = new VehicleDto
        {
            Id = 101,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        await httpClient.PostAsJsonAsync("api/vehicles", input);
        await httpClient.PostAsJsonAsync($"api/auctions/start", new AuctionDto { VehicleId = input.Id });

        var response = await httpClient.PatchAsJsonAsync(
            $"api/auctions/place-bid",
            new AuctionPlaceBidDto { VehicleId = input.Id, Bid = 30000 }
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnBadRequest_WhenPlaceBidInInvalidAuction()
    {
        var response = await httpClient.PatchAsJsonAsync(
            $"api/auctions/place-bid", 
            new AuctionPlaceBidDto { VehicleId = -1, Bid = 30000 }
        );

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnOk_WhenClosingValidAuction()
    {
        var input = new VehicleDto
        {
            Id = 102,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        await httpClient.PostAsJsonAsync("api/vehicles", input);
        await httpClient.PostAsJsonAsync($"api/auctions/start", new AuctionDto { VehicleId = input.Id });

        var response = await httpClient.PatchAsJsonAsync($"api/auctions/close", new AuctionDto { VehicleId = input.Id });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnBadRequest_WhenClosingInvalidAuction()
    {
        var response = await httpClient.PatchAsJsonAsync($"api/auctions/close", new AuctionDto { VehicleId = -1 });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
