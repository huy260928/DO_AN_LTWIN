using AFP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFP.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // 1. Khai báo Context
        private readonly PictureFixModel _context;

        // 2. Khai báo các Repository
        public IGenericRepository<Project> Projects { get; private set; }
        public IGenericRepository<EditHistory> EditHistories { get; private set; }

        public UnitOfWork(PictureFixModel context)
        {
            _context = context;

            // Khởi tạo các Repository, truyền cùng một Context vào
            Projects = new GenericRepository<Project>(_context);
            EditHistories = new GenericRepository<EditHistory>(_context);

            // *Lưu ý: Nếu bạn có logic truy vấn phức tạp (ví dụ: GetByProjectID) 
            // thì nên tạo ProjectRepository/EditHistoryRepository riêng thay vì GenericRepository.
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
