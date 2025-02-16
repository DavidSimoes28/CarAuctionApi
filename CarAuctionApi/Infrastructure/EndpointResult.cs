using FluentValidation.Results;

namespace CarAuctionApi.Infrastructure;

public class EndpointResult
{
    public bool IsValid { get => Errors.Count == 0; }
    public List<string> Errors { get; set; } = [];

    public EndpointResult() { }

    public EndpointResult(string error)
    {
        Errors.Add(error);
    }

    public EndpointResult(List<ValidationFailure> errors)
    {
        Errors.AddRange(errors.Select(x => x.ErrorMessage));
    }
}

public class EndpointResult<T> : EndpointResult
{
    public T? Result { get; set; }

    public EndpointResult() : base() { }

    public EndpointResult(T result)
    {
        Result = result;
    }

    public EndpointResult(string error) : base(error) { }

    public EndpointResult(List<ValidationFailure> errors) : base(errors) { }
}
