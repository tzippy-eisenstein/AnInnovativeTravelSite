using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
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
        public string? typeName { get; set; }

        

    }

}