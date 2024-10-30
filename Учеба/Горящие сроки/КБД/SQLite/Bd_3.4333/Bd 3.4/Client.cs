using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
