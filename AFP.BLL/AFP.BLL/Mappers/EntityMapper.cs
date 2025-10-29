using System;
using AFP.BLL.DTOs;
using AFP.DAL.Entities;

namespace AFP.BLL.Mappers
{
    public static class EntityMapper
    {
        public static ProjectDto ToDto(Project p)
        {
            if (p == null) return null;
            return new ProjectDto
            {
                ProjectID = p.ProjectID,
                ProjectName = p.ProjectName,
                OriginalFilePath = p.OriginalFilePath,
                LastSavedPath = p.LastSavedPath,
                DateCreated = p.DateCreated,
                DateModified = p.DateModified
            };
        }

        public static Project ToEntity(ProjectDto dto)
        {
            if (dto == null) return null;
            return new Project
            {
                ProjectID = dto.ProjectID,
                ProjectName = dto.ProjectName,
                OriginalFilePath = dto.OriginalFilePath,
                LastSavedPath = dto.LastSavedPath,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified
            };
        }

        public static EditHistoryDto ToDto(EditHistory h)
        {
            if (h == null) return null;
            return new EditHistoryDto
            {
                HistoryID = h.HistoryID,
                ProjectID = h.ProjectID,
                StepIndex = h.StepIndex,
                OperationType = h.OperationType,
                OperationData = h.OperationData,
                DateApplied = h.DateApplied
            };
        }

        public static EditHistory ToEntity(EditHistoryDto dto)
        {
            if (dto == null) return null;
            return new EditHistory
            {
                HistoryID = dto.HistoryID,
                ProjectID = dto.ProjectID,
                StepIndex = dto.StepIndex,
                OperationType = dto.OperationType,
                OperationData = dto.OperationData,
                DateApplied = dto.DateApplied
            };
        }
    }
}
