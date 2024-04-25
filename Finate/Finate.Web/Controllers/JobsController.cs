using Finate.Application.Requests.Queries.Jobs.GetJobsFormsByFilter;
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
        return View();
    }
}