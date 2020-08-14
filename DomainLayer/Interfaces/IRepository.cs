using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(T element);
        Task<T> Add(T element);
    }
}
