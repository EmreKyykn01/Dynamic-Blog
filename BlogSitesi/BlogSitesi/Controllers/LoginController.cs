using System.Security.Claims;
using BlogSitesi.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataBaseContext _context;

        public LoginController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> IndexAsync(string email , string password)
        {
            try
            {
                var kullanici = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.IsActive);
                if (kullanici == null) TempData["Mesaj"] = "Giriş Başarısız";
                else
                {
                    var haklar = new List<Claim>() { new Claim (ClaimTypes.Email , kullanici.Email)};
                    var kullanicikimligi = new ClaimsIdentity(haklar , "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullanicikimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin)
                    {
                        return Redirect("/Admin");
                    }
                    else return Redirect("/Home");
                }
            }
            catch (Exception hata)
            {

                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        } // Oturum Açma işlemi
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync();
            return Redirect("/");
        } // Oturum Kapatma işlemi
    }
}
