using Finate.Application.Requests.Queries.Candidates.GetCandidatesFormsByFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Candidates.GetCandidatesFormsByFilter;

namespace Finate.Web.Controllers;

public class CandidatesController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> FindCandidates(
        [FromQuery] GetCandidatesFormsByFilterRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetCandidatesFormsByFilterQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    [Authorize]
    public IActionResult CandidateForm([FromQuery] Guid candidateFormId, CancellationToken cancellationToken)
    {
        return View();
    }
}