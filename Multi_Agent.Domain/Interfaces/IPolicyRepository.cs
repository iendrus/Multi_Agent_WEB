using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Interfaces
{
    public interface IPolicyRepository
    {
        IQueryable<Policy> GetAllActivePolicies();

        public IQueryable<PolicyStatus> GetAllActivePolicyStatuses();

        public IQueryable<PolicyType> GetAllActivePolicyTypes();

        public IQueryable<PaymentType> GetAllActivePaymentTypes();

        Policy GetPolicy(int policyId);


        IQueryable<Policy> GetPoliciesByTypeId(string typeId);

        void DeletePolicy(int policyId);
        int AddPolicy(Policy policy);
        void UpdatePolicy(Policy policy);
    }
}
