using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<Company, CompanyDTO>().ReverseMap();
            cfg.CreateMap<Job, JobDTO>().ReverseMap();
            cfg.CreateMap<Job, JobResponseDTO>().ReverseMap();
            cfg.CreateMap<Application, ApplicationDTO>().ReverseMap();
            cfg.CreateMap<Application, ApplicationResponseDTO>().ReverseMap();
            cfg.CreateMap<Job, JobApplicationsDTO>();
            cfg.CreateMap<Application, ApplicationUserDTO>()
               .IncludeBase<Application, ApplicationDTO>()
               .ForMember(d => d.User,o => o.MapFrom(s => s.JobSeeker));
            cfg.CreateMap<Company, CompanyJobDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }
}
