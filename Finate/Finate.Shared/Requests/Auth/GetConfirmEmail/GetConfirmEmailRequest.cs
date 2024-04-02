using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.GetConfirmEmail;

public class GetConfirmEmailRequest
{
    public GetConfirmEmailRequest(GetConfirmEmailRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
        UserConfirmEmailToken = request.UserConfirmEmailToken;
    }

    public GetConfirmEmailRequest(string email, string userConfirmEmailToken)
    {
        Email = email;
        UserConfirmEmailToken = userConfirmEmailToken;
    }
    
    public GetConfirmEmailRequest()
    {
    }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
    
    [Required]
    public string UserConfirmEmailToken { get; set; } = default!;
}