using AutoMapper;
using AutoMapper.QueryableExtensions;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Employee;
using Multi_Agent.Application.ViewModels.InsuranceCompany;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Services
{
    public class InsuranceCompanyService : IInsuranceCompanyService
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepo;
        private readonly IMapper _mapper;

        public InsuranceCompanyService(IInsuranceCompanyRepository insuranceCompanyRepo, IMapper mapper)
        {
            _insuranceCompanyRepo = insuranceCompanyRepo;
            _mapper = mapper;
                
        }

        public void AddInsuranceCompany(NewInsuranceCompanyVm insCompany)
        {
            var item = _mapper.Map<InsuranceCompany>(insCompany);
            _insuranceCompanyRepo.AddInsuranceCompany(item);
        }


        public ListInsuranceCompanyForListVm GetAllInsuranceCompanyForList()
        {
            var insuranceCompanies = _insuranceCompanyRepo.GetAllActiveInsuranceCompany()
                           .ProjectTo<InsuranceCompanyVm>(_mapper.ConfigurationProvider).ToList();
            var list = new ListInsuranceCompanyForListVm()
            {
                InsuranceCompanies = insuranceCompanies,
                Count = insuranceCompanies.Count
            };
            return list;
        }

        public InsuranceCompanyVm GetInsuranceCompanyDetails(string id)
        {
            var item = _insuranceCompanyRepo.GetInsuranceCompany(id);
            var vm = _mapper.Map<InsuranceCompanyVm>(item);
            return vm;
        }

        public object GetInsuranceCompanyForEdit(string id)
        {
            var item = _insuranceCompanyRepo.GetInsuranceCompany(id);
            var vm = _mapper.Map<NewInsuranceCompanyVm>(item);
            return vm;
        }

        public void UpdateInsuranceCompany(NewInsuranceCompanyVm model)
        {
            var item = _mapper.Map<InsuranceCompany>(model);
            if (item != null)
            {
                _insuranceCompanyRepo.UpdateInsuranceCompany(item);
            }
        }

        public void DeleteInsuranceCompany(string id)
        {
            _insuranceCompanyRepo.DeleteInsuranceCompany(id);
        }


    }

}

