using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostLogin;

public class PostLoginRequest
{
    public PostLoginRequest(PostLoginRequest? request)
    {
        if (request is null) return;
        
        Email = request.Email;
        Password = request.Password;
        RememberMe = request.RememberMe;
    }
    
    public PostLoginRequest()
    {
    }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}