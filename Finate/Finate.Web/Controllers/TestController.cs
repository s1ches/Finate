using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

public class TestController : Controller
{
    public IActionResult TestIndex() => View();
}