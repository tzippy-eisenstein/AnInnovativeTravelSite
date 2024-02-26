
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.interfaces
{
    public interface ITripsTypeBll
    {
        List<DTO.classes.TripsType> getAll();
        int add(DTO.classes.TripsType Trip);
        bool remove(int id);
    }
}
