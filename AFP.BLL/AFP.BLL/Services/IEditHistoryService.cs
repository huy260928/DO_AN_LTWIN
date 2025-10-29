using System.Collections.Generic;
using System.Threading.Tasks;
using AFP.BLL.DTOs;

namespace AFP.BLL.Services
{
    public interface IEditHistoryService
    {
        Task<List<EditHistoryDto>> GetByProjectAsync(int projectId);
        Task<EditHistoryDto> CreateAsync(EditHistoryDto dto);
        Task DeleteAsync(int id);
    }
}
