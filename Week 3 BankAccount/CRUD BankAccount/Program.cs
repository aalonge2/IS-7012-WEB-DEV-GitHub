using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// HTTPS redirection is commented out for local development
// app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
// Map Razor Pages.
app.MapRazorPages();
// Create and seed account holders
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var accountHolders1 = new List<AccountHolder1>
    {
        new AccountHolder1 { Name = "Anisa Longe", Email = "longeaa@gert.com", AccountBalance = 15000 },
        new AccountHolder1 { Name = "Barney Brontosaur", Email = "dino@fir.com", AccountBalance = 3200 },
        new AccountHolder1 { Name = "Geard Smith", Email = "gsmith564@lepe.com", AccountBalance = 22400 }
    };
    dbContext.AccountHolders.1AddRange(accountHolders1);
    dbContext.SaveChanges();
}
app.Run();