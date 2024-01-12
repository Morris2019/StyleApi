using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanStyleApi.Models
{
    public class UsersBookings
    {
        public BookingItem GetBookingItem { get; set; }
        public Booking GetBooking { get; set; }
        public BookingUser GetBookingUser { get; set; }
        public BusinessService GetBusinessService { get; set; }
        public BusinessServiceLocation GetBusinessServiceLocation { get; set; }
        public BusinessServiceUser GetBusinessServiceUser { get; set; }
        public Location GetLocation { get; set; }
    }
}
