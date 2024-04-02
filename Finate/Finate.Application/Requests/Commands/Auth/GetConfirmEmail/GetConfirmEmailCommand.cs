using MediatR;
using Shared.Requests.Auth.GetConfirmEmail;

namespace Finate.Application.Requests.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommand(GetConfirmEmailRequest? request)
    : GetConfirmEmailRequest(request),
        IRequest<GetConfirmEmailResponse>;