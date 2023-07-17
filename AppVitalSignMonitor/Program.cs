using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Autenticacion/Login"; // Se configura la ruta de la pagina donde se loguea el usuario.
        option.AccessDeniedPath = "/Home/AccesoNegado"; // Se configura donde en caso de un error sea redirigido el usuario. HACER!!!
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Se configura en cuanto tiempo expira la coookie.
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Esto activa la autenticacion.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();