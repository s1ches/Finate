using MediatR;

namespace Finate.Application.Requests.Commands.Auth.PostLogin;

public class PostLoginCommand : IRequest<PostLoginResponse>
{
    public string Email { get; set; } = default!;
    
    public string Password { get; set; } = default!;

    public bool RememberMe { get; set; } = default!;
}