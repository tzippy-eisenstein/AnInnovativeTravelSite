//using dal.models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.interfaces
{
    public interface ITripsTypeDall
    {
        List<TripsType> getAll();
        int add(TripsType Trip);
        bool remove(int id);
        bool upDate(TripsType Trip);
    }
}
