using Finate.Application.Interfaces;
using MediatR;
using Shared.Requests.Candidates.GetCandidateFormById;

namespace Finate.Application.Requests.Queries.Candidates.GetCandidateFormById;

public class GetCandidateFormByIdQueryHandler(IDbContext dbContext) 
    : IRequestHandler<GetCandidateFormByIdQuery, GetCandidateFormByIdResponse>
{
    public async Task<GetCandidateFormByIdResponse> Handle(GetCandidateFormByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}