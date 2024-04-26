using Finate.Application.Features.Queries.Jobs.GetJobFormById;
using Finate.Application.Features.Queries.Jobs.GetJobsFormsByFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Jobs.GetJobsFormsByFilter;

namespace Finate.Web.Controllers;

public class JobsController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> FindJobs(
        [FromQuery] GetJobsFormsByFilterRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetJobsFormsByFilterQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> JobForm(
        [FromQuery] Guid jobFormId,
        CancellationToken cancellationToken)
    {
        var query = new GetJobFormByIdQuery(jobFormId);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}