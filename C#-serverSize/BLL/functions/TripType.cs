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

namespace BLL.functions
{
    public class fTripTypeBll : ITripsTypeBll
    {
        ITripsTypeDall dal;
        IMapper mapper;

        public fTripTypeBll(ITripsTypeDall dal)
        {
            this.dal = dal;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            mapper = config.CreateMapper();
        }
        public int  add(DTO.classes.TripsType Trip)
        {
            try
            {
                var mapType = mapper.Map<DAL.Models.TripsType>(Trip);
                return dal.add(mapType);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<DTO.classes.TripsType> getAll()
        {
            return mapper.Map<List<DAL.Models.TripsType>, List<DTO.classes.TripsType>>(dal.getAll());
        }

        public bool remove(int id)
        {
            return dal.remove(id);  
        }

    
    }
}
