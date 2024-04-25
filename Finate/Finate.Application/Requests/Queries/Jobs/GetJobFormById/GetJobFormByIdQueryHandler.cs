using System.Net;
using Finate.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Jobs.GetJobFormById;

namespace Finate.Application.Requests.Queries.Jobs.GetJobFormById;

public class GetJobFormByIdQueryHandler(IDbContext dbContext) 
    : IRequestHandler<GetJobFormByIdQuery, GetJobFormByIdResponse>
{
    public async Task<GetJobFormByIdResponse> Handle(GetJobFormByIdQuery request, CancellationToken cancellationToken)
    {
        var jobForm = await dbContext.JobFormExtensions
            .Include(form => form.JobForm)
            .ThenInclude(form => form.User)
            .Include(form => form.DescriptionParts)
            .FirstOrDefaultAsync(form => form.JobForm.Id == request.JobFormId,
                cancellationToken: cancellationToken);

        if (jobForm is null)
            throw new BadHttpRequestException("Job form with this id doesn't exist",
                (int)HttpStatusCode.BadRequest);

        return new GetJobFormByIdResponse();
    }
}