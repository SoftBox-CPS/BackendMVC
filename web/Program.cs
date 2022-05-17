using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase;
using SoftBox.DataBase.InterfacesRepository;
using SoftBox.DataBase.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("SoftBoxMS");
builder.Services.AddDbContext<SoftBoxDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<RoomRepository>();

builder.Services.AddSignalR();
//builder.Services.ConnectEFCoreDB(builder.Configuration);

// Add services to the container.
var MVCbuilder = builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    MVCbuilder.AddRazorRuntimeCompilation();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<MVCWebApplication.Hubs.ChatHub>("/chathub");

app.Run();
