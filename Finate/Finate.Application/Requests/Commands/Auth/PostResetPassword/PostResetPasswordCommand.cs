using MediatR;

namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommand : IRequest<PostResetPasswordResponse>
{
    public string Email { get; set; } = default!;

    public string NewPassword { get; set; } = default!;

    public string NewPasswordConfirm { get; set; } = default!;
}