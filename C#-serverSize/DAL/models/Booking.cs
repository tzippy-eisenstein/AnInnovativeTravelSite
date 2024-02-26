using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Booking
{
    public short IdBooking { get; set; }

    public short? IdUser { get; set; }

    public DateTime? Datebooking { get; set; }

    public short? TimeBooking { get; set; }

    public short? IdTrip { get; set; }

    public short? Places { get; set; }

    public virtual Trip? IdTripNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
