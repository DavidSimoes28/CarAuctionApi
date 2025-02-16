using Microsoft.AspNetCore.Mvc;

namespace CarAuctionApi.Infrastructure;

public static class EndpointExtensions
{
    public static ProblemDetails ToProblemDetails(this EndpointResult result)
    {
        var problem = new ProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation failed",
            Detail = "One or more errors occurred"
        };

        problem.Extensions.Add("errors", result.Errors);

        return problem;
    }
}
