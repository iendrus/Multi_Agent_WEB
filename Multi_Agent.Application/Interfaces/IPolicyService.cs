﻿using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface IPolicyService
    {
        ListPolicyForListVm GetAllPoliciesForList(int pageSize, int pageNo, string searachString);

        int AddPolicy(NewPolicyVm policy);

        PolicyDetailsVm GetPolicyDetails(int policyId);

        public List<PolicyStatusVm> GetAllPolicyStatusesForList();
        public List<PolicyTypeVm> GetAllPolicyTypesForList();

        public List<PaymentTypeVm> GetAllPaymentTypesForList();

        NewPolicyVm GetPolicyForEdit(int id);

        void UpdatePolicy(NewPolicyVm model);

        void DeletePolicy(int id);

    }
}
