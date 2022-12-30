using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Model;
using Multi_Agent.Infrastructure;

namespace Multi_Agent.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var model = _customerService.GetAllCustomersForList();
            return View(model);
        }
        public IActionResult ViewCustomer(int Id)
        {
            var customer = _customerService.GetCustomerDetails(Id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new NewCustomerVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _customerService.AddCustomer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(NewCustomerVm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomer(model);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (model != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(model);
        }

        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }


    }
}
