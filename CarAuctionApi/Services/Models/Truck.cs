namespace CarAuctionApi.Services.Models;

public class Truck(int id, string model, string manufacturer, int year, decimal startingBid, int loadCapacity) 
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int LoadCapacity { get; set; } = loadCapacity;
}
