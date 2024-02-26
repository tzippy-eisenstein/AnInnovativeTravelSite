using DAl.interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class FBookingDall : IBookingDall
    {
        public TripsContext db;
        public FBookingDall(TripsContext db)
        {

            this.db = db;
        }
        public List<Booking> getAllToTrip(int id)
        {

            List<Booking> result = new List<Booking>();
            foreach (Booking booking in db.Bookings)
            {
                if (id == booking.IdBooking)
                    result.Add(booking);
            }
            return result;
        }
        //האם התאריך רלוונטי
        public static bool checkDate(DateTime? date)
        {
            if (date < DateTime.Now)
                return false;
            return true;
        }
        public async Task<bool> add(Booking order)
        {
            try
            {
                var t = db.Trips.ToList().Find(x => x.IdTrip == order.IdTrip);
                if (t != null && t.PlacesAvailable >= order.Places)
                {
                    order.Datebooking = DateTime.Today;
                    //order.TimeBooking = new TimeSpan(DateTime.Now.Hour);
                    db.Add(order);
                    t.PlacesAvailable -= order.Places;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        //הוספה
        //public bool add(Booking booking)

        //{
        //    if (checkDate(booking.Datebooking) && booking.IdTripNavigation.PlacesAvailable - booking.Places >= 0)
        //    {
        //        booking.Datebooking = DateTime.Now;
        //        db.Bookings.Add(booking);

        //        if (booking.IdTripNavigation != null && booking.IdTripNavigation.PlacesAvailable != null)
        //        {
        //            var a = booking.IdTripNavigation.PlacesAvailable;
        //            booking.IdTripNavigation.PlacesAvailable -= booking.Places;
        //        }

        //        db.SaveChanges();

        //        return true;
        //    }
        //    return false;
        //}


        public Booking getByid(int id)
        {
            try
            {
                var newBooking = db.Bookings.Include(p => p.IdUserNavigation).
                             Include(p => p.IdTripNavigation).First(x => x.IdBooking == id);
                if (newBooking == null)
                    return null;
                else
                    return newBooking;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool remove(int id)
        {
            try
            {
                Booking o = db.Bookings.FirstOrDefault(x => x.IdBooking == id);
                if (o != null)
                {
                    Trip t = db.Trips.FirstOrDefault(x => x.IdTrip == o.IdTrip);
                    if (t.DateTrip > DateTime.Now)
                    {
                        db.Bookings.Remove(o);
                        t.PlacesAvailable = (short)(t.PlacesAvailable - o.Places);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public bool upDate(Booking booking)
        {
            throw new NotImplementedException();
        }

        bool IBookingDall.add(Booking order)
        {
            try
            {
                var t = db.Trips.ToList().Find(x => x.IdTrip == order.IdTrip);
                if (t != null && t.PlacesAvailable >= order.Places)
                {
                    order.Datebooking = DateTime.Today;
                    //order.TimeBooking = new TimeSpan(DateTime.Now.Hour);
                    db.Add(order);
                    t.PlacesAvailable -= order.Places;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //    bool IBookingDall.add(Booking booking)
        //    {
        //        if (checkDate(booking.Datebooking) )
        //        {
        //            booking.Datebooking = DateTime.Now;

        //            db.Bookings.Add(booking);

        //            if (booking.IdTripNavigation != null && booking.IdTripNavigation.PlacesAvailable != null)
        //            {
        //                var a = booking.IdTripNavigation.PlacesAvailable;
        //                booking.IdTripNavigation.PlacesAvailable -= booking.Places;
        //            }

        //            db.SaveChanges();
        //            return true;
        //        }
        //        return false;
        //    }
        //}
    }
}