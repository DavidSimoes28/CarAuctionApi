namespace CarAuctionApi.Services.Models;

public class Hatchback(int id, string model, string manufacturer, int year, decimal startingBid, int doorNumber)
    : VehicleWithDoors(id, model, manufacturer, year, startingBid, doorNumber)
{
}
