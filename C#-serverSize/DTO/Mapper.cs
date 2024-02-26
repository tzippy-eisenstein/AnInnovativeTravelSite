using AutoMapper;
using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DTO.mapper
{
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
        

            CreateMap<DTO.classes.Trip, DAL.Models.Trip>()
               .ForMember(dest => dest.IdTrip, opt => opt.Ignore());
            CreateMap<DAL.Models.Trip, DTO.classes.Trip>()
               .ForMember(dest => dest.typeName, opt => opt.MapFrom(src => src.IdTypeNavigation.NameType));


            CreateMap<DAL.Models.TripsType, DTO.classes.TripsType>();
            CreateMap<DTO.classes.TripsType,DAL.Models.TripsType>()
                 .ForMember(dest => dest.IdType, opt => opt.Ignore());


            CreateMap<DTO.classes.User, DAL.Models.User>()
                 .ForMember(dest => dest.IdUser, opt => opt.Ignore());
            CreateMap<DAL.Models.User, DTO.classes.User>();

            CreateMap<DTO.classes.Booking, DAL.Models.Booking>()
          .ForMember(dest => dest.IdBooking, opt => opt.Ignore());
            CreateMap<DAL.Models.Booking, DTO.classes.Booking>()
                .ForMember(dest=>dest.TripName,opt=>opt.MapFrom(s=>s.IdTripNavigation.DestinationTrip))
                .ForMember(dest => dest.fullName, opt =>opt.MapFrom(src => src.IdUserNavigation.UserFirstName) //+ " " + src.IdUserNavigation.UserLastName);//
                ) ;
        }

        }
}

