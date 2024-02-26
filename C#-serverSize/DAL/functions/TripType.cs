using DAl.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class fTripTypeDall : ITripsTypeDall
    {
        public TripsContext db;
        public fTripTypeDall(TripsContext db)
        {
            this.db = db;
        }

        public List<TripsType> getAll()
        {
            return db.TripsTypes.ToList();
        }

        public bool remove(int id)
        {
            try
            {
                var type =db.TripsTypes.FirstOrDefault(c => c.IdType == id);
                db.TripsTypes.Remove(type);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool upDate(TripsType Trip)
        {
            throw new NotImplementedException();
        }

        int ITripsTypeDall.add(TripsType Trip)
        {
            try
            {
                bool cheak= db.TripsTypes.Any(c => c.NameType == Trip.NameType);
                if (cheak==false)
                {
                    var newType = db.TripsTypes.Add(Trip);
                    db.SaveChanges();
                
                  if (newType != null )
                  {
                    return Trip.IdType;
                  }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }
    }
}
