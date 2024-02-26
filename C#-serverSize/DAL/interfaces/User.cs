using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.interfaces
{
    public interface IUserDall
    {
       List<User> getAll();
       User getByEmailAndPassword (string email,string password) ;
       int add(User user);
       bool remove(int id);
       bool upDate(User user,int id);
       List<Booking> GetAllTrips(int id);
    }
}
    