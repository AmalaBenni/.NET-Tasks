using Microsoft.EntityFrameworkCore;
using ProductListDb.Data; // add your namespace for DbContext

var builder = WebApplication.CreateBuilder(args);

                                            
builder.Services.AddControllersWithViews(); // Add services to the container.

// Register ApplicationDbContext with MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36)) // adjust to your MySQL version
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Change default controller to Products so app opens on Products list
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();