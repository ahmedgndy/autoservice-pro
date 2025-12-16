namespace AutoService.Domain.Common.Results;


public interface IResult
{
    bool IsSuccess { get; }
    List<Error>? Error { get; }
}

public interface IResult<out TValue> : IResult
{
    TValue? Value { get; }
}