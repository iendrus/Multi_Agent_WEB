using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Model
{
    public class TestClass
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual Employee CreatedByNavigation { get; set; } 

        public virtual Employee? ModifiedByNavigation { get; set; }

        public virtual ICollection<Policy> Policies { get; } = new List<Policy>();
    }
}
