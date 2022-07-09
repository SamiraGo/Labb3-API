using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        Task<T> Add(T newEntity);

        //Task<T> Update(T Entity);

        //Task<T> Delete(int id);
    }
}
