using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Home.GetIndex;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер отвечающий за отдачу главной страницы
/// </summary>
[AllowAnonymous]
public class HomeController(IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        var response = new GetIndexResponse();
        return View(response);
    }
}