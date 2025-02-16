using CarAuctionApi.Dtos;
using CarAuctionApi.Services;

namespace CarAuctionApi.Tests.UnitTests;

public class AuctionServiceTests
{
    private readonly InventoryService seededInventoryService;

    public AuctionServiceTests()
    {
        seededInventoryService = new InventoryService();
        seededInventoryService.AddVehicle(new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
        });
    }

    [Fact]
    public void Should_Successed_WhenValidVehicleForAuction()
    {
        var service = new AuctionService(seededInventoryService);

        var result = service.StartAuction(1);

        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Should_Fail_WhenAuctionAlreadyStarted()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);

        var result = service.StartAuction(1);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 1 already is in a ongoing auction", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenVehicleDoesNotExistStartAuction()
    {
        var inventoryService = new InventoryService();
        var service = new AuctionService(inventoryService);

        var result = service.StartAuction(1);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 1 does not exist", result.Errors);
    }

    [Fact]
    public void Should_Successed_WhenPlacingValidBidInActiveAuction()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);

        var result = service.PlaceBid(1, 21000);

        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Should_Fail_WhenVehicleDoesNotExistPlaceBid()
    {
        var service = new AuctionService(seededInventoryService);

        var result = service.PlaceBid(10, 30000);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 10 does not exist", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenPlacingLowerBidThenVehicleStartingBid()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);

        var result = service.PlaceBid(1, 19000);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Your bid for the the vehicle 1 is lower than the starting bid", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenPlacingLowerBidThenCurrentBid()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);
        service.PlaceBid(1, 21000);

        var result = service.PlaceBid(1, 20500);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Your bid for the the vehicle 1 is invalid", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenPlacingBidInClosedAuction()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);
        service.CloseAuction(1);

        var result = service.PlaceBid(1, 20500);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 1 does not have a ongoing auction", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenPlacingBidInNoneExistantAuction()
    {
        var service = new AuctionService(seededInventoryService);

        var result = service.PlaceBid(1, 20500);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 1 does not have a ongoing auction", result.Errors);
    }

    [Fact]
    public void Should_Successed_WhenClosingActiveAuction()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);

        var result = service.CloseAuction(1);

        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Should_Fail_WhenVehicleDoesNotExistCloseAuction()
    {
        var service = new AuctionService(seededInventoryService);
        service.StartAuction(1);

        var result = service.CloseAuction(10);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("Vehicle 10 does not exist", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenActionDoesNotExist()
    {
        var service = new AuctionService(seededInventoryService);

        var result = service.CloseAuction(1);

        Assert.NotEmpty(result.Errors);
        Assert.False(result.IsValid);
        Assert.Contains("There is no active auction for the vehicle 1", result.Errors);
    }
}
