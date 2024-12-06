using Microsoft.AspNetCore.Mvc;
using WwatermelonWebsite.Models;
using System.Linq;
using WwatermelonWebsite.Data;


namespace WwatermelonWebsite.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string query)
        {

            if (string.IsNullOrEmpty(query))
            {
                return View(); 
            }

            // remove any whitespace on left or right
            query = query.Trim();

            var results = _context.BrandActions
                .Where(b => b.Brand.Contains(query) || b.Action.Contains(query) || b.Why.Contains(query))
                .ToList();
            
            return View(results);
        }

        public IActionResult AllBrands()
        {

            return View(); 
        }
    }
}
