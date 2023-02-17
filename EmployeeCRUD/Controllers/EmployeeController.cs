using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _db;
        public EmployeeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _db.employees.ToList();

          return View(employees);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e) {
          //
            if(ModelState.IsValid)
            {
            _db.employees.Add(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(e);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Employee e = _db.employees.Find(id);
            if (e == null) return NotFound();
            return View(e);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if(ModelState.IsValid)
            {
                _db.employees.Update(e);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }
        public IActionResult Delete(int? id)
        {
            if(id==null) return NotFound();
            Employee e = _db.employees.Find(id);
            if (e == null) return NotFound();
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null) return NotFound();
            Employee emp = _db.employees.Find(id);
            if (emp == null) return NotFound();
            _db.employees.Remove(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
