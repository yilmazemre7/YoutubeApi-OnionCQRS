﻿using YoutubeApi.Application.Interface.Repositories;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Application.Interface.UnitOfWorks
{
    public interface IUnitOfWork<T> : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
