using Linjie.NET5.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linjie.NET5.DAL
{
    public partial class LinjieNET5DALDbContext : DbContext
    {
        public LinjieNET5DALDbContext()
        {
        }

        public LinjieNET5DALDbContext(DbContextOptions<LinjieNET5DALDbContext> options) : base(options)
        {
        }

        #region Dbset
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JdCommodity001> JdCommodity001s { get; set; }
        public virtual DbSet<JdCommodity002> JdCommodity002s { get; set; }
        public virtual DbSet<JdCommodity003> JdCommodity003s { get; set; }
        public virtual DbSet<JdCommodity004> JdCommodity004s { get; set; }
        public virtual DbSet<JdCommodity005> JdCommodity005s { get; set; }
        public virtual DbSet<JdCommodity006> JdCommodity006s { get; set; }
        public virtual DbSet<JdCommodity007> JdCommodity007s { get; set; }
        public virtual DbSet<JdCommodity008> JdCommodity008s { get; set; }
        public virtual DbSet<JdCommodity009> JdCommodity009s { get; set; }
        public virtual DbSet<JdCommodity010> JdCommodity010s { get; set; }
        public virtual DbSet<JdCommodity011> JdCommodity011s { get; set; }
        public virtual DbSet<JdCommodity012> JdCommodity012s { get; set; }
        public virtual DbSet<JdCommodity013> JdCommodity013s { get; set; }
        public virtual DbSet<JdCommodity014> JdCommodity014s { get; set; }
        public virtual DbSet<JdCommodity015> JdCommodity015s { get; set; }
        public virtual DbSet<JdCommodity016> JdCommodity016s { get; set; }
        public virtual DbSet<JdCommodity017> JdCommodity017s { get; set; }
        public virtual DbSet<JdCommodity018> JdCommodity018s { get; set; }
        public virtual DbSet<JdCommodity019> JdCommodity019s { get; set; }
        public virtual DbSet<JdCommodity020> JdCommodity020s { get; set; }
        public virtual DbSet<JdCommodity021> JdCommodity021s { get; set; }
        public virtual DbSet<JdCommodity022> JdCommodity022s { get; set; }
        public virtual DbSet<JdCommodity023> JdCommodity023s { get; set; }
        public virtual DbSet<JdCommodity024> JdCommodity024s { get; set; }
        public virtual DbSet<JdCommodity025> JdCommodity025s { get; set; }
        public virtual DbSet<JdCommodity026> JdCommodity026s { get; set; }
        public virtual DbSet<JdCommodity027> JdCommodity027s { get; set; }
        public virtual DbSet<JdCommodity028> JdCommodity028s { get; set; }
        public virtual DbSet<JdCommodity029> JdCommodity029s { get; set; }
        public virtual DbSet<JdCommodity030> JdCommodity030s { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<SysLog> SysLogs { get; set; }
        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<SysRole> SysRoles { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMappings { get; set; }
        public virtual DbSet<SysUser> SysUsers { get; set; }
        public virtual DbSet<SysUserMenuMapping> SysUserMenuMappings { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMappings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wpfclass> Wpfclasses { get; set; }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=WIN-CSTBNBVVGSQ;Initial Catalog=ZhaoxiEduDataBase;User ID=sa;Password=sa123");
                
                //控制台和debug的sql脚本执行的抓取
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole().AddDebug()));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ParentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<JdCommodity001>(entity =>
            {
                entity.ToTable("JD_Commodity_001");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity002>(entity =>
            {
                entity.ToTable("JD_Commodity_002");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity003>(entity =>
            {
                entity.ToTable("JD_Commodity_003");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity004>(entity =>
            {
                entity.ToTable("JD_Commodity_004");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity005>(entity =>
            {
                entity.ToTable("JD_Commodity_005");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity006>(entity =>
            {
                entity.ToTable("JD_Commodity_006");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity007>(entity =>
            {
                entity.ToTable("JD_Commodity_007");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity008>(entity =>
            {
                entity.ToTable("JD_Commodity_008");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity009>(entity =>
            {
                entity.ToTable("JD_Commodity_009");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity010>(entity =>
            {
                entity.ToTable("JD_Commodity_010");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity011>(entity =>
            {
                entity.ToTable("JD_Commodity_011");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity012>(entity =>
            {
                entity.ToTable("JD_Commodity_012");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity013>(entity =>
            {
                entity.ToTable("JD_Commodity_013");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity014>(entity =>
            {
                entity.ToTable("JD_Commodity_014");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity015>(entity =>
            {
                entity.ToTable("JD_Commodity_015");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity016>(entity =>
            {
                entity.ToTable("JD_Commodity_016");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity017>(entity =>
            {
                entity.ToTable("JD_Commodity_017");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity018>(entity =>
            {
                entity.ToTable("JD_Commodity_018");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity019>(entity =>
            {
                entity.ToTable("JD_Commodity_019");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity020>(entity =>
            {
                entity.ToTable("JD_Commodity_020");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity021>(entity =>
            {
                entity.ToTable("JD_Commodity_021");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity022>(entity =>
            {
                entity.ToTable("JD_Commodity_022");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity023>(entity =>
            {
                entity.ToTable("JD_Commodity_023");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity024>(entity =>
            {
                entity.ToTable("JD_Commodity_024");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity025>(entity =>
            {
                entity.ToTable("JD_Commodity_025");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity026>(entity =>
            {
                entity.ToTable("JD_Commodity_026");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity027>(entity =>
            {
                entity.ToTable("JD_Commodity_027");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity028>(entity =>
            {
                entity.ToTable("JD_Commodity_028");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity029>(entity =>
            {
                entity.ToTable("JD_Commodity_029");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity030>(entity =>
            {
                entity.ToTable("JD_Commodity_030");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasComment("记录WPF班的VIP学员");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_REFERENCE_WPFCLASS");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.ToTable("SysLog");

                entity.HasComment("系统日志表");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CreatorId).HasComment("操作用户");

                entity.Property(e => e.Detail)
                    .HasMaxLength(4000)
                    .HasComment("详细信息");

                entity.Property(e => e.Introduction)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasComment("简介");

                entity.Property(e => e.LastModifierId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.LogType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("操作类型：0信息操作，1 登陆退出\r\n   2 增\r\n   3 删\r\n   4 改\r\n   5 启用禁用\r\n   6 申请/审核通过/拒绝\r\n   7 导入导出\r\n   8 上传下载\r\n   100 其他");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasComment("操作者名称，没有就写系统生成");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("SysMenu");

                entity.HasComment("管理后台菜单表");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CreatorId).HasComment("添加用户");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("说明");

                entity.Property(e => e.LastModifierId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(20)
                    .HasComment("菜单图标");

                entity.Property(e => e.MenuLevel)
                    .HasDefaultValueSql("((1))")
                    .HasComment("菜单等级");

                entity.Property(e => e.MenuType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("类型：1 菜单 2 按钮");

                entity.Property(e => e.ParentId).HasComment("上级菜单：根目录id为0");

                entity.Property(e => e.Sort).HasComment("排序值");

                entity.Property(e => e.SourcePath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment("菜单路径：parentpath/guid\r\n   一级菜单为 root/guid");

                entity.Property(e => e.Status).HasComment("状态：0  正常  1 冻结  2 删除");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("菜单名称");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("链接地址");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("SysRole");

                entity.HasComment("管理后台用户角色表");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasComment("状态：0  正常  1 冻结  2 删除");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<SysRoleMenuMapping>(entity =>
            {
                entity.ToTable("SysRoleMenuMapping");

                entity.HasComment("角色和菜单映射表，一个角色对应多菜单   一个菜单多个角色");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.SysMenuId).HasComment("菜单Id");

                entity.Property(e => e.SysRoleId).HasComment("角色Id");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("SysUser");

                entity.HasComment("后台管理员表");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasComment("联系地址");

                entity.Property(e => e.CreateId).HasComment("添加用户");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("联系邮箱");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasComment("最后登陆时间");

                entity.Property(e => e.LastModifyId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("手机号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("用户名");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasComment("密码");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("联系电话");

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasComment("联系QQ");

                entity.Property(e => e.Sex).HasComment("性别  0男 1女");

                entity.Property(e => e.Status).HasComment("用户状态");

                entity.Property(e => e.WeChat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("微信号");
            });

            modelBuilder.Entity<SysUserMenuMapping>(entity =>
            {
                entity.ToTable("SysUserMenuMapping");

                entity.HasComment("用户和菜单映射表,额外补充用户权限\r\n   一个用户对应多菜单   一个菜单多个角色");
            });

            modelBuilder.Entity<SysUserRoleMapping>(entity =>
            {
                entity.ToTable("SysUserRoleMapping");

                entity.HasComment("用户和角色映射表，一个用户可能多个角色，一个角色多个用户");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.SysRoleId).HasComment("角色Id");

                entity.Property(e => e.SysUserId).HasComment("用户Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasComment("用户状态  0正常 1冻结 2删除");

                entity.Property(e => e.UserType).HasComment("用户类型  1 普通用户 2管理员 4超级管理员");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Company");
            });

            modelBuilder.Entity<Wpfclass>(entity =>
            {
                entity.ToTable("WPFClass");

                entity.HasComment("WPFClass");

                entity.HasIndex(e => new { e.ClassName, e.Teacher }, "NonClusteredIndex-20210104-213253");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
