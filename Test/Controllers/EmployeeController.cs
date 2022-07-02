using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EmployeeController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result=_context.Employees.Include(x=>x.Department).OrderBy(x=>x.EmployeeName).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
          
            return View();
        }

    }
}
