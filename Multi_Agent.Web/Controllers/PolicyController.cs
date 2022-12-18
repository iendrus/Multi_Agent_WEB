using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Policy;

namespace Multi_Agent.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyService;
        private readonly ICustomerService _customerService;
        private readonly IInsuranceCompanyService _insuranceCompanyService;
        private readonly IEmployeeService _employeeService;
        public PolicyController(IPolicyService policyService, ICustomerService customerService,
            IInsuranceCompanyService insuranceCompanyService, IEmployeeService employeeService)
        {
            _policyService = policyService;
            _customerService = customerService;
            _insuranceCompanyService = insuranceCompanyService;
            _employeeService = employeeService;
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
            ViewData["PolicyStatusId"] = new SelectList(_policyService.GetAllPolicyStatusesForList(), "Id", "Name");
            ViewData["PolicyTypeId"] = new SelectList(_policyService.GetAllPolicyTypesForList(), "Id", "Name");
            ViewData["PaymentTypeId"] = new SelectList(_policyService.GetAllPaymentTypesForList(), "Id", "Name");
            ViewData["InsuranceCompanyId"] = new SelectList(_insuranceCompanyService.GetAllInsuranceCompanyForList().InsuranceCompanies, "Id", "Name");
            ViewData["AgentId"] = new SelectList(_employeeService.GetActiveAgentsList(), "Id", "FullName");
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
