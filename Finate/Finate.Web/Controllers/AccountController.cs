using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

[Authorize]
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult MyProfile() => View();
}