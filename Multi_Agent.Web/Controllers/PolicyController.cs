using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Policy;

namespace Multi_Agent.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyService;
        private readonly ICustomerService _customerService;
        public PolicyController(IPolicyService policyService, ICustomerService customerService)
        {
            _policyService = policyService;
            _customerService = customerService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //utworzyć wido dla tej akcji
            //tabla z kLientami 
            //filtorwanie danych
            //przekazać filtry do serwisu
            //serwis przygotuje dane
            //serwis musi zwrócić dane w odpowiednim formacie

            var model = _policyService.GetAllPoliciesForList(8, 1, "");

            return View(model);

        }


        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _policyService.GetAllPoliciesForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }



        [HttpGet]
        public IActionResult AddPolicy()
        {
           
            ViewData["CustomerId"] = new SelectList(_customerService.GetAllCustomersForList().Customers, "Id", "FullName");
            return View(new NewPolicyVm());
        }

        [HttpPost]
        public IActionResult AddPolicy(NewPolicyVm model)
        {
            var id = _policyService.AddPolicy(model);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return RedirectToAction("AddPolicy");
        }

        public IActionResult ViewPolicy(int Id)
        {
            var model = _policyService.GetPolicyDetails(Id);
            return View(model);
        }
    }
}
