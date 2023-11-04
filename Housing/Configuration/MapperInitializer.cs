using AutoMapper;
using Housing.Data;
using Housing.Model;

namespace Housing.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<State,StateDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }

    }
}
