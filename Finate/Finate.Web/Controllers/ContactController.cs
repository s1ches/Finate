using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

[AllowAnonymous]
public class ContactController : Controller
{
    [HttpGet]
    public IActionResult OurContacts() => View();
}