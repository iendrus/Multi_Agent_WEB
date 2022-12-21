﻿using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyTypeVm : IMapFrom<Multi_Agent.Domain.Model.PolicyType>
    {
        [DisplayName("Kod rodzaju polisy")]
        public string Id { get; set; }
        [DisplayName("Nazwa rodzaju polisy")]
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.PolicyType, PolicyTypeVm>();
        }

    }
}
