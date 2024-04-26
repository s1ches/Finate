using MediatR;
using Shared.Requests;

namespace Finate.Application.Features.Commands.Account.PatchEditMyProfile;

// TODO: Implement
public class PatchEditMyProfileCommandHandler 
    : IRequestHandler<PatchEditMyProfileCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(PatchEditMyProfileCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}