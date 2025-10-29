namespace AFP.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EditHistory")]
    public partial class EditHistory
    {
        [Key]
        public int HistoryID { get; set; }

        public int ProjectID { get; set; }

        public int StepIndex { get; set; }

        [Required]
        [StringLength(50)]
        public string OperationType { get; set; }

        [Required]
        public string OperationData { get; set; }

        public DateTime DateApplied { get; set; }

        public virtual Project Project { get; set; }
    }
}
