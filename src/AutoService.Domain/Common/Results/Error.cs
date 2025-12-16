namespace AutoService.Domain.Common.Results;
/// <summary>
/// Immutable value-type representing a domain error for the Result pattern.
/// Use the provided static factory methods (e.g. NotFound, Validation) to create instances;
/// instances compare by value (record semantics). Note: <c>default(Error)</c> yields null/zero properties.
/// </summary>
public readonly record struct Error
{
    private Error(string code, string description, ErrorKind type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    public string Code { get; }
    public string Description { get; }
    public ErrorKind Type { get; }

    public static Error Create(string code, string description, ErrorKind type)
    => new Error(code, description, type);

    public static Error Failure(string code = "Failure", string description = "General failure")
    => new Error(code, description, ErrorKind.Failure);

    public static Error NotFound(string code = "NotFound", string description = "Resource not found")
    => new Error(code, description, ErrorKind.NotFound);

    public static Error Conflict(string code = "Conflict", string description = "Resource conflict")
    => new Error(code, description, ErrorKind.Conflict);

    public static Error Validation(string code = "Validation", string description = "Validation error")
    => new Error(code, description, ErrorKind.Validation);

    public static Error Unauthorized(string code = "Unauthorized", string description = "Unauthorized access")
    => new Error(code, description, ErrorKind.Unauthorized);

    public static Error Forbidden(string code = "Forbidden", string description = "Forbidden access")
    => new Error(code, description, ErrorKind.Forbidden);

    public static Error Internal(string code = "Internal", string description = "Internal server error")
    => new Error(code, description, ErrorKind.Internal);

    public static Error Unexpected(string code = "Unexpected", string description = "Unexpected error")
    => new Error(code, description, ErrorKind.Unexpected);

}