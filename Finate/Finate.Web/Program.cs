using Finate.Application;
using Finate.Persistence;
using Finate.Services;
using Finate.Web.Configuration;
using Finate.Web.Middlewares;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Добавление и конфигурация Identity
builder.Services.AddIdentity();
builder.Services.AddLogging();

//Добавление Middleware, который отвечает за обработку страниц ошибок
builder.Services.AddSingleton<ErrorMiddleware>();

// Конфигурация аутентификации
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = IdentityConstants.ApplicationScheme;
    opt.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    opt.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
});

// Конфигурация кук
builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Identity.Cookie";
    config.LoginPath = "/Auth/Login";
    config.ReturnUrlParameter = "/";
    config.LogoutPath = "/Auth/Logout";
});

// Добавление Application слоя
builder.Services.AddApplication();
// Добавление слоя сервисов
builder.Services.AddServices();
//Добавление Persistence слоя
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Использование ErrorMiddleware
app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/");

app.MapControllers();

app.Run();