namespace CarAuctionApi.Services.Models;

public class Suv(int id, string model, string manufacturer, int year, decimal startingBid, int seetNumber)
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int SeetNumber { get; set; } = seetNumber;
}
