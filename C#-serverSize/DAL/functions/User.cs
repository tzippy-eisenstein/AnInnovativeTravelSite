using DAl.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class fUserDall : IUserDall
    {
        public TripsContext db;
        public fUserDall(TripsContext db)
        {
            this.db = db;
        }

        public int add(User user)
        {
            try
            {   
                var newUser =db.Users.Add(user);
                db.SaveChanges();
                if(newUser != null)
                {
                    return user.IdUser;
                }
            }  
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }

        public List<User> getAll()
        {
            return db.Users.ToList();
        }

        public User getByEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = db.Users.First(x => x.UserPassword ==password && x.UserEmail==email);
                if (newUser == null)
                    return null;
                else
                    return newUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public User getByid(int id)
        {
            try
            {
                var newUser = db.Users.First(x => x.IdUser == id);
                if (newUser == null)
                    return null;
                else
                    return newUser;
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
                var user = getByid(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
         }

        public bool upDate(User user, int id)
        {
            User u = (User)db.Users.FirstOrDefault(c => c.IdUser == id);
            if (u != null)
            {
                if (user.UserPhone != "string") { u.UserPhone = user.UserPhone; }
                if (user.UserLastName != "string") { u.UserLastName = user.UserLastName; }
                if (user.UserFirstName != "string") { u.UserFirstName = user.UserFirstName; }
                if (user.UserEmail != "string") { u.UserEmail = user.UserEmail; }
                if (user.UserPassword != "string") { u.UserPassword = user.UserPassword; };
                if (user.UserFirstAid != u.UserFirstAid) { u.UserFirstAid = user.UserFirstAid; }
                db.SaveChanges();
                return true;

            }
            else { return false; }
        }
            public List<Booking> GetAllTrips(int id)
        {
            List<Booking> list = new List<Booking>();
            foreach (var i in db.Bookings)
            {
                if (i.IdUser == id)
                    list.Add(i);
            }
            if (list.Count > 0)
                return list;
            return null;
        }
    }


}
