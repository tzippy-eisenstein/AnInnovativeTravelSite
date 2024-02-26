using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public partial class Booking
    {
        public short IdBooking { get; set; }

        public short? IdUser { get; set; }

        public DateTime? DateBookink { get; set; }

        public short? TimeBooking { get; set; }

        public short? IdTrip { get; set; }

        public short? Places { get; set; }

        public string? fullName { get; set; }
        public string? TripName { get; set; }
        public DateTime? DateTrip { get; set; }
    }
}