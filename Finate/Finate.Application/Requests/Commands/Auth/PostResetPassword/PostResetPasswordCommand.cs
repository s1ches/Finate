using MediatR;
using Shared.Requests.Auth.PostResetPassword;

namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommand(PostResetPasswordRequest? request) 
    : PostResetPasswordRequest(request),
        IRequest<PostResetPasswordResponse>;