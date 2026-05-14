using backend.Position.Module.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Position.Module.DAL.Repositories.Interface
{
    public class TypePosadRepository : GenericRepository<TypePosad>, ITypePosadRepository
    {

        public TypePosadRepository(TypePosadDbContext context) : base(context) { }

        public async Task<(IEnumerable<TypePosad> Items, int TotalCount)> GetPagedAsync(
            bool includeArchive,
            int pageNumber,
            int pageSize,
        string sortBy,
            bool sortDescending)
        {
            var query = _dbSet.AsQueryable();

            // Фільтрація архівованих
            if (!includeArchive)
            {
                query = query.Where(x => x.Active);
            }

            // Рахуємо загальну кількість для фронтенд-пагінації
            int totalCount = await query.CountAsync();

            query = sortDescending
                ? query.OrderByDescending(x => x.Id)
                : query.OrderBy(x => x.Id);
            // Пагінація
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<int> CreateAsync(TypePosad entity)
        {
            entity.Active_BOS = entity.Active_AD;
            entity.Active = true;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(TypePosad entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        // Перевірка наявності активних посад перед архівуванням
        //public async Task<bool> HasActivePosad(int typePosadId)
        //{
        //    // Використовуємо SQL CASE логіку через AnyAsync (ефективний EXISTS)
        //    // Примітка: Переконайтеся, що DbSet<SpisokPosad> додано в DbContext
        //    return await _context.Set<SpisokPosad>()
        //        .AnyAsync(p => p.IDTpPosad == typePosadId
        //                    && p.Active == 1
        //                    && p.History == 1);
        //}

        public async Task<bool> SetStatusAsync(int id, bool active)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            entity.Active = active;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TypePosad?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}

