using DBDemoDBFirst.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemoDBFirst
{
    public static class EFCoreQuery
    {
        public static void Show()
        {
            #region 其他查询
            using (ZhaoxiDbContext dbContext = new ZhaoxiDbContext())
            {
                {
                    var idlist = new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 };//in查询
                    var list = dbContext.SysUsers.Where(u => idlist.Contains(u.Id));//in查询
                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
                {
                    //没有任何差别，只有写法上的熟悉
                    var list = from u in dbContext.SysUsers
                               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id)
                               select u;
                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
                {
                    var list = dbContext.SysUsers.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 18, 19, 20, 21, 22, 23 }.Contains(u.Id))
                                              .OrderBy(u => u.Id)
                                              .Select(u => new
                                              {
                                                  Name = u.Name,
                                                  Pwd = u.Password
                                              }).Skip(3).Take(5);
                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Pwd);
                    }
                }
                {
                    var list = (from u in dbContext.SysUsers
                                where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id)
                                orderby u.Id
                                select new
                                {
                                    Name = u.Name,
                                    Pwd = u.Password
                                }).Skip(3).Take(5);
                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
                {
                    var list = dbContext.SysUsers.Where(u => u.Name.StartsWith("小")
                                                && u.Name.EndsWith("村长"))
                                                .Where(u => u.Name.EndsWith("长"))
                                                .Where(u => u.Name.Contains("名村"))
                                                .Where(u => u.Name.Length < 5)
                                                .OrderBy(u => u.Id);
                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Name);
                    }
                    var list1 = from u in dbContext.SysUsers
                                where u.Name.StartsWith("小") && u.Name.EndsWith("村长")
                                where u.Name.EndsWith("长")
                                select new { Name = u.Name, pwd = u.Password };
                    foreach (var user in list1)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
                {
                    //dbContext.SysUsers.Join()
                    var list = (from u in dbContext.SysUsers
                                join c in dbContext.SysUserRoleMappings on u.Id equals c.SysUserId //条件不能写等号，要使用equals关键字
                                where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                                select new
                                {
                                    Name = u.Name,
                                    Pwd = u.Password,
                                    RoleId = c.SysRoleId.ToString(),
                                    UserId = u.Id
                                }).OrderBy(u => u.UserId).Skip(3).Take(5);
                    foreach (var user in list)
                    {
                        Console.WriteLine("{0} {1}", user.Name, user.Pwd);
                    }
                }
                {
                    Console.WriteLine("**********************Linq左连接 * ***************************");
                        //Linq左连接：
                   {
                        //Linq中只有左连接
                        {
                            var list = from u in dbContext.SysUsers
                                       join c in dbContext.SysUserRoleMappings on u.Id equals c.SysUserId
                                       into ucList
                                       from uc in ucList.DefaultIfEmpty()
                                       where new int[] { 1, 2, 3, 4, 6, 7, 10}.Contains(u.Id)
                                       select new
                                       {
                                           Account = u.Name,
                                           Pwd = u.Password,
                                           UserId = u.Id
                                       };
                            foreach (var user in list)
                            {
                                Console.WriteLine("{0} {1}", user.Account, user.Pwd);
                            }
                        }
                        {
                            var list = from c in dbContext.SysUserRoleMappings
                                       join u in dbContext.SysUsers on c.SysUserId equals u.Id
                                       into ucList
                                       from uc in ucList.DefaultIfEmpty()
                                       where new int[] { 1, 2, 3, 4, 6, 7, 10}.Contains(c.Id)
                                       select new
                                       {
                                           Account = uc.Name,
                                           Pwd = uc.Password,
                                           Id = uc.Id.ToString()
                                       };
                            foreach (var user in list)
                            {
                                Console.WriteLine("{0} {1}", user.Account, user.Pwd);
                            }
                        }
                    }
                }
            }

            //如果遇到非常复杂的查询----建议直接写Sql语句；
            using (ZhaoxiDbContext dbContext = new ZhaoxiDbContext())
            {
                {
                    try
                    {
                        string selectSql = "select * from JD_Commodity_001 where id<@Id";
                        SqlParameter parameter1 = new SqlParameter("@Id", 500);
                        var query = dbContext.JdCommodity001s.FromSqlRaw<JdCommodity001>(selectSql, parameter1);
                        foreach (var jd in query)
                        {
                            Console.WriteLine(jd.Title);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                {
                    string sql = "Update [JD_Commodity_001] Set Title='小新' WHERE Id=@Id";
                    SqlParameter parameter1 = new SqlParameter("@Id", 500);
                    int flg = dbContext.Database.ExecuteSqlRaw(sql, parameter1);
                }
            }
            #endregion
        }
    }
}
