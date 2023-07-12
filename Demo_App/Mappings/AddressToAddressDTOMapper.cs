using AutoMapper;
using Demo_App.Models;

namespace Demo_App.Mappings
{
    public class AddressToAddressDTOMapper
    {
        public static  Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.fullAddress, act => act.MapFrom(src => src.House + " " + src.Street+ " "+ src.City+ " "+ src.State + " " +src.Country));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
