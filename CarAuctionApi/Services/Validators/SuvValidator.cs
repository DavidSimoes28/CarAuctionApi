﻿using CarAuctionApi.Services.Models;
using FluentValidation;

namespace CarAuctionApi.Services.Validators;

public class SuvValidator : AbstractValidator<Suv>
{
    public SuvValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model bust not be empty");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer bust not be empty");

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("Invalid year");

        RuleFor(x => x.StartingBid)
            .GreaterThan(0).WithMessage("Invalid stating bid");

        RuleFor(x => x.SeetNumber)
            .GreaterThan(0).WithMessage("Invalid seet number");
    }
}
