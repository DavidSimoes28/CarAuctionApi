using CarAuctionApi.Dtos;
using CarAuctionApi.Services.Validators;
using FluentValidation.Results;

namespace CarAuctionApi.Services.Models;

public class Suv(int id, string model, string manufacturer, int year, decimal startingBid, int seatNumber)
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int SeatNumber { get; set; } = seatNumber;

    public override ValidationResult Validate() => new SuvValidator().Validate(this);
    
    public override VehicleDto ToDto() => new()
    {
        Id = Id,
        Manufacturer = Manufacturer,
        Model = Model,
        Year = Year,
        StartingBid = StartingBid,
        SeatNumber = SeatNumber
    };
}
