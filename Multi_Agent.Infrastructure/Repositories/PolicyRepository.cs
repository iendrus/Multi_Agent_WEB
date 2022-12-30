using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly Context _context;
        public PolicyRepository(Context context )
        {
            _context = context;
        }



        public int AddPolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            _context.SaveChanges();
            return policy.Id;
        }

        public IQueryable<Policy> GetPoliciesByTypeId(string typeId)
        {
            var policies = _context.Policies.Where(i => i.PolicyTypeId == typeId);
            return policies;
        }


        public Policy GetPolicy(int policyId)
        {
            var policy = _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.PolicyStatus)
                .Include(p => p.PolicyType)
                .Include(p => p.PaymentType)
                .Include(p => p.InsuranceCompany)
                .Include(p => p.Agent)
                .Include(p => p.CreatedByNavigation)
                .Include(p => p.ModifiedByNavigation)
                .FirstOrDefault(p => p.Id == policyId);
            return policy;
        }


        public IQueryable<Policy> GetAllActivePolicies()
        {
            return _context.Policies.Where(p => p.IsActive == true);
        }

        public IQueryable<PolicyStatus> GetAllActivePolicyStatuses()
        {
            return _context.PolicyStatuses.Where(p => p.IsActive == true);
        }

        public IQueryable<PolicyType> GetAllActivePolicyTypes()
        {
            return _context.PolicyTypes.Where(p => p.IsActive == true);
        }
        public IQueryable<PaymentType> GetAllActivePaymentTypes()
        {
            return _context.PaymentTypes.Where(p => p.IsActive == true);
        }

        public void UpdatePolicy(Policy policy)
        {
            if (policy != null)
            {
                _context.Update(policy);
                _context.SaveChanges();
            }
        }

        public void DeletePolicy(int policyId)
        {
            var policy = _context.Policies.Find(policyId);
            if (policy != null)
            {
                policy.IsActive = false;
                _context.Update(policy);
                _context.SaveChanges();
            }
        }
    }
}
