using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        [Area("Admin"), Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
