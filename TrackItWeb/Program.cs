using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Home/Index", "");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "TrackIt";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.SlidingExpiration = true;
        options.LoginPath = "/Authentication/Login";
        options.LogoutPath = "/Authentication/Login";
        options.AccessDeniedPath = "/Error";
    });

builder.Services.AddAuthorization(options =>
{
});


var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(cookiePolicyOptions);

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapDefaultControllerRoute();

app.Run();
