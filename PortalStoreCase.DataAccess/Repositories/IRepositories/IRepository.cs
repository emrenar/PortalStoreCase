
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetEntityByIdAsync(int id);
        void Remove(int id);
        void Add(T entity);
        void Update(T entity);
        void Save();
        void SaveAsync();
    }
}
