﻿using AutoMapper;
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

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<UserSkillDTO, UserSkill>();
            CreateMap<UserSkill, UserSkillDTO>();

            CreateMap<Experience, ExperienceDTO>();
            CreateMap<ExperienceDTO, Experience>();
        }
    }
}
