
using AutoMapper;
using BLL.interfaces;
using DaL.functions;
using DAl.interfaces;
using DAL.Models;
using DTO;
using DTO.classes;
using DTO.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class fBookingBll: IBookingBll
    {
        IBookingDall dal;
        IMapper mapper;
        ITripDall t;

        public fBookingBll(IBookingDall dal,ITripDall t)
        {
            this.dal = dal;
            this.t = t;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        //public bool add(DTO.classes.Booking booking)
        //{
        //    dal.add(mapper.Map<DTO.classes.Booking, DAL.Models.Booking>(booking));
        //    booking.DateBookink = DateTime.Now;
        //    booking.TimeBooking = (short)DateTime.Now.Hour;
        //     return true;
        //    return false;
        //}
      

        public List<DTO.classes.Booking> getAllToTrip(int id)
        {
            return mapper.Map<List<DAL.Models.Booking>, List<DTO.classes.Booking>>(dal.getAllToTrip(id));
        }

        public DTO.classes.Booking getByid(int id)
        {
            DAL.Models.Booking t = dal.getByid(id);
            if (t != null)
            {
                return mapper.Map<DAL.Models.Booking ,DTO.classes.Booking>(t);
            }
            return null;
        }

        public bool remove(int id)
        {
            return dal.remove(id);

        }



        bool IBookingBll.add(DTO.classes.Booking order)
        {
            List<DTO.classes.Trip> tripList = mapper.Map<List<DAL.Models.Trip>, List<DTO.classes.Trip>>(this.t.getAll());
            DTO.classes.Trip t = tripList.Find(x => x.IdTrip == order.IdTrip);
            if (t != null)
            {
                if (t.DateTrip > DateTime.Now)
                    return dal.add(mapper.Map<DTO.classes.Booking, DAL.Models.Booking>(order));
            }
            return false;
        }
    } 
}