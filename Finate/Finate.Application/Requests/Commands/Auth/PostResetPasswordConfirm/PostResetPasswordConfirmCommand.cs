using MediatR;

namespace Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommand : IRequest<PostResetPasswordConfirmResponse>
{
    public string Email { get; set; } = default!;
    
    public string UserResetPasswordToken { get; set; } = default!;

    public string NewPassword { get; set; } = default!;
}