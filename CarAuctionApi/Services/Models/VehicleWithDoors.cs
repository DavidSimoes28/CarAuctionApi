using CarAuctionApi.Services.Validators;
using FluentValidation.Results;

namespace CarAuctionApi.Services.Models;

public abstract class VehicleWithDoors(int id, string model, string manufacturer, int year, decimal startingBid, int doorNumber) 
    : Vehicle(id, model, manufacturer, year, startingBid)
{
    public int DoorNumber { get; set; } = doorNumber;

    public override ValidationResult Validate() => new VehicleWithDoorsValidator().Validate(this);
}
