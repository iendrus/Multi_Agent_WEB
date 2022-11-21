using Microsoft.AspNetCore.Mvc;

namespace Multi_Agent.Web.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            //utworzyć wido dla tej akcji
            //tabla z kLientami 
            //filtorwanie danych
            //przekazać filtry do serwisu
            //serwis przygotuje dane
            //serwis musi zwrócić dane w odpowiednim formacie

            var model = policyService.GetAllPoliciesForList();

            return View(model);

        }

        [HttpGet]
        public IActionResult AddPolicy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPolicy(PolicyModel model)
        {
            var id = policyServise.AddCustomer(model);
            return View();
        }

        public IActionResult ViewPolicy(int policyId)
        {
            var policyModel = policyService.GetPolicyById(policyId);
            return View(policyModel);
        }
    }
}
