using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Room
    {
        public Room()
        {
            Orders = new HashSet<Order>();
        }

        public int RoomId { get; set; }
        public int? BranchId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual RoomCategory Category { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
