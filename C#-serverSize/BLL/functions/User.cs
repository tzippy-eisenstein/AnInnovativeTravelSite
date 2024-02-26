using AutoMapper;
using BLL.interfaces;
using DAl.interfaces;
using DAL.Models;
using DTO.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class fUserBll : IUserBLL

    {
        IUserDall dal;
        IMapper mapper;

        public fUserBll(IUserDall dal)
        {
            this.dal = dal;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            mapper = config.CreateMapper();
        }

        public int add(DTO.classes.User user)
        {
            try
            {
                var mapUser = mapper.Map<DAL.Models.User>(user);
                return dal.add(mapUser);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

     
        public List<DTO.classes.User> getAll()
        {
            return mapper.Map<List<User>, List<DTO.classes.User>>(dal.getAll());
        }

        public DTO.classes.User getByEmailAndPassword(string email, string password)
        {
           User u = dal.getByEmailAndPassword(email, password);
            if (u != null)
            {
                return mapper.Map<DAL.Models.User,DTO.classes.User>(u);
            }
            return null;

        }

        public bool remove(int id)
        {
            return dal.remove(id);
        }
        public List<DTO.classes.Booking> GetAllTrips(int id)
        {
            return mapper.Map<List<Booking>, List<DTO.classes.Booking>>(dal.GetAllTrips(id));
        }

        public bool upDate(DTO.classes.User user, int id)
        {
            var mapUser = mapper.Map<DAL.Models.User>(user);
            if (mapUser != null)
                return dal.upDate(mapUser,id);
            else
                return
                    false;
        }
    }
}
