using backend.Position.Module.BLL.Dtos;

namespace backend.Position.Module.BLL.Services.Interfaces
{
    public interface ITypePosadService
    {
        // Повертаємо список DTO та загальну кількість для пагінації
        Task<(IEnumerable<TypePosadDto> Items, int TotalCount)> GetPagedAsync(
            bool includeArchive, int pageNumber, int pageSize, string sortBy, bool sortDescending);

        Task<TypePosadDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateTypePosadDto dto);
        Task<bool> UpdateAsync(TypePosadDto dto);
        Task<bool> SetStatusAsync(int id, bool active);
    }
}