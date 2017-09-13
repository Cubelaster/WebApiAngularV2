using AutoMapper;
using BL.ViewModels.Account;
using DAL.Contracts.Enumerations;
using DAL.Models.IdentityClasses;
using System;

namespace BL.ViewModels.Mappings.Account
{
    public class AccountViewModelsToEntityMappingProfile : Profile
    {
        public AccountViewModelsToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, ApplicationUser>()
                .ForMember(user => user.DateRegistered, map => map.MapFrom(o => DateTime.UtcNow))
                .ForMember(user => user.Status, map => map.MapFrom(o => DatabaseEntityStatusEnum.Active));
        }
    }
}
