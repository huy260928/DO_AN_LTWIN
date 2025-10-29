using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AFP.BLL.DTOs;
using AFP.BLL.Mappers;
using AFP.DAL.Entities;
using AFP.DAL.Repositories;

namespace AFP.BLL.Services
{
    public class EditHistoryService : IEditHistoryService
    {
        // 1. THÀNH VIÊN PRIVATE: Gi? tham chi?u ??n UnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        // 2. FIX L?I CONSTRUCTOR (CS1729): Nh?n IUnitOfWork t? bên ngoài
        public EditHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // --- Logic CRUD ???c refactor ?? dùng Repository ---

        public async Task<List<EditHistoryDto>> GetByProjectAsync(int projectId)
        {
            // Thay th? "using (var db = new PictureFixModel())" b?ng Repository
            var list = await _unitOfWork.EditHistories
                                        .GetAllAsync(); // Gi? ??nh GetAllAsync l?y t?t c?

            // L?c và s?p x?p (Logic BLL)
            return list.Where(h => h.ProjectID == projectId)
                       .OrderBy(h => h.StepIndex)
                       .Select(EntityMapper.ToDto)
                       .ToList();

            // *L?U Ý: N?u repository c?a b?n có hàm GetByProjectIDAsync, hãy dùng nó ?? t?i ?u.*
        }

        public async Task<EditHistoryDto> CreateAsync(EditHistoryDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            // 1. Logic nghi?p v?: C?p nh?t ngày tháng
            var entity = EntityMapper.ToEntity(dto);
            entity.DateApplied = dto.DateApplied == default(DateTime) ? DateTime.Now : dto.DateApplied;

            // 2. G?I REPOSITORY: Thêm Entity vào context
            _unitOfWork.EditHistories.Add(entity);

            // 3. G?I UNIT OF WORK: L?u thay ??i (ch? m?t l?n)
            await _unitOfWork.CompleteAsync();

            return EntityMapper.ToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            // 1. G?I REPOSITORY: L?y Entity
            var existing = await _unitOfWork.EditHistories.GetByIdAsync(id);

            if (existing == null) return;

            // 2. G?I REPOSITORY: Xóa kh?i context
            _unitOfWork.EditHistories.Delete(existing);

            // 3. G?I UNIT OF WORK: L?u thay ??i
            await _unitOfWork.CompleteAsync();
        }
    }
}
