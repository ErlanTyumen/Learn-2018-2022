using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? RoomId { get; set; }
        public int ClientId { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Departure { get; set; }
        public decimal? Sum { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateOfBooking { get; set; }

        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
    }
}
