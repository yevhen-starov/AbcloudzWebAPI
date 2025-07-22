using ErrorOr;

namespace AbcloudzWebAPI.Domain.Errors;

public static class UserErrors
{
    public static Error Null => Error.Validation("User is null", "User cannot be null.");
    public static Error InvalidEmail => Error.Validation("User Invalid Email", "Email is required.");
    public static Error CreateFailed (string details) => Error.Failure("User Created failed", $"Could not create user: {details}");
}
