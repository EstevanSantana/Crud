using System.Threading.Tasks;

namespace Crud.BackEnd.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
