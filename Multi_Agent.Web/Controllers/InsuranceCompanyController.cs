using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Employee;
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


        public ActionResult ViewInsuranceCompany(string id)
        {
            var item = _insuranceCompanyService.GetInsuranceCompanyDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        [HttpGet]
        public IActionResult AddInsuranceCompany()
        {
            return View(new NewInsuranceCompanyVm());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInsuranceCompany(NewInsuranceCompanyVm model)
        {
            if (ModelState.IsValid)
            {
                _insuranceCompanyService.AddInsuranceCompany(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditInsuranceCompany(string id)
        {
            var insuranceCompany = _insuranceCompanyService.GetInsuranceCompanyForEdit(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }
            return View(insuranceCompany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditInsuranceCompany(NewInsuranceCompanyVm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _insuranceCompanyService.UpdateInsuranceCompany(model);
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

        public IActionResult DeleteInsuranceCompany(string id)
        {
            _insuranceCompanyService.DeleteInsuranceCompany(id);
            return RedirectToAction("Index");
        }

    }
}
