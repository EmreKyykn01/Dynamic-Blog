using BlogSitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DataBaseContext _context;

        public CategoriesController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var model = _context.Categories.Include(p=> p.Posts).FirstOrDefault(c=> c.Id == id);
            return View(model);
        }
    }
}
