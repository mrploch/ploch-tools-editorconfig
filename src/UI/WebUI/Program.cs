using Syncfusion.Licensing;
using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Ploch.EditorConfigTools.UseCases;
using Ploch.EditorConfigTools.DataAccess;
using Ploch.EditorConfigTools.Processing;
using Ploch.Data.GenericRepository.EFCore;

SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH9dcXRQQmZdVkB1X0o=");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<EditorConfigDbContext>(options =>
                                                         options.UseSqlServer(connectionString))
       .AddRepositories<EditorConfigDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
       .AddEntityFrameworkStores<EditorConfigDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddProcessing().AddUseCases();

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
