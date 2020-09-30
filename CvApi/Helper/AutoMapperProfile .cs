using AutoMapper;
using CvApi.Models;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;

namespace CvApi.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
