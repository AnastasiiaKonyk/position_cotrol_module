using AutoMapper;
using backend.Position.Module.BLL.Dtos;
using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.BLL.Map
{
    public class TypePosadMapping: Profile
    {
        public TypePosadMapping()
        {
            CreateMap<TypePosad, TypePosadDto>();
            CreateMap<CreateTypePosadDto, TypePosad>();
            CreateMap<TypePosadDto, TypePosad>();
        }
    }
}
