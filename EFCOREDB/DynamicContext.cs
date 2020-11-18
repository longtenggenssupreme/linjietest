using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace EFCOREDB
{
    public class DynamicContext : DbContext
    {
        public DateTime CreateDateTime { get; set; }//为了区分不同的表
        public DbSet<Test> Tests { get; set; }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DynamicContext;Trusted_Connection=True;")
          .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseInMemoryDatabase("DynamicContext")
        //.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(b =>
            {
                b.ToTable(CreateDateTime.ToString("yyyyMMdd"));
                b.HasKey(p => p.Id);
            });
        }
        #endregion
    }
}
