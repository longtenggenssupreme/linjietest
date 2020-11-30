using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace EFCOREDB
{
    public class DynamicContext : DbContext
    {
        public DateTime CreateDateTime { get; set; }//为了区分不同的表
        public DbSet<Test> Tests { get; set; }

        //sqlserver连接字符串 Server=(localdb)\\mssqllocaldb;Database=DynamicContext;Trusted_Connection=True;
        //sqlserver连接字符串 server=127.0.0.1;database=DynamicContext;user=zy;password=zy;

        //oracle连接字符串 Data Source=127.0.0.1:1521/orcl;User Id=zy;Password=zy;
        //"DbConnectString": "Data Source=127.0.0.1:1521/orcl;User Id=zy;Password=zy;",
        //"DefaultSchema": "ZY", 
        //"DbVersion": "11", 

        //mysql连接字符串 server=127.0.0.1;database=DynamicContext;user=zy;password=zy;
        //public static string DbConnectString = "(localdb)\\mssqllocaldb;Database=DynamicContext;Trusted_Connection=True;";
        //如果是oracle的话，Oracle连接字符串中并不包含数据名称，其实DefaultSchema就是数据库名称，音系需要下面的两个DefaultSchema，DbVersion字段
        public static string DefaultSchema = "ZY";//
        public static string DbVersion = "11";
        DbType dbType = DbType.SqlServer;

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (dbType)
            {
                case DbType.SqlServer:
                    string DbConnectStringSqlServer = "(localdb)\\mssqllocaldb;Database=DynamicContext;Trusted_Connection=True;";
                    DbConnectStringSqlServer = "server=127.0.0.1;database=DynamicContext;user=zy;password=zy;";
                    DbConnectStringSqlServer = "server=127.0.0.1;database=DynamicContext;user=sa;password=sa123;";
                    optionsBuilder.UseSqlServer(DbConnectStringSqlServer)
                        .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();

                    //SQL SERVER 2012/ 2014 分页，用 OFFSET，FETCH NEXT改写ROW_NUMBER的用法
                    //从 SQL SERVER 2000 那个大家还在写TOP的年代，到2005的ROW_NUMBER，再到2012的OFFSET  FETCH 
                    //optionsBuilder.UseSqlServer(DbConnectStringSqlServer,b=>b.UseRowNumberForPaging())
                    //  .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
                    break;
                case DbType.MySql:
                    string DbConnectStringMySql = "server=127.0.0.1;database=DynamicContext;user=zy;password=zy;";
                    DbConnectStringMySql = "server=127.0.0.1;database=DynamicContext;user=root;password=123456;";
                    optionsBuilder.UseMySql(DbConnectStringMySql)
                        .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
                    break;
                case DbType.Oracle:
                    string DbConnectStringOracle = "Data Source=127.0.0.1:1521/orcl;User Id=zy;Password=zy;";
                    optionsBuilder.UseOracle(DbConnectStringOracle, t=>t.UseOracleSQLCompatibility(DbVersion))
                        .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
                    break;
                default:
                    throw new Exception("数据库不匹配。。。");
            }
        }
        //=> optionsBuilder.UseMySql(DbConnectString).ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
         //=> optionsBuilder.UseOracle(DbConnectString).ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
         //=> optionsBuilder.UseSqlServer(DbConnectString).ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseInMemoryDatabase("DynamicContext")
        //.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Database.IsOracle())
            {
                modelBuilder.HasDefaultSchema(DefaultSchema);
            }

            modelBuilder.Entity<Test>(b =>
            {
                b.ToTable(CreateDateTime.ToString("yyyyMMdd"));
                b.HasKey(p => p.Id);
                //b.Property(p => p.Id).HasColumnType("int").ValueGeneratedOnAdd();
                //b.Property(p => p.Id).HasColumnType("int");
                b.Property(p => p.Title).HasMaxLength(20);
                b.Property(p => p.Content).HasMaxLength(500);
            });
        }
        #endregion
    }
    public enum DbType
    {
        SqlServer,
        MySql,        
        Oracle
    }
}
