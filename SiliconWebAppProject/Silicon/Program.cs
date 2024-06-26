using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Silicon.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Home}/{id?}");

app.Run();
