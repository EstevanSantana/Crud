using Crud.BackEnd.Domain.Core.DomainObjects;
using System;

namespace Crud.BackEnd.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
