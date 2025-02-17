using CarAuctionApi.Dtos;

namespace CarAuctionApi.Services.Models;

public class Hatchback(int id, string model, string manufacturer, int year, decimal startingBid, int doorNumber)
    : VehicleWithDoors(id, model, manufacturer, year, startingBid, doorNumber)
{
    public override VehicleDto ToDto() => new()
    {
        Id = Id,
        Manufacturer = Manufacturer,
        Model = Model,
        Year = Year,
        StartingBid = StartingBid,
        DoorNumber = DoorNumber
    };
}
