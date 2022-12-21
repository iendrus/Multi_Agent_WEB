using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface ICommonService
    {
        DateTime CreatedAt { get; set; }

        DateTime? ModifiedAt { get; set; }

        int CreatedBy { get; set; }

        int? ModifiedBy { get; set; }

        bool IsActive { get; set; }


     }
}
