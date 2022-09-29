using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.DTOs;
using Chorizo.Models.School;

namespace Chorizo.Services
{
    public class MapperService : AutoMapper.Profile
    {
        public MapperService()
        {
            CreateMap<Person, PersonDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                          .ForMember(dest => dest.Surename, opt => opt.MapFrom(src => src.Surename));
            CreateMap<Subject, SubjectDTO>().ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}