namespace Finate.Application.Requests.Commands.Auth.PostConfirmEmail;

public class PostConfirmEmailResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = [];
}