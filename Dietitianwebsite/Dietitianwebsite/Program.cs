using CloudinaryDotNet;
using Dietitianwebsite.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication()
                .AddGoogle(options => {
                    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
                    options.ClientId = "176533284849-fftkhhapvlj0rlhkv22rv96lgda3f3fr.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.CallbackPath = "/Home";

                })
                .AddFacebook(options => {
                    options.AppId = "534920235160329";
                    options.AppSecret = "164db42e38bc1e11cb07aca7ce0ddbf4";

                });

var app = builder.Build();

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
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
