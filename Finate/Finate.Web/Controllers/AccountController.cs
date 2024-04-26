using Finate.Application.Features.Commands.Account.PatchEditMyProfile;
using Finate.Application.Features.Queries.Account.GetMyProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Account.PatchEditMyProfile;

namespace Finate.Web.Controllers;

[Authorize]
public class AccountController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> MyProfile(CancellationToken cancellationToken)
    {
        var query = new GetMyProfileQuery();
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    // TODO: Create view
    public async Task<IActionResult> EditMyProfile(CancellationToken cancellationToken) => View();
    
    [HttpPatch]
    public async Task<IActionResult> EditMyProfile(
        [FromBody] PatchEditMyProfileRequest request,
        CancellationToken cancellationToken)
    {
        var command = new PatchEditMyProfileCommand(request);
        var response = await mediator.Send(command, cancellationToken);
        
        if(response.IsSuccessful)
            return RedirectToAction("MyProfile", "Account");
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

        return View(response);
    }
}