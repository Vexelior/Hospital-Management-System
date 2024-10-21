using Application.Interfaces;
using Application.Services;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Web.Data;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HospitalContext>(options =>
         options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

// Services \\
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<ProviderService>();

builder.Services.AddScoped<IProviderServiceLocationRepository, ProviderServiceLocationRepository>();
builder.Services.AddScoped<ProviderServiceLocationService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();

builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddScoped<ClaimService>();

builder.Services.AddScoped<IAccountRequestRepository, AccountRequestRepository>();
builder.Services.AddScoped<AccountRequestService>();

builder.Services.AddTransient<IEmailService, EmailService>();
// End Services \\

// Logging \\
var logFile = $"log-{DateTime.Now:yyyy-MM-dd}.log";
var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", logFile);

if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Logs")))
{
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));
}

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});
// End Logging \\

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var hospitalContext = services.GetRequiredService<HospitalContext>();

        await context.Database.MigrateAsync();
        await hospitalContext.Database.MigrateAsync();

        await app.SeedData();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
