using System.Diagnostics;
using BlogSitesi.Data;
using BlogSitesi.Entites;
using BlogSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext _context;

        public HomeController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Posts.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("hakkimda")]
        public IActionResult About()
        {
            return View();
        }
        [Route("iletisim")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("iletisim") , HttpPost]
        public IActionResult Contact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                TempData["Message"] = "<div class='alert alert-success'>Mesajýný Gönderildi Teþekkürler..</div>";
                return RedirectToAction("Contact");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hata Oluþtu!");
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
