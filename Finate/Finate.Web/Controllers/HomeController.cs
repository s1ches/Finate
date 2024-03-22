using Finate.Web.Models.HomeModels.HomeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер отвечабщий за отдачу главной страницы
/// </summary>
[AllowAnonymous]
public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = new IndexViewModel();
        return View(model);
    }
}