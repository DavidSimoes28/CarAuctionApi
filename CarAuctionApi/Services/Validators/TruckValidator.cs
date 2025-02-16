using CarAuctionApi.Services.Models;
using FluentValidation;

namespace CarAuctionApi.Services.Validators;

public class TruckValidator : AbstractValidator<Truck>
{
    public TruckValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model must not be empty");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer must not be empty");

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("Invalid year");

        RuleFor(x => x.StartingBid)
            .GreaterThan(0).WithMessage("Invalid starting bid");

        RuleFor(x => x.LoadCapacity)
            .GreaterThan(0).WithMessage("Invalid load capacity");
    }
}
