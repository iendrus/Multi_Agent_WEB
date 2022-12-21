using Microsoft.AspNetCore.Mvc;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Policy;

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
            var customerModel = _customerService.GetCustomerDetails(Id);
            return View(customerModel);
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
            if(ModelState.IsValid)
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
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(NewCustomerVm model)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult Create()
        {
            return RedirectToAction("AddCustomer");
        }

    }
}
