using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TripsType
{
    public short IdType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
