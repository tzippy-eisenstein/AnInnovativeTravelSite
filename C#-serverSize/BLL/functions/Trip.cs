using AutoMapper;
using bll.interfaces;
using DAl.interfaces;
using DAL.Models;
using DTO.classes;
using DTO.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll.functions
{
    public class fTripBll : ITripBll

    {
        ITripDall dal;
         IMapper mapper;
    public fTripBll(ITripDall dal)
        {
            this.dal = dal;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            mapper = config.CreateMapper();
        }
        public int add(DTO.classes.Trip trip)
        {
            try
            {
              var mapTrip = mapper.Map<DAL.Models.Trip>(trip);
               return dal.add(mapTrip);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<DTO.classes.Trip> getAll()
        {
            return mapper.Map<List<DAL.Models.Trip>, List<DTO.classes.Trip>>(dal.getAll());
        }

        public DTO.classes.Trip GetById(int id)
        {
            DAL.Models.Trip t=dal.GetById(id);
            if (t != null)
            {
                return mapper.Map<DAL.Models.Trip, DTO.classes.Trip>(t);
            }
            return null;
        }
        public bool remove(int id)
        {
            return dal.remove(id);
        }

        public bool update(DTO.classes.Trip Trip,int id)
        {
            var mapTrip = mapper.Map<DAL.Models.Trip>(Trip);
            if (mapTrip != null)
                return dal.update(mapTrip,id);
            else
                return
                    false;
        }

        List<DTO.classes.Booking> GetInvitesToTrip(int id)
        {
            return mapper.Map<List<DAL.Models.Booking>, List<DTO.classes.Booking>>(dal.GetInvitesToTrip(id));
        }

        List<DTO.classes.Booking> ITripBll.GetInvitesToTrip(int id)
        {
            return  mapper.Map<List<DAL.Models.Booking>,List<DTO.classes.Booking>>(dal.GetInvitesToTrip(id));
        }
    }
}

