using System.Collections.Generic;
using System.Threading.Tasks;
using AFP.BLL.DTOs;

namespace AFP.BLL.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetByIdAsync(int id);
        Task<ProjectDto> CreateAsync(ProjectDto dto);
        Task UpdateAsync(ProjectDto dto);
        Task DeleteAsync(int id);
    }
}
