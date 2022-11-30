﻿using Multi_Agent.Application.ViewModels.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface IPolicyService
    {
        ListPolicyForListVm GetAllPoliciesForList();

        //int AddPolicy(NewPolicyVm policy);

        //PolicyDetailsVm GetPolicyDetails(int policyId);
        PolicyForListVm GetPolicyDetails(int policyId);



    }
}