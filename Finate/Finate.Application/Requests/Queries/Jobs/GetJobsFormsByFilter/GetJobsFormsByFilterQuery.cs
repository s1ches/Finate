using MediatR;
using Shared.Requests.Jobs.GetJobsFormsByFilter;

namespace Finate.Application.Requests.Queries.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterQuery(GetJobsFormsByFilterRequest request)
    : GetJobsFormsByFilterRequest(request),
    IRequest<GetJobsFormsByFilterResponse>;