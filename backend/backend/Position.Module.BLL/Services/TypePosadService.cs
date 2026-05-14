using AutoMapper;
using backend.Position.Module.BLL.Dtos;
using backend.Position.Module.BLL.Services.Interfaces;
using backend.Position.Module.DAL.Interface;
using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.BLL.Services
{
    public class TypePosadService : ITypePosadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypePosadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<TypePosadDto> Items, int TotalCount)> GetPagedAsync(
            bool includeArchive, int pageNumber, int pageSize, string sortBy, bool sortDescending)
        {
            var result = await _unitOfWork.TypePosads.GetPagedAsync(
                includeArchive, pageNumber, pageSize, sortBy, sortDescending);

            var dtos = _mapper.Map<IEnumerable<TypePosadDto>>(result.Items);
            return (dtos, result.TotalCount);
        }

        public async Task<TypePosadDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TypePosads.GetByIdAsync(id);
            return _mapper.Map<TypePosadDto>(entity);
        }

        public async Task<int> CreateAsync(CreateTypePosadDto dto)
        {
            var entity = _mapper.Map<TypePosad>(dto);
            var id = await _unitOfWork.TypePosads.CreateAsync(entity);
            await _unitOfWork.SaveAsync(); 
            return id;
        }

        public async Task<bool> UpdateAsync(TypePosadDto dto)
        {
            var entity = _mapper.Map<TypePosad>(dto);
            var result = await _unitOfWork.TypePosads.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<bool> SetStatusAsync(int id, bool active)
        {
            var result = await _unitOfWork.TypePosads.SetStatusAsync(id, active);
            await _unitOfWork.SaveAsync();
            return result;
        }
    }
}