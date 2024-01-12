using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrbanStyleApi.Models;

namespace UrbanStyleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersBookingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public UsersBookingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/UsersBookings
        [HttpGet]
        public IEnumerable<UsersBookings> GetUsersBookings()
        {
            List<Booking> listbookings = _context.Bookings.ToList();
            List<BookingItem> listbookingitem = _context.BookingItems.ToList();
            List<BookingUser> listbookinguser = _context.BookingUsers.ToList();
            List<BusinessService> listbusinessservice = _context.BusinessServices.ToList();
            List<BusinessServiceLocation> listbusinesslocation = _context.BusinessServiceLocations.ToList();
            List<BusinessServiceUser> listbusinesssusers = _context.BusinessServiceUsers.ToList();
            List<Location> listlocation = _context.Locations.ToList();

            var usersbooking = (from bookusers in listbookinguser
                               join book in listbookings on bookusers.BookingId equals book.Id into bookuser
                               from book in bookuser.DefaultIfEmpty()
   
                               select new UsersBookings(){ GetBookingUser = bookusers, GetBooking = book }).ToList();

            return usersbooking;
        }
    }
}
