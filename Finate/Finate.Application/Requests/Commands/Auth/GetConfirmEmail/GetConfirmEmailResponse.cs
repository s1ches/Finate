namespace Finate.Application.Requests.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailResponse
{
    public bool IsSuccessful { get; set; }

    public List<string> ErrorMessages { get; set; } = [];
}