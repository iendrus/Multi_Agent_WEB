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
        }

        int AddPolicy(NewPolicyVm policy)
        {
            throw new NotImplementedException();
        }

        //public PolicyDetailsVm GetPolicyDetails(int policyId)
        //{
        //    var policy = _policyRepo.GetPolicy(policyId);
        //    //metoda Map jest stosowana przy pojedynczym elemencje, natomiast ProjektTo przy kolekcjach
        //    var policyVm = _mapper.Map<PolicyDetailsVm>(policy);

        //    return policyVm;
        //}

        public PolicyForListVm GetPolicyDetails(int policyId)
        {
            var policy = _policyRepo.GetPolicy(policyId);
            //metoda Map jest stosowana przy pojedynczym elemencje, natomiast ProjektTo przy kolekcjach
            var policyVm = _mapper.Map<PolicyForListVm>(policy);

            return policyVm;
        }

    }
}
