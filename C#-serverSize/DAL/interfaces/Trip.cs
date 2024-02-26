//using dalmodels;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.interfaces
{
    public interface ITripDall
    {
        List<Trip> getAll();
        Trip GetById(int id);
        int add(Trip Trip);
        bool remove(int id);
        bool update(Trip Trip,int id);
        List<Booking> GetInvitesToTrip(int id);
        
    }
}
