using AutoMapper;
using backend.Position.Module.BLL.Dtos;
using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.BLL.Map
{
    public class TypePosadMappingv: Profile
    {
        public TypePosadMappingv()
        {
            CreateMap<TypePosad, TypePosadDto>();
            CreateMap<CreateTypePosadDto, TypePosad>();
        }
    }
}
