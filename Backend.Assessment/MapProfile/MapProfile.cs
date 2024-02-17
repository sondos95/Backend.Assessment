using AutoMapper;
using Backend.Assessment.Application.Requests;
using Backend.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Api.MapProfile
{
    public class MapProfile : Profile
    {
        /// <summary>
        /// Using Map Profile for AutoMapper mapping view models to entity
        /// </summary>
        public MapProfile()
        {
            CreateMap<Driver, CreateDriverViewModel>().ReverseMap();
            CreateMap<Driver, UpdateDriverViewModel>().ReverseMap();

        }
    }
}
