using Microsoft.EntityFrameworkCore;
using backend.Position.Module.DAL.Models;

namespace backend.Position.Module.DAL.Repositories
{
    public class GenericRepository<T> : BaseRepository where T : Entity
    {
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TypePosadDbContext context) : base(context)
        {
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
