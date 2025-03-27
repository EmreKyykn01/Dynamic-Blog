using BlogSitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly DataBaseContext _dataBase;

        public Categories(DataBaseContext dataBase) // DI
        {
            _dataBase = dataBase;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _dataBase.Categories.ToListAsync());
        }
    }
}
