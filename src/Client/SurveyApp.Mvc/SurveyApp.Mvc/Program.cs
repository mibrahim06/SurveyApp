
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.AccessDeniedPath = "/denied";
            options.Events = new CookieAuthenticationEvents()
            {
                OnSignedIn = async context =>
                {
                 
                    await Task.CompletedTask;
                },
                OnSigningOut = async context =>
                {
                    await Task.CompletedTask;
                },
                OnValidatePrincipal = async context =>
                {
                    var principal = context.Principal;
                    if (principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
                    {
                        if (principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ==
                            "ckaya")
                        {
                            var claimsIdentity = principal.Identity as ClaimsIdentity;
                            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                        }
                    }
                    await Task.CompletedTask;
                }
            };
        }
    );
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();