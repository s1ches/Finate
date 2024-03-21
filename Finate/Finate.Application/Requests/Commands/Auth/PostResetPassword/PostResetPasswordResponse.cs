namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = [];
}