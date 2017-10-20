using AutoMapper;
using DAL.Contracts.Enumerations;
using DAL.Models.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BL.Mappers
{
    public class ClaimsMapper : Profile
    {
        public ClaimsMapper()
        {
            CreateMap<Claim, Claims>()
                .ForMember(claim => claim.DateCreated, map => map.MapFrom(o => DateTime.UtcNow))
                .ForMember(claim => claim.Status, map => map.MapFrom(o => DatabaseEntityStatusEnum.Active));

            CreateMap<Claims, Claim>();
        }
    }
}
