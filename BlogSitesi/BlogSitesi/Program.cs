using BlogSitesi.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // Güvenli giriþ için lazým admin giriþi için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {
    x.LoginPath = "/Login";
    x.Cookie.Name = "AdminLogin";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // "UseAuthentication" ilk önce bunu yaz sonra bu "UseAuthorization"
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
