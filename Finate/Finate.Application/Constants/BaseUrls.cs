namespace Finate.Application.Constants;

public static class BaseUrls
{
    public static string ConfirmEmailLink(string confirmToken, string email)
        => $"https://localhost:44383/Auth/ConfirmEmail?confirmToken={confirmToken}&email={email}";
    
    public static string ConfirmPasswordResetLink(string confirmToken, string email)
        => $"https://localhost:44383/Auth/ResetPasswordConfirm?confirmToken={confirmToken}&email={email}";
}