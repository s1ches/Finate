using Finate.Domain.Entities;
using Finate.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

[AllowAnonymous]
[Route("[controller]/[action]")]
public class AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
    : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        var model = new LoginViewModel { ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await userManager.FindByNameAsync(model.Email);

        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "User not found");
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, 
            isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
            return Redirect(model.ReturnUrl);
        
        ModelState.AddModelError(string.Empty, "Login error");
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        var model = new RegisterViewModel { ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new User { Email = model.Email, EmailConfirmed = false, UserName = string.Empty };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            return Redirect(model.ReturnUrl);
        }
        
        ModelState.AddModelError(string.Empty, "Error occured");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout(string returnUrl)
    {
        await signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }
}