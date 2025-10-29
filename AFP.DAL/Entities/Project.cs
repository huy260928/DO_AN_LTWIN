namespace AFP.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            EditHistories = new HashSet<EditHistory>();
        }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(255)]
        public string ProjectName { get; set; }

        [Required]
        public string OriginalFilePath { get; set; }

        public string LastSavedPath { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EditHistory> EditHistories { get; set; }
    }
}
