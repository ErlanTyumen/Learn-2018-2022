using System;
using System.Collections.Generic;

#nullable disable

namespace Bd_3._4
{
    public partial class RoomCategory
    {
        public RoomCategory()
        {
            Rooms = new HashSet<Room>();
        }

        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal PriceForDay { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
