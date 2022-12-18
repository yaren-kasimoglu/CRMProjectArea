using CRMProjectArea.DAL.Concrete.EF.Context;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//identity


// Add services to the container.
builder.Services.AddControllersWithViews();

//context
builder.Services.AddDbContext<CRMContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

builder.Services.AddDefaultIdentity<UserAccount>(options =>
{

})
.AddRoles<UserRole>()
.AddEntityFrameworkStores<CRMContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
	//login path
	config.LoginPath = new PathString("/identity/login");
	config.AccessDeniedPath = new PathString("/identity/access-denied");
	config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
	config.Cookie.HttpOnly = true;
	config.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //Giriþ kontrolü yapýlan middleware
app.UseAuthorization(); //yetki kontrolü yapýlan middleware

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
