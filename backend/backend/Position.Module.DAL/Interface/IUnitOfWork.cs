using backend.Position.Module.DAL.Repositories.Interface;

namespace backend.Position.Module.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ITypePosadRepository TypePosads { get; }

        Task<int> SaveAsync();
    }
}
