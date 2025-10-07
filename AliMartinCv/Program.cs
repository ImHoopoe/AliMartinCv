using AliMartinCv.Core.Services.Services;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Sevices.Services;
using AliMartinCv.DataLayer.context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(24);
        options.SlidingExpiration = true;  
        options.Cookie.HttpOnly = true;   
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; 
    });


builder.Services.AddAuthorization();
#region Context
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AliMartinCvContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AliMartinCvDataBase")));

#endregion
#region IOC
builder.Services.AddScoped<IBlogGroup,BlogGroupServices>();
builder.Services.AddScoped<IBlog,BlogServices>();
builder.Services.AddScoped<ISchool,SchoolServices>();
builder.Services.AddScoped<IClass,ClassService>();
builder.Services.AddScoped<IStudent,StudentServices>();
builder.Services.AddScoped<IAttendance,AttendanceServices>();
builder.Services.AddScoped<IParent,ParentServices>();

#endregion

var app = builder.Build();

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

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
