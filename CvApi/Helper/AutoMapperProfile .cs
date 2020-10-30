using AutoMapper;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;
using CvApi.Models.Entities.ResolvingTables;

namespace CvApi.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<UserSkillDTO, UserSkill>();
            CreateMap<UserSkill, UserSkillDTO>();

            CreateMap<Experience, ExperienceDTO>();
            CreateMap<ExperienceDTO, Experience>();

            CreateMap<JobSkill, JobSkillDTO>();
            CreateMap<JobSkillDTO, JobSkill>();

            CreateMap<JobAdvertisementDTO, JobAdvertisement>();
            CreateMap<JobAdvertisement, JobAdvertisementDTO>();

            CreateMap<Application, ApplicationDTO>();
            CreateMap<ApplicationDTO, Application>();
        }
    }
}
