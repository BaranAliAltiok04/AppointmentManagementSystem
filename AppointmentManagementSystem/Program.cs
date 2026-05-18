using AppointmentManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Veri tabanı bağlantısını MySQL olarak internete bağlıyoruz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// 2. MVC Ekran (View) ve Kontrolcü (Controller) desteğini açıyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 3. Proje açılır açılmaz direkt Randevular listesi karşımıza gelsin
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Appointments}/{action=Index}/{id?}");

app.Run();