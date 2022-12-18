using Microsoft.AspNetCore.Mvc;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.InsuranceCompany;
using System.Diagnostics.CodeAnalysis;

namespace Multi_Agent.Web.Controllers
{
    public class InsuranceCompanyController : Controller
    {

        private readonly IInsuranceCompanyService _insuranceCompanyService;

        public InsuranceCompanyController(IInsuranceCompanyService insuranceCompanyService)
        {
            _insuranceCompanyService = insuranceCompanyService;
        }
        public IActionResult Index()
        {
            var model = _insuranceCompanyService.GetAllInsuranceCompanyForList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddInsuranceCompany()
        {
            return View(new NewInsuranceCompanyVm());
        }


        [HttpPost]
        public IActionResult AddInsuranceCompany(NewInsuranceCompanyVm model)
        {
            _insuranceCompanyService.AddInsuranceCompany(model);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return RedirectToAction("AddInsuranceCompany");
        }


    }
}
