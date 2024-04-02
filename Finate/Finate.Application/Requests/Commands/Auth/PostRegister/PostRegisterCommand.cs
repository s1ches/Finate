using MediatR;
using Shared.Requests.Auth.PostRegister;

namespace Finate.Application.Requests.Commands.Auth.PostRegister;

public class PostRegisterCommand(PostRegisterRequest? request)
    : PostRegisterRequest(request), 
        IRequest<PostRegisterResponse>;