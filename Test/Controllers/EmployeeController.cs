using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

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
          ViewBag.Department=_context.Departments.OrderBy(x=>x.DepartmentName).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            UploadImage(model);
            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View();
        }

        private void UploadImage(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filestream = new FileStream(Path.Combine(@"wwwroot/", "Img", ImageName), FileMode.Create);
                file[0].CopyTo(filestream);
                model.Image = ImageName;

            }
            else if (model.Image == null)
            {
                model.Image = "Default.png";
            }
            else
            {
                model.Image = model.Image;
            }
        }

        public IActionResult Edit(int? Id)
        {
            var Result = _context.Employees.Find(Id);
            ViewBag.Department = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View("Create",Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee model)
        {
            UploadImage(model);
            if (ModelState.IsValid)
            {
                _context.Employees.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View(model);
        }
        public IActionResult Delete(int? Id)
        {
            var Result = _context.Employees.Find(Id);
            if(Result != null)
            {
                _context.Employees.Remove(Result);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
