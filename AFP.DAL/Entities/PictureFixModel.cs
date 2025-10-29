using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AFP.DAL.Entities
{
    public partial class PictureFixModel : DbContext
    {
        public PictureFixModel()
            : base("name=PictureFixModel")
        {
        }

        public virtual DbSet<EditHistory> EditHistories { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
