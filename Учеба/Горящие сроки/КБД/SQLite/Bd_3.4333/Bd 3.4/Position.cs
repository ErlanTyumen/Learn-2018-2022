using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string Position1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
