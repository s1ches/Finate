using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostRegister;

public class PostRegisterRequest
{
    public PostRegisterRequest(PostRegisterRequest? request)
    {
        if (request is null) return;

        Role = request.Role;
        UserName = request.UserName;
        Email = request.Email;
        Password = request.Password;
        PasswordConfirm = request.PasswordConfirm;
    }   
    
    public PostRegisterRequest()
    {
    }
    
    [Required]
    public string Role { get; set; } = string.Empty;

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    [Compare(nameof(Password), ErrorMessage = "Passwords need to be equals")]
    public string PasswordConfirm { get; set; } = string.Empty;
}