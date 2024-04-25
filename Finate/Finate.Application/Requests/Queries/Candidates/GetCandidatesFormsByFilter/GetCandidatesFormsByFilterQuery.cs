using MediatR;
using Shared.Requests.Candidates.GetCandidatesFormsByFilter;

namespace Finate.Application.Requests.Queries.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterQuery(GetCandidatesFormsByFilterRequest request)
    : GetCandidatesFormsByFilterRequest(request),
        IRequest<GetCandidatesFormsByFilterResponse>;