using MediatR;

namespace Finate.Application.Requests.Commands.Auth.PostConfirmEmail;

public class GetConfirmEmailCommand : IRequest<GetConfirmEmailResponse>
{
    public string Email { get; set; } = default!;
    
    public string UserConfirmEmailToken { get; set; } = default!;
}