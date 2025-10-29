using System;

namespace AFP.BLL.DTOs
{
    public class EditHistoryDto
    {
        public int HistoryID { get; set; }
        public int ProjectID { get; set; }
        public int StepIndex { get; set; }
        public string OperationType { get; set; }
        public string OperationData { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
