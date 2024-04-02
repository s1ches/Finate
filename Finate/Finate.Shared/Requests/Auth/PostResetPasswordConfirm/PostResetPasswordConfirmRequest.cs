using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmRequest
{
    public PostResetPasswordConfirmRequest(PostResetPasswordConfirmRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
        UserResetPasswordToken = request.UserResetPasswordToken;
        NewPassword = request.NewPassword;
        NewPasswordConfirm = request.NewPasswordConfirm;
    }
    
    public PostResetPasswordConfirmRequest(string email, string userResetPasswordToken)
    {
        Email = email;
        UserResetPasswordToken = userResetPasswordToken;
    }

    public PostResetPasswordConfirmRequest()
    {
    }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Required]
    public string UserResetPasswordToken { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPassword { get; set; } = default!;
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords need to be equals")]
    public string NewPasswordConfirm { get; set; } = default!;
}