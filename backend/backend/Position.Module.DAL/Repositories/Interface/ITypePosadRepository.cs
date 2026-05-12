using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.DAL.Repositories.Interface
{
    public interface ITypePosadRepository
    {
        // 1. Отримати список з пагінацією та фільтром по активності
        // returns: список посад + загальна кількість (для фронтенд-пагінації)
        Task<(IEnumerable<TypePosad> Items, int TotalCount)> GetPagedAsync(
            bool includeArchive,
            int pageNumber,
            int pageSize,
            string sortBy,
            bool sortDescending);

        // 2. Створення запису
        Task<int> CreateTypePosad(TypePosad entity);

        // 3. Редагування запису
        Task<bool> UpdateTypePosad(TypePosad entity);

        // 4. Перевірка перед архівуванням (SQL CASE з вашого ТЗ)
        //Task<bool> HasActivePosad(int typePosadId);

        // Зміна статусу активності (використовується для архівування та розархівування)
        Task<bool> SetStatusPosad(int id, bool active);

        // 6. Отримання по ID
        Task<TypePosad?> GetTypePosadById(int id);
    }
}
