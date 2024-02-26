//using dal.functions;

using DAL;
using DAL.Models;
using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
   public interface IBookingBll
    {
        List<DTO.classes.Booking> getAllToTrip(int id );
        bool add(DTO.classes.Booking booking);
        //List<DTO.classes.Booking> add();
        bool remove(int id);
        //bool upDate(Booking booking);
        public DTO.classes.Booking getByid(int id);


    }

}
