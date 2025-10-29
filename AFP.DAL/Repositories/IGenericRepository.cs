using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFP.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Add(T entity); // Chỉ thêm vào context, chưa lưu
        void Update(T entity);
        void Delete(T entity);
    }
}
