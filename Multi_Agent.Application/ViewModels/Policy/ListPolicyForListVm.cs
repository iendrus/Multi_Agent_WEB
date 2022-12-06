﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class ListPolicyForListVm
    {
        public List<PolicyForListVm> Policies { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString{ get; set; }
        public int Count { get; set; }
    }
}
