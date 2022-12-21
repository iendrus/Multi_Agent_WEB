using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Employee;

namespace Multi_Agent.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult Index()
        {
            var model = _employeeService.GetAllEmployeesForList();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult AddEmployee()
        {
            return View(new NewEmployeeVm());
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(NewEmployeeVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _employeeService.AddEmployee(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Create()
        {
            return RedirectToAction("AddEmployee");
        }
    }
}
