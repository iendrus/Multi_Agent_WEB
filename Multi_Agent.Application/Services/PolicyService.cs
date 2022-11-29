using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Query;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepo;
        private readonly IMapper _mapper;

        public PolicyService(IPolicyRepository policyRepo, IMapper mapper)
        {
            _policyRepo = policyRepo;
            _mapper = mapper;
        }
        public ListPolicyForListVm GetAllPoliciesForList()
        {
            // metoda ProjectTo wykorzystuje zdefiniowane  mapowanie 

            var policies = _policyRepo.GetAllActivePolicies()
                    .ProjectTo<PolicyForListVm>(_mapper.ConfigurationProvider).ToList();
            var policyList = new ListPolicyForListVm()
            {
                Policies = policies,
                Count = policies.Count
            };
            return policyList;



            // poniżesze mapowania są zastąpione AutoMapperem
            //var policies = _policyRepo.GetAllActivePolicies();
            //ListPolicyForListVm result = new ListPolicyForListVm();
            //result.Policies = new List<PolicyForListVm>();
            //foreach (var policy in policies)
            //{
            //    var PolicyVm = new PolicyForListVm()
            //    {
            //        Id = policy.Id,
            //        PolicyNumber = policy.PolicyNumber,
            //        PolicyStatusName = policy.PolicyStatus.Name,
            //        PolicyTypeName = policy.PolicyType.Name,
            //        InsuranceCompanyName = policy.InsuranceCompany.Name
            //    };
            //    result.Policies.Add(PolicyVm);
            //}
            //result.Count = result.Policies.Count;
            //return result;
        }

        int AddPolicy(NewPolicyVm policy)
        {
            throw new NotImplementedException();
        }

        PolicyDetailsVm GetPolicyDetails(int policyId)
        {
            var policy = _policyRepo.GetPolicy(policyId);
            //var policyVm = new PolicyDetailsVm();
            //metoda Map jest stosowana przy pojedynczym elemencje, natomiast ProjektTo przy kolekcjach
            var policyVm = _mapper.Map<PolicyDetailsVm>(policy);

            //policyVm.Id = policy.Id;
            //policyVm.PolicyNumber = policy.PolicyNumber;
            //policyVm.PolicyStatusName = policy.PolicyStatus.Name;
            //policyVm.PolicyDate = policy.PolicyDate;
            //policyVm.CustomerFullName = policy.Customer.Surname + " " + policy.Customer.Name;
            return policyVm;
        }
    }
}
