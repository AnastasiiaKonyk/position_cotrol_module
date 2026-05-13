namespace backend.Position.Module.DAL.Repositories
{
    public class BaseRepository
    {
        protected readonly TypePosadDbContext _context;

        protected BaseRepository(TypePosadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
