using MediatR;
using Shared.Requests.Auth.PostLogin;

namespace Finate.Application.Requests.Commands.Auth.PostLogin;

public class PostLoginCommand(PostLoginRequest request)
    : PostLoginRequest(request),
        IRequest<PostLoginResponse>;