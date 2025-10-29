using System;

namespace AFP.BLL.DTOs
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string OriginalFilePath { get; set; }
        public string LastSavedPath { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
