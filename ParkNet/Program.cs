using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ParkNetDefaultConection") ?? throw new InvalidOperationException("Connection string 'ParkNetDefaultConection' not found.");
builder.Services.AddDbContext<ParkNetDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ParkNetDbContext>();
builder.Services.AddRazorPages();

// Dependency injection configuration
builder.Services.AddScoped<BalanceTransactionsServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
