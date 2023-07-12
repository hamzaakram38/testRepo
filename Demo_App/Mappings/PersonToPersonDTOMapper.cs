using AutoMapper;
using Demo_App.Models;

namespace Demo_App.Mappings
{
    public class PersonToPersonDTOMapper
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.FirstName + " "+ src.LastName));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
