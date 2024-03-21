namespace Finate.Application.Constants;

public static class AuthErrorMessages
{
    public const string UserWithThisEmailNotFound = "Wrong email";

    public const string WrongPassword = "Wrong password";

    public const string PasswordIsNotConfirmed = "Password and Password Confirm must be equals";

    public const string UserWithSameEmailAlreadyExist = "User with same Email already exist";

    public static string EmptyField(string fieldName) => $"{fieldName} can not be empty";
}