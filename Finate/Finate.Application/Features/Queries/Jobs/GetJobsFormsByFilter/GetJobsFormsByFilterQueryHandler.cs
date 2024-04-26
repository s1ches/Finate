using Finate.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Jobs.GetJobsFormsByFilter;

namespace Finate.Application.Features.Queries.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterQueryHandler(IDbContext dbContext)
    : IRequestHandler<GetJobsFormsByFilterQuery, GetJobsFormsByFilterResponse>
{
    public async Task<GetJobsFormsByFilterResponse> Handle(GetJobsFormsByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.JobFormExtensions
            .Include(form => form.JobForm)
            .ThenInclude(form => form.User)
            .Where(form => form.JobForm.IsActive);

        if (!string.IsNullOrWhiteSpace(request.SearchValue))
            query = query
                .Where(form => form.JobForm.ProfessionName.ToLower().Contains(request.SearchValue.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.Category))
            query = query
                .Where(form => form.JobFormName.ToLower().Equals(request.Category.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.City))
            query = query
                .Where(form => form.JobForm.PlaceAddress.ToLower().Equals(request.City.ToLower()));
        
        var orderedQuery = query
            .OrderByDescending(form => form.JobForm.Views)
            .ThenByDescending(form => form.JobForm.Rating)
            .Select(form => new GetJobsFormsByFilterResponseItem
            {
                JobFormImagePath = 
                    form.JobForm.User.UserPhotoUrl == null
                    ? ""
                    : form.JobForm.User.UserPhotoUrl,
                Rating = form.JobForm.Rating,
                JobFormId = form.FormId,
                CompanyName = form.JobForm.User.UserName!,
                Address = form.JobForm.PlaceAddress,
                JobName = form.JobFormName,
                JobType = form.JobType.ToString(),
                TopSkills = form.JobForm.Skills!.Where(x => x.IsTopSkill).Select(x => x.SkillName).ToList(),
                Salary = form.JobForm.Salary
            });

        return new GetJobsFormsByFilterResponse
        {
            JobsForms = await orderedQuery
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken),
            TotalCount = await orderedQuery.CountAsync(cancellationToken)
        };
    }
}