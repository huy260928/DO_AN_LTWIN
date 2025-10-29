using AFP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFP.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Khai báo các Repository cụ thể
        IGenericRepository<Project> Projects { get; }
        IGenericRepository<EditHistory> EditHistories { get; }

        // Phương thức để lưu tất cả thay đổi
        Task<int> CompleteAsync();
    }
}
