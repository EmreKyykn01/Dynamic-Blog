using BlogSitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Controllers
{
    public class PostsController : Controller
    {
        private readonly DataBaseContext _context;

        public PostsController(DataBaseContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> IndexAsync()
        {
            var model =await _context.Posts.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> SearchAsync(string kelime)
        {
            var model = await _context.Posts.Where(p=>p.Name.Contains(kelime)).ToListAsync();
            return View(model);
            
        }
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _context.Posts.FindAsync(id);
            return View(model);

        } 
    }
}
