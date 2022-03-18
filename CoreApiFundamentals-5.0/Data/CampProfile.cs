using AutoMapper;
using CoreCodeCamp.Model;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>();
        }
    }
}
