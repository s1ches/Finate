using Finate.Application.Features.Queries.Candidates.GetCandidateFormById;
using Finate.Application.Features.Queries.Candidates.GetCandidatesFormsByFilter;
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
    public async Task<IActionResult> CandidateForm([FromRoute] Guid candidateFormId, CancellationToken cancellationToken)
    {
        var query = new GetCandidateFormByIdQuery(candidateFormId);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}