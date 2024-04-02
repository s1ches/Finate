using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostResetPassword;

public class PostResetPasswordRequest
{
    public PostResetPasswordRequest(PostResetPasswordRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
    }
    
    public PostResetPasswordRequest()
    {
    }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
}