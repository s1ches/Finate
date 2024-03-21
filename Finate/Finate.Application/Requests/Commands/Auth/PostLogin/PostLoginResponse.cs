namespace Finate.Application.Requests.Commands.Auth.PostLogin;

public class PostLoginResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = [];
}