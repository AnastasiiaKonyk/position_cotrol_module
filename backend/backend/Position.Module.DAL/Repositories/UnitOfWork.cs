using backend.Position.Module.DAL.Interface;
using backend.Position.Module.DAL.Repositories.Interface;

namespace backend.Position.Module.DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly TypePosadDbContext _context;
        public ITypePosadRepository TypePosads { get; }
        public UnitOfWork(TypePosadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            TypePosads = new TypePosadRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
    }
}

