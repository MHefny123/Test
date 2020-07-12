using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApi.Models
{
       public partial class HefnyDBContext : DbContext
    {
        public HefnyDBContext()
        {
        }

        public HefnyDBContext(DbContextOptions<HefnyDBContext> options)
            : base(options)
        {
        }

        
        
        

        public virtual DbSet<Product> Product  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=HefnyDB;User Id=SA;Password=MHefny@550; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

           

          

          


             modelBuilder.Entity<Product>(entity =>
            {

                entity.ToTable("Product");
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProdDesc).HasColumnName("proddesc");

                entity.Property(e => e.ProdName).HasColumnName("prodname");

                entity.Property(e => e.ProdPrice).HasColumnName("prodprice");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedat")
                    .HasColumnType("date");
            });
        }
    }
}

