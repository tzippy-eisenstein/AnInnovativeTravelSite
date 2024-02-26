
using DAl.interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaL.functions
{
    public class fTripDall : ITripDall
    {
        public TripsContext db;
        public fTripDall(TripsContext db)
        {
            this.db = db;
        }
        public int add(Trip trip)
        {
            try
            {
                var newTrip = db.Trips.Add(trip);
                db.SaveChanges();
                if (newTrip != null)
                {
                    return trip.IdTrip;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }
        public List<Trip> getAll()
        {

            
            return db.Trips.Include(p => p.IdTypeNavigation).ToList();
        }

        public Trip GetById(int id)
        {
            try
            {
                var newTrip = db.Trips.Include(p => p.IdTypeNavigation).First(x => x.IdTrip == id);
                if (newTrip == null)
                    return null;
                else
                    return newTrip;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Booking> GetInvitesToTrip(int id)
        {
            List<Booking> list = new List<Booking>();
            foreach (var i in db.Bookings)
            {
                if (i.IdTrip == id)
                    list.Add(i);
            }
            if (list.Count > 0)
                return list;
            return null;
        }

        public bool remove(int id)
        {
            try
            {
                var trip = GetById(id);
                db.Trips.Remove(trip);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool update(Trip Trip,int id)
        {
           Trip t = db.Trips.FirstOrDefault(c => c.IdTrip == id);
            if (t != null)
            {
                if (Trip.DestinationTrip != "string") { t.DestinationTrip = Trip.DestinationTrip; }
                if (Trip.IdType !=0) { t.IdType = Trip.IdType; }
                if (Trip.DateTrip != null) { t.DateTrip = Trip.DateTrip; }
                if (Trip.LeavingTime != null) { t.LeavingTime = Trip.LeavingTime; }
                if (Trip.DurationTrip != null) { t.DurationTrip = Trip.DurationTrip; }
                if (Trip.PlacesAvailable != null) { t.PlacesAvailable = Trip.PlacesAvailable; }
                if (Trip.Price != null) { t.Price = Trip.Price; }
                if (Trip.Image!= "string") { t.Image = Trip.Image; }           
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
    }
    

