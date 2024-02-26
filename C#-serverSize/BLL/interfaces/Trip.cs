
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.interfaces
{
    public interface ITripBll
    {
        List<DTO.classes.Trip> getAll();
       DTO.classes.Trip GetById(int id);     
        int add(DTO.classes.Trip Trip);
        bool remove(int id);
        bool update(DTO.classes.Trip Trip,int id);

        List<DTO.classes.Booking> GetInvitesToTrip(int id);    
    }
}
