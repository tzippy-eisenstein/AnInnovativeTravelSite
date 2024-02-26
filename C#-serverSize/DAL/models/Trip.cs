using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
{
    public short IdTrip { get; set; }

    public string? DestinationTrip { get; set; }

    public short? IdType { get; set; }

    public DateTime? DateTrip { get; set; }

    public short? LeavingTime { get; set; }

    public short? DurationTrip { get; set; }

    public short? PlacesAvailable { get; set; }

    public short? Price { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual TripsType? IdTypeNavigation { get; set; }

    public static Task<List<Trip>> GetAll()
    {
        throw new NotImplementedException();
    }
}
