using CarAuctionApi.Infrastructure;
using CarAuctionApi.Services.Models;

namespace CarAuctionApi.Services;

public class AuctionService(InventoryService inventoryService)
{
    private readonly List<Auction> auctions = [];

    public readonly InventoryService inventoryService = inventoryService;

    /// <summary>
    /// Starts the auction for given vehicle
    /// </summary>
    /// <param name="vehicleId">vehicle id</param>
    public EndpointResult StartAuction(int vehicleId)
    {
        if (inventoryService.GetVehicle(vehicleId) is null)
            return new EndpointResult($"Vehicle {vehicleId} does not exist");

        if (auctions.Any(x => x.VehicleId == vehicleId && x.Status == AuctionStatus.Started))
            return new EndpointResult($"Vehicle {vehicleId} already has an ongoing auction");

        var auction = new Auction() { VehicleId = vehicleId, Status = AuctionStatus.Started };

        auctions.Add(auction);

        return new EndpointResult();
    }

    /// <summary>
    /// Places a bid at an auction for a particular vehicle
    /// </summary>
    /// <param name="vehicleId">vehicle id</param>
    /// <param name="bid">bid</param>
    public EndpointResult PlaceBid(int vehicleId, decimal bid)
    {
        var vehicle = inventoryService.GetVehicle(vehicleId);

        if (vehicle is null)
            return new EndpointResult($"Vehicle {vehicleId} does not exist");

        if (!auctions.Any(x => x.VehicleId == vehicleId && x.Status == AuctionStatus.Started))
            return new EndpointResult($"Vehicle {vehicleId} does not have an ongoing auction");

        var auction = auctions.First(x => x.VehicleId == vehicleId && x.Status == AuctionStatus.Started);

        if(auction.Bid >= bid)
            return new EndpointResult($"Your bid for the vehicle {vehicleId} is invalid");

        if (vehicle.StartingBid >= bid)
            return new EndpointResult($"Your bid for the vehicle {vehicleId} is lower than the starting bid");

        auction.Bid = bid;

        return new EndpointResult();
    }

    /// <summary>
    /// Closes the auction for a particular vehicle
    /// </summary>
    /// <param name="vehicleId">vehicle id</param>
    /// <param name="bid">bid</param>
    public EndpointResult CloseAuction(int vehicleId)
    {
        if (inventoryService.GetVehicle(vehicleId) is null)
            return new EndpointResult($"Vehicle {vehicleId} does not exist");

        var auction = auctions.FirstOrDefault(x => x.VehicleId == vehicleId && x.Status == AuctionStatus.Started);

        if (auction is null)
            return new EndpointResult($"There is no active auction for the vehicle {vehicleId}");

        auction.Status = AuctionStatus.Closed;

        return new EndpointResult();
    }
}
