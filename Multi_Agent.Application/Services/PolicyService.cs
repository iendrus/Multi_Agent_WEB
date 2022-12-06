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
        public ListPolicyForListVm GetAllPoliciesForList(int pageSize, int pageNo, string searachString)
        {
            // metoda ProjectTo wykorzystuje zdefiniowane  mapowanie 

            var policies = _policyRepo.GetAllActivePolicies().Where(p => p.Customer.Surname.StartsWith(searachString))
                    .ProjectTo<PolicyForListVm>(_mapper.ConfigurationProvider).ToList();

            var customerToShow = policies.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var policyList = new ListPolicyForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searachString,
                Policies = customerToShow,
                Count = policies.Count
            };
            return policyList;
        }

        public int AddPolicy(NewPolicyVm policy)
        {
            //zaimplementować
            return policy.Id;
        }


        public PolicyDetailsVm GetPolicyDetails(int policyId)
        {
            var policy = _policyRepo.GetPolicy(policyId);
            //metoda Map jest stosowana przy pojedynczym elemencje, natomiast ProjektTo przy kolekcjach
            var policyVm = _mapper.Map<PolicyDetailsVm>(policy);

            return policyVm;
        }

    }
}
