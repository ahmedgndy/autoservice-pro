namespace AutoService.Domain.Common.Results;

public enum ErrorKind
{
    Failure,
    Unexpected,
    NotFound,
    Conflict,
    Validation,
    Unauthorized,
    Forbidden,
    Internal
}
