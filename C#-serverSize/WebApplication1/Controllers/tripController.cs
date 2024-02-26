using bll.interfaces;
using BLL.interfaces;
using DTO.classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class tripController : ControllerBase
    {
        IBookingBll bllBooking;
        ITripBll bllTrip;
        ITripsTypeBll bllTripsTypes;
        public tripController(IBookingBll bllBooking, ITripBll bllTrip, ITripsTypeBll bllTripsTypes)
        {
            this.bllBooking = bllBooking;
            this.bllTrip = bllTrip;
            this.bllTripsTypes = bllTripsTypes;
        }
        //booking
        [HttpPost]
        [Route("addBooking")]
        public bool addBooking(Booking b)
        {
            return this.bllBooking.add(b);
        }

        [HttpDelete]
        [Route("deleteBooking/{id}")]
        public bool deleteBooking(int id)
        {
            return this.bllBooking.remove(id);
        }

        [HttpGet]
        [Route("getAllToTripBooking")]
        public List<Booking> getAllBooking(int id)
        {
            return this.bllBooking.getAllToTrip(id);
        }
        [HttpPut]
        [Route("updateTrip")]
        public bool updateTrip (Trip b,int id)
        {
            return this.bllTrip.update(b,id);   
        }

        [HttpGet]
        [Route("getBookingById")]
        public Booking getBookingById(int id) {
            return this.bllBooking.getByid(id);
        }

        //
        // trip
        [HttpGet]
        [Route("GetAllTrip")]
        public List<Trip> getAlltrips()
        {
            return this.bllTrip.getAll();

        }

        [HttpGet]
        [Route("GetAllTripById/{id}")]
        public Trip getAlltripsById(int id)
        {
            return this.bllTrip.GetById(id);
        }

        [HttpPost]
        [Route("AddTrip")]
        public int addTrip(Trip trip)
        {
            return this.bllTrip.add(trip);
        }

        [HttpDelete]
        [Route("deleteTrip")]
        public bool deleteTrip(int id)
        {
            return this.bllTrip.remove(id);
        }

        [HttpGet]
        [Route("GetInvitesToTrip")]
        public List<Booking> GetInvitesToTrip(int id)
        {
            return this.bllTrip.GetInvitesToTrip(id);
        }
        //tripsTyps
        [HttpGet]
        [Route("getAllTripsTypes")]
        public List<TripsType> getAllTripsTypes()
        {
            return this.bllTripsTypes.getAll();
        }
        [HttpPost]
        [Route("addTripType")]
        public int addTripType(TripsType type)
        {
            return this.bllTripsTypes.add(type);
        }
        [HttpDelete]
        [Route("deleteTripType")]
        public bool deleteTripType(int id)
        {
            return this.bllTripsTypes.remove(id);
        }

    }
}
