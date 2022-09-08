using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteApp;
using NoteApp.Data;
using NoteApp.Data.Repository;
using NoteApp.Models;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot _confString = new ConfigurationBuilder().
	SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
			   options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<User, IdentityRole>(opts => {
	opts.Password.RequiredLength = 5;   // ����������� �����
	opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
	opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
	opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
	opts.Password.RequireDigit = true; // ��������� �� �����
})
	.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddTransient<INote, NoteRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var userManager = services.GetRequiredService<UserManager<User>>();
		var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
		var applicationContext = services.GetRequiredService<ApplicationContext>();
		await Initializer.Initialize(userManager, rolesManager, applicationContext);
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while seeding the database.");
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
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
