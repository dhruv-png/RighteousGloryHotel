using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RighteousGloryHotel.Models
{
    public class Booking
    {

        public int bookingId { get; set; }
        public int roomId { get; set; }

        public string customerName { get; set; }

        public DateTime dateOfBooking { get; set; }

    }
}
