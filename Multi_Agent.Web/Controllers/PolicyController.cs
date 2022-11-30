using Microsoft.AspNetCore.Mvc;
using Multi_Agent.Application.Interfaces;

namespace Multi_Agent.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        public IActionResult Index()
        {
            //utworzyć wido dla tej akcji
            //tabla z kLientami 
            //filtorwanie danych
            //przekazać filtry do serwisu
            //serwis przygotuje dane
            //serwis musi zwrócić dane w odpowiednim formacie

            var model = _policyService.GetAllPoliciesForList();

            return View(model);

        }

        [HttpGet]
        public IActionResult AddPolicy()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddPolicy(PolicyModel model)
        //{
        //    var id = _policyService.AddCustomer(model);
        //    return View();
        //}

        public IActionResult ViewPolicy(int Id)
        {
            var model = _policyService.GetPolicyDetails(Id);
            return View(model);
        }
    }
}
