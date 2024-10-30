using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Employee
    {
        public Employee()
        {
            Branches = new HashSet<Branch>();
            Rooms = new HashSet<Room>();
        }

        public int EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? PositionId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
