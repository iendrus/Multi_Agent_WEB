using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    internal class PolicyDetailsVm
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }

        public string PolicyTypeName { get; set; }

        public string PolicyStatusName { get; set; }

        public string CustomerFullName { get; set; }

        public DateTime PolicyDate { get; set; }

        public DateTime PolicyDateStart { get; set; }

        public DateTime PolicyDateEnd { get; set; }

    }
}
