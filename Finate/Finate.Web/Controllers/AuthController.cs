using Finate.Application.Requests.Commands.Auth.PostConfirmEmail;
using Finate.Application.Requests.Commands.Auth.PostLogin;
using Finate.Application.Requests.Commands.Auth.PostRegister;
using Finate.Application.Requests.Commands.Auth.PostResetPassword;
using Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;
using Finate.Web.Models.AuthModels.AuthViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

// TODO: Переписать методы confirm email и reset password на переход по ссылке из письма, и при confirm email - redirect на returnUrl, а при reset password пользователь попадает на страницу с полями newPassword и newPasswordConfirm, токен для смены пароля мы берём из url и меняем пароль, а не так, что юзер меняет пароль и вводит почту в одном месте

[AllowAnonymous]
[Route("[controller]/[action]")]
public class AuthController(IMediator mediator)
    : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        var model = new LoginViewModel { ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellationToken)
    {
        var command = new PostLoginCommand { Email = model.Email, Password = model.Password };

        var response = await mediator.Send(command, cancellationToken);
        
        if(response.IsSuccessful)
            return Redirect(model.ReturnUrl);
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);
        
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        var model = new RegisterViewModel { ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellationToken)
    {
        var command = new PostRegisterCommand
            { Email = model.Email, Role = model.Role, UserName = model.UserName,
                Password = model.Password, PasswordConfirm = model.PasswordConfirm };

        var response = await mediator.Send(command, cancellationToken);
        
        if (response.IsSuccessful)
        {
            var url = Url.Action(nameof(ConfirmEmail), "Auth",
                new { returnUrl = model.ReturnUrl ?? "/", email = model.Email });
            return Redirect(url!);
        }

        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }
    
    [HttpGet]
    public IActionResult ConfirmEmail([FromQuery] string returnUrl, [FromQuery] string email)
    {
        var model = new ConfirmEmailViewModel { Email = email, ReturnUrl = returnUrl };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
    {
        var command = new PostConfirmEmailCommand
        {
            Email = model.Email,
            UserConfirmEmailToken = model.UserConfirmEmailToken
        };

        var result = await mediator.Send(command);

        if (result.IsSuccessful)
            return Redirect(model.ReturnUrl);
        
        foreach(var error in result.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }

    [HttpGet]
    public IActionResult ResetPassword(string returnUrl)
    {
        var model = new ResetPasswordViewModel { ReturnUrl = returnUrl };
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model,
        CancellationToken cancellationToken)
    {
        var command = new PostResetPasswordCommand
        {
            Email = model.Email,
            NewPassword = model.NewPassword,
            NewPasswordConfirm = model.NewPasswordConfirm
        };
        
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsSuccessful)
            return RedirectToAction(nameof(ResetPasswordConfirm), nameof(AuthController), 
                $"?returnUrl={model.ReturnUrl}&email={model.Email}&newPassword={model.NewPassword}");
        
        foreach(var error in result.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }

    [HttpGet]
    public IActionResult ResetPasswordConfirm([FromQuery] string returnUrl,
        [FromQuery]string email, [FromQuery]string newPassword)
    {
        var model = new ResetPasswordConfirmViewModel
        {
            Email = email,
            ReturnUrl = returnUrl,
            NewPassword = newPassword
        };

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmViewModel model,
        CancellationToken cancellationToken)
    {
        var command = new PostResetPasswordConfirmCommand
        {
            Email = model.Email,
            NewPassword = model.NewPassword,
            UserResetPasswordToken = model.UserResetPasswordToken
        };
        
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsSuccessful)
            return Redirect(model.ReturnUrl);
        
        foreach(var error in result.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }    
    
}