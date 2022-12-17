using AutoMapper;
using AutoMapper.QueryableExtensions;
using Multi_Agent.Application.Interfaces;
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
        private readonly IInsuranceCompanyRepository _InsuranceCompanyRepo;
        private readonly IMapper _mapper;

        public InsuranceCompanyService(IInsuranceCompanyRepository InsuranceCompanyRepo, IMapper mapper)
        {
            _InsuranceCompanyRepo = InsuranceCompanyRepo;
            _mapper = mapper;
                
        }

        public int AddInsuranceCompany(NewInsuranceCompanyVm insuranceCompany)
        {
            throw new NotImplementedException();
        }

        public List<InsuranceCompanyVm> GetAllInsuranceCompanyForList()
        {
            var list = _InsuranceCompanyRepo.GetAllActiveInsuranceCompany().Where(p => p.IsActive == true)
                   .ProjectTo<InsuranceCompanyVm>(_mapper.ConfigurationProvider).ToList();
            return list;
        }

        public InsuranceCompanyVm GetInsuranceCompanyDetails(int insuranceCompanyId)
        {
            throw new NotImplementedException();
        }
    }

}

