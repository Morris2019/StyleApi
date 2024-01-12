using System;
using System.Collections.Generic;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class BookingUser
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual User User { get; set; }
    }
}
