using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Services
{
    public interface IPersonRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        Task<T> GetInterests(int id);

        Task<T> GetLinks(int id);
    }
}
