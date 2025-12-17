using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
namespace AutoService.Domain.Common.Results;

public static class Result
{
    public static Success Success => default;
    public static Created Created => default;
    public static Deleted Deleted => default;
    public static Updated Updated => default;
}

public sealed class Result<TValue> : IResult<TValue>
{

    private readonly List<Error>? _errors = null;
    private readonly TValue? _value = default;

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;

    public List<Error>? Errors => IsError ? _errors! : [];
    public TValue? Value => IsSuccess ? _value : default;
    public Error TopError => (_errors?.Count > 0) ? _errors[0] : default;

    private Result(Error error)
    {
        _errors = [error];
    }

    private Result(List<Error> errors)
    {
        if (errors == null || errors.Count == 0)
            throw new ArgumentException("cannot  create an empty or null errors list, provide at least one error", nameof(errors));
        _errors = errors.ToList();
        IsSuccess = false;
    }

    private Result(TValue value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Cannot create a successful Result with a null value.");
        IsSuccess = true;
        _value = value;
    }

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serialization only", true)]
    public Result(bool isSuccess, List<Error>? error, TValue? value)
    {
        if (isSuccess)
        {
            _Value = value ?? throw new ArgumentNullException(nameof(value), "Cannot create a successful Result with a null value.");
            _Error = [];
            IsSuccess = true;
        }
        else
        {
            if (error == null || error.Count == 0)
                throw new ArgumentException("cannot  create an empty or null errors list, provide at least one error", nameof(error));
            _Error = error.ToList();
            _Value = default!;
            IsSuccess = false;
        }

    }

    public TNextValue? Match<TNextValue>(
           Func<TValue, TNextValue> onSuccess,
           Func<List<Error>, TNextValue> onFailure)
   => IsSuccess
       ? onSuccess(_value!)
       : onFailure(_errors!);

    public static implicit operator Result<TValue>(TValue value)
    {
        return new(value);
    }

    public static implicit operator Result<TValue>(Error error)
        => new(error);
    public static implicit operator Result<TValue>(List<Error> errors)
        => new(errors);


    public static Result<TValue> Success(TValue value)
        => new Result<TValue>(value);

    public static Result<TValue> Failure(List<Error> errors)
        => new Result<TValue>(errors);

    public static Result<TValue> Failure(Error error)
        => new Result<TValue>(new List<Error> { error });


}

public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;