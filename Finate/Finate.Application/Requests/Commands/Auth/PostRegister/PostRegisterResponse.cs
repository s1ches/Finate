namespace Finate.Application.Requests.Commands.Auth.PostRegister;

public class PostRegisterResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = default!;
}