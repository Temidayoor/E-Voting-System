using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Voting_System.Data;
using E_Voting_System.Areas.Identity.Data;
using E_Voting_System.Models;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("E_Voting_SystemContextConnection") ?? throw new InvalidOperationException("Connection string 'E_Voting_SystemContextConnection' not found.");

builder.Services.AddDbContext<E_Voting_SystemContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<E_Voting_SystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<E_Voting_SystemContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();   

    
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<E_Voting_SystemContext>();
        var userManager = services.GetRequiredService<UserManager<E_Voting_SystemUser>>();
        DbInitializer.InitializeAsync(context, services, userManager).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured while seeding the database");
    }
}



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
app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//IWebHostEnvironment env = app.Environment;

app.Run();
