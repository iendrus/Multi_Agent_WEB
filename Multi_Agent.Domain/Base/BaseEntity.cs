using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Base
{
    public class BaseEntity
    {

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
