using Finate.Application.Constants;
using Finate.Application.Requests.Commands.Auth.GetConfirmEmail;
using Finate.Application.Requests.Commands.Auth.PostLogin;
using Finate.Application.Requests.Commands.Auth.PostRegister;
using Finate.Application.Requests.Commands.Auth.PostResetPassword;
using Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;
using Finate.Web.Models.AuthModels.AuthViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер, отвечающий за авторизацию, регистрацию и функцию забыл пароль
/// </summary>
/// <param name="mediator"></param>
[AllowAnonymous]
[Route("[controller]/[action]")]
public class AuthController(IMediator mediator)
    : Controller
{
    /// <summary>
    /// Возвращает страницу логина
    /// </summary>
    /// <returns>Страницу логина</returns>
    [HttpGet]
    public IActionResult Login()
    {
        var model = new LoginViewModel();

        return View(model);
    }
    
    /// <summary>
    /// Логинит пользователя
    /// </summary>
    /// <param name="model">Модель логина</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на главную страницу, иначе добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellationToken)
    {
        var command = new PostLoginCommand { Email = model.Email, Password = model.Password };

        var response = await mediator.Send(command, cancellationToken);
        
        if(response.IsSuccessful)
            return RedirectToAction("Index", "Home");
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);
        
        return View(model);
    }
    
    /// <summary>
    /// Возвращает страницу регистрации
    /// </summary>
    /// <returns>Страница регистрации</returns>
    [HttpGet]
    public IActionResult Register()
    {
        var model = new RegisterViewModel();

        return View(model);
    }

    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="model">Модель регистрации</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на страницу ожидания подтверждения почты,
    /// иначе добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellationToken)
    {
        var command = new PostRegisterCommand
            { Email = model.Email, Role = model.Role, UserName = model.UserName,
                Password = model.Password, PasswordConfirm = model.PasswordConfirm };

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("ConfirmEmailAwait", "Auth");

        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }

    /// <summary>
    /// Возвращает страницу ожидания подтверждения почты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult ConfirmEmailAwait() => View();
    
    /// <summary>
    /// Подтверждение почты
    /// </summary>
    /// <param name="confirmToken">Токен для подтвержения почты</param>
    /// <param name="email">Почта</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на главную страницу, редирект на страницу
    /// BadRequest(если неверный confirmToken)</returns>
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string confirmToken, [FromQuery] string email,
        CancellationToken cancellationToken)
    {
        var token = Uri.UnescapeDataString(confirmToken).Replace(" ", "+");   

        var command = new GetConfirmEmailCommand
        {
            Email = email,
            UserConfirmEmailToken = token
        };

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("Index", "Home");

        return RedirectToAction("BadRequest", "Error");
    }

    /// <summary>
    /// Возвращает страницу сброса пароля
    /// </summary>
    /// <returns>Страница сброса пароля</returns>
    [HttpGet]
    public IActionResult ResetPassword()
    {
        var model = new ResetPasswordViewModel();
        return View(model);
    }
    
    /// <summary>
    /// Сброс пароля
    /// </summary>
    /// <param name="model">Модель сброса пароля(Email)</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на страницу ожидания подтверждения по почте, иначе
    /// добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model, CancellationToken cancellationToken)
    {
        var command = new PostResetPasswordCommand { Email = model.Email };

        var response = await mediator.Send(command, cancellationToken);
        
        if (response.IsSuccessful)
            return RedirectToAction("ResetPasswordConfirmAwait");
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(string.Empty, error);

        return View(model);
    }

    /// <summary>
    /// Возвращает страницу ожидания подтверждения сброса пароля по почте
    /// </summary>
    /// <returns>Страницу ожидания подтверждения сброса пароля по почте</returns>
    [HttpGet]
    public IActionResult ResetPasswordConfirmAwait() => View();

    /// <summary>
    /// Подтверждение сброса пароля
    /// </summary>
    /// <param name="confirmToken">Токен для подтверждения сброса пароля</param>
    /// <param name="email">Почта</param>
    /// <returns>Если всё хорошо, редирект на главную страницу, иначе либо добавление ошибок на форму,
    /// иначе редирект на BadRequest(если неверный confirmToken)</returns>
    [HttpGet]
    public IActionResult ResetPasswordConfirm(string confirmToken, string email)
    {
        var model = new ResetPasswordConfirmViewModel
        {
            UserResetPasswordToken = confirmToken,
            Email = email
        };

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmViewModel model,
        CancellationToken cancellationToken)
    {
        var token = Uri.UnescapeDataString(model.UserResetPasswordToken).Replace(" ", "+");   
        var command = new PostResetPasswordConfirmCommand
        {
            Email = model.Email, NewPassword = model.NewPassword, NewPasswordConfirm = model.NewPasswordConfirm,
            UserResetPasswordToken = token
        };
        
        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("Index", "Home");

        foreach (var error in response.ErrorMessages)
        {
            if (error.Equals(AuthErrorMessages.WrongUserConfirmationToken))
                RedirectToAction("BadRequest", "Error");
            
            ModelState.AddModelError(string.Empty, error);
        }

        return View(model);
    }
    
    
    
}