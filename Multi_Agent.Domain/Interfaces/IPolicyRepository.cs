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
        void DeletePolicy(int policyId);
        int AddPolicy(Policy policy);
        IQueryable<Policy> GetPoliciesByTypeId(string typeId);
        Policy GetPoliciesById(int policyId);
    }
}
