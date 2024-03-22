namespace Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = [];
}