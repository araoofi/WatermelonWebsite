using Microsoft.AspNetCore.Mvc;
using WwatermelonWebsite.Models;
using WwatermelonWebsite.Data;

namespace WwatermelonWebsite.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(RequestModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new Request
                {
                    EmailAddress = model.EmailAddress,
                    BrandRequest = model.BrandRequest,
                    IsCorrection = model.IsCorrection,
                    CorrectionDetails = model.IsCorrection ? model.CorrectionDetails : null
                };

                _context.Requests.Add(request);
                _context.SaveChanges();

                return RedirectToAction("ThankYou");
            }

            return View("Index", model);
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
