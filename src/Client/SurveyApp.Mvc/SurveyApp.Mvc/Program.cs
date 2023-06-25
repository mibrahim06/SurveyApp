
using Microsoft.AspNetCore.Authentication.Cookies;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/User/login";
        options.ReturnUrlParameter = "rtnUrl";
    });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();

// get all users
var users = builder.Services.BuildServiceProvider().GetRequiredService<IUserService>().GetAll();
Console.WriteLine("All users:");
foreach (var item in users)
{
    Console.WriteLine(item.Name);
}

var app = builder.Build();

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

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();