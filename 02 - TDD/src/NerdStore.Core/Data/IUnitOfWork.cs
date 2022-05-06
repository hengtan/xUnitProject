using System;
using System.Threading.Tasks;
using NerdStore.Core.DomainObject;

namespace NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}