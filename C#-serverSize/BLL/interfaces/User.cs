
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IUserBLL
    {
        List<DTO.classes.User> getAll();
        int add(DTO.classes.User user);
        bool remove(int id);
        bool upDate(DTO.classes.User user,int id);
        DTO.classes.User getByEmailAndPassword(string email, string password);
        List<DTO.classes.Booking> GetAllTrips(int id);
    }
}
