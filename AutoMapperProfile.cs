using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dto;
using dotnet_rpg.Dto.Character;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<character,GetCharacterDto>();
             CreateMap<AddCharacterDto,character>();
             CreateMap<UpdateCharacterDto,character>();
        }
    }
}