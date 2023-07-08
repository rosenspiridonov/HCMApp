using CapitalManagement.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddJwtAuthentication(builder.Configuration[CapitalManagement.Common.Constants.JwtTokenSecret] ?? throw new InvalidOperationException("Jwt key not found"))
    .AddAuthorization()
    .AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(60);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    })
    .RegisterServices()
    .AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app
        .UseExceptionHandler("/Home/Error")
        .UseHsts()
        .UseDeveloperExceptionPage();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseSession()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
