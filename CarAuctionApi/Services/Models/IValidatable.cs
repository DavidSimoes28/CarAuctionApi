using FluentValidation.Results;

namespace CarAuctionApi.Services.Models;

public interface IValidatable
{
    public ValidationResult Validate();
}
