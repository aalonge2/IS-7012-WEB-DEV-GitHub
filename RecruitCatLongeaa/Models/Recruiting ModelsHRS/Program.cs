// File: Program.cs
// Target framework: .NET 6 / Visual Studio 2022

using HenchmentRecruitingSolutions.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// 1) Configure Logging (optional, mirrors appsettings.json)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

// --------------------------------------------------
// 2) Register your DbContext
//    • For development or testing you can use InMemory.
//    • For production switch to UseSqlServer and a real ConnectionString.
builder.Services.AddDbContext<RecruitingDbContext>(options =>
{
    // In‐Memory for now:
    options.UseInMemoryDatabase("HenchmentRecruitingDb");

    // When ready for SQL Server, comment out the line above and use:
    // options.UseSqlServer(
    //     builder.Configuration.GetConnectionString("DefaultConnection"));
});

// --------------------------------------------------
// 3) Register MVC controllers (API)
builder.Services.AddControllers();

// --------------------------------------------------
// 4) (Optional) Register Swagger/OpenAPI if you want API docs
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------------------------------------
// 5) Configure the HTTP pipeline

// If you enabled Swagger in step 4, uncomment these lines:
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// NOTE: per your request, HTTPS redirection is disabled.
// app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

// Map your API controllers
app.MapControllers();

app.Run();