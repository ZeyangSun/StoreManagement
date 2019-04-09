namespace StoreManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModelNew")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Stores)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       

      
    }
}
