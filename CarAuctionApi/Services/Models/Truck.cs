using CarAuctionApi.Dtos;
using CarAuctionApi.Services.Validators;
using FluentValidation.Results;

namespace CarAuctionApi.Services.Models;

public class Truck(int id, string model, string manufacturer, int year, decimal startingBid, int loadCapacity) 
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int LoadCapacity { get; set; } = loadCapacity;

    public override ValidationResult Validate() => new TruckValidator().Validate(this);

    public override VehicleDto ToDto() => new()
    {
        Id = Id,
        Manufacturer = Manufacturer,
        Model = Model,
        Year = Year,
        StartingBid = StartingBid,
        LoadCapacity = LoadCapacity
    };
}
