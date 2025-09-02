using YoutubeApi.Application.Interface.Repositories;
using YoutubeApi.Application.Interface.UnitOfWorks;
using YoutubeApi.Persistence.Context;
using YoutubeApi.Persistence.Repositories;

namespace YoutubeApi.Persistence.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T>
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public int Save() => _context.SaveChanges();
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork<T>.GetReadRepository<T>() => new ReadRepository<T>(_context);

        IWriteRepository<T> IUnitOfWork<T>.GetWriteRepository<T>() => new WriteRepository<T>(_context);
    }
}
