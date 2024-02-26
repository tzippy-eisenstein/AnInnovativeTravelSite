//using dal.functions;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.interfaces
{
   public interface IBookingDall
    {
        List<Booking> getAllToTrip(int id );
        bool add(Booking booking);
        bool remove(int id);
        bool upDate(Booking booking);
        public Booking getByid(int id);
    }
    
}
