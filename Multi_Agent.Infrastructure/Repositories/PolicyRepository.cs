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

        public void DeletePolicy(int policyId)
        {
            var policy = _context.Policies.Find(policyId);
            if(policy != null)
            {
                _context.Policies.Remove(policy);
                _context.SaveChanges();
            }
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

        //public Policy GetPolicy(int policyId)
        //{
        //    var policy = _context.Policies.FirstOrDefault(i => i.Id == policyId);
        //    return policy;
        //}

        public Policy GetPolicy(int policyId)
        {
            var policy = _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.PolicyStatus)
                .Include(p => p.PolicyType)
                .Include(p => p.InsuranceCompany)
                .Include(p => p.Agent)
                .FirstOrDefault(p => p.Id == policyId);
            return policy;
        }


        public IQueryable<Policy> GetAllActivePolicies()
        {
            return _context.Policies;
        }


    }
}
