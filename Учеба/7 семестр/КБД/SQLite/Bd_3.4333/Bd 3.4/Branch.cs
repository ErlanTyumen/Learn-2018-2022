using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Branch
    {
        public Branch()
        {
            Employees = new HashSet<Employee>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? DirectorId { get; set; }

        public virtual Employee Director { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
