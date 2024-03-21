using MediatR;

namespace Finate.Application.Requests.Commands.Auth.PostRegister;

public class PostRegisterCommand : IRequest<PostRegisterResponse>
{
    public string Role { get; set; } = default!;

    public string UserName { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public string Password { get; set; } = default!;
    
    public string PasswordConfirm { get; set; } = default!;
}