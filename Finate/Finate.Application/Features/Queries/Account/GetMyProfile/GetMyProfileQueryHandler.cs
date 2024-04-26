using Finate.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Account.GetMyProfile;

namespace Finate.Application.Features.Queries.Account.GetMyProfile;

public class GetMyProfileQueryHandler(ICurrentUser currentUser, IDbContext dbContext)
    : IRequestHandler<GetMyProfileQuery, GetMyProfileResponse>
{
    public async Task<GetMyProfileResponse> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId;
        
        var forms = await dbContext.Forms
            .Where(form => form.UserId == userId)
            .Select(form => new FormDto
            {
                FormName = form.ProfessionName,
                FormId = form.Id,
                Views = form.Views,
                Rating = form.Rating
            })
            .ToListAsync(cancellationToken);

        var user = await dbContext.Users.FirstAsync(user => user.Id == userId, cancellationToken: cancellationToken);

        return new GetMyProfileResponse
        {
            UserName = user.UserName!,
            UserPhotoUrl = user.UserPhotoUrl ?? "",
            Forms = forms
        };
    }
}