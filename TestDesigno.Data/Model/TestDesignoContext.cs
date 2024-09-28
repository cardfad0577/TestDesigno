using Microsoft.EntityFrameworkCore;
using System;
using TestDesigno.Data.Entities;

namespace TestDesigno.Data.Model
{
    public class TestDesignoContext : DbContext
    {
        public TestDesignoContext(DbContextOptions<TestDesignoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Sueldo)
                      .HasColumnType("decimal(18,2)"); 
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
