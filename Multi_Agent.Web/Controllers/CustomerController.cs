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
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _customerService.AddCustomer(model);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return RedirectToAction("AddCustomer");
        }

    }
}
