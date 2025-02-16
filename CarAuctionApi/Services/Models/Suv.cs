namespace CarAuctionApi.Services.Models;

public class Suv(int id, string model, string manufacturer, int year, decimal startingBid, int seatNumber)
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int SeatNumber { get; set; } = seatNumber;
}
