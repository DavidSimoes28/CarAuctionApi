using CarAuctionApi.Services.Models;
using FluentValidation;

namespace CarAuctionApi.Services.Validators;

public class VehicleWithDoorsValidator : AbstractValidator<VehicleWithDoors>
{
    public VehicleWithDoorsValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model must not be empty");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer must not be empty");

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("Invalid year");

        RuleFor(x => x.StartingBid)
            .GreaterThan(0).WithMessage("Invalid starting bid");

        RuleFor(x => x.DoorNumber)
            .GreaterThan(0).WithMessage("Invalid door number");
    }
}
