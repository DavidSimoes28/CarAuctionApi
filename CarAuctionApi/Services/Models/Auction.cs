namespace CarAuctionApi.Services.Models;

public class Auction
{
    public int VehicleId { get; set; }
    public decimal Bid { get; set; }
    public AuctionStatus Status { get; set; }
}
