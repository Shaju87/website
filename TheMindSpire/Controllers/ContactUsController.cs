using Microsoft.AspNetCore.Mvc;
using TheMindSpire.Data;
using TheMindSpire.Models.ContactData;

namespace TheMindSpire.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly MindSpireDbContext _context;

        public ContactUsController(MindSpireDbContext context)
        {
            _context = context;
        }

        // GET: ContactUs
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs
        [HttpPost]
        public IActionResult Index(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _context.ContactUsData.Add(contact);
                _context.SaveChanges();

                ViewBag.Message = "Thank you! Your message has been submitted.";
                ModelState.Clear();
            }

            return View();
        }
    }
}
