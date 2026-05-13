using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.DAL.Repositories.Interface
{
    public interface ITypePosadRepository
    {
        Task<(IEnumerable<TypePosad> Items, int TotalCount)> GetPagedAsync(
            bool includeArchive,
            int pageNumber,
            int pageSize,
            string sortBy,
            bool sortDescending);
        Task<int> CreateAsync(TypePosad entity);
        Task<bool> UpdateAsync(TypePosad entity);
        // Перевірка перед архівуванням (SQL CASE з вашого ТЗ)
        //Task<bool> HasActivePosad(int typePosadId);
        Task<bool> SetStatusAsync(int id, bool active);
        Task<TypePosad?> GetByIdAsync(int id);
    } 
}
