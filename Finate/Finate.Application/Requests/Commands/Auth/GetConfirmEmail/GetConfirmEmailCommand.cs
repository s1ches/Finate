using MediatR;

namespace Finate.Application.Requests.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommand : IRequest<GetConfirmEmailResponse>
{
    public string Email { get; set; } = default!;
    
    public string UserConfirmEmailToken { get; set; } = default!;
}