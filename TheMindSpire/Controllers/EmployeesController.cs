using Microsoft.AspNetCore.Mvc;
using TheMindSpire.Data;
using TheMindSpire.Models.EmpData;
using TheMindSpire.Models.viewmodels;
namespace TheMindSpire.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MindSpireDbContext mindSpireDbContext;

        public EmployeesController(MindSpireDbContext mindSpireDbContext)
        {
            this.mindSpireDbContext = mindSpireDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(DataRequest dataRequest)
        {
            var msdata = new MindSpireData
            {
                Name = dataRequest.Name,
                Role = dataRequest.Role,
                Email = dataRequest.Email

            };

            mindSpireDbContext.EmployeesData.Add(msdata);
            mindSpireDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var  li = mindSpireDbContext.EmployeesData.ToList();

            return View(li);
        }
    }
}
