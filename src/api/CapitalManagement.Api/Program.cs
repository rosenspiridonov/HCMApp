using CapitalManagement.Api.Extensions;
using CapitalManagement.Data;

using Microsoft.EntityFrameworkCore;

using static CapitalManagement.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString))
    .AddIdentity()
    .AddJwtAuthentication(builder.Configuration[Configuration.JwtSecret] ?? throw new InvalidOperationException("Jwt key not found"))
    .AddAuthorization()
    .RegisterServices()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.EnsureDeleted();
//    dbContext.Database.EnsureCreated();
//    dbContext.Database.Migrate();
//}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}

app.UseSwaggerWithUI()
.UseRouting()
.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod())
.UseAuthentication()
.UseAuthorization();

app.MapControllers();
app.Run();
