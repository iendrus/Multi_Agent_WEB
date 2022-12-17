﻿using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyStatusVm : IMapFrom<Multi_Agent.Domain.Model.PolicyStatus>
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.PolicyStatus, PolicyStatusVm>();
        }

    }
}
