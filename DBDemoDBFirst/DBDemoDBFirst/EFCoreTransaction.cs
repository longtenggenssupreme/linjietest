using DBDemoDBFirst.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemoDBFirst
{
    public static class EFCoreTransaction
    {
        public static void Show()
        {
            
            using ZhaoxiDbContext context = new ZhaoxiDbContext();
            using IDbContextTransaction contextTransaction = context.Database.BeginTransaction();
            try
            {
                JdCommodity001 jdCommodity = new JdCommodity001
                {
                    //Id = 123,
                    ProductId = 456,
                    CategoryId = 789,
                    ImageUrl = "imageurl",
                    Price = 123,
                    Title = "11111",
                    Url = "url"
                };
                //CRUD-C增加
                context.JdCommodity001s.Add(jdCommodity);
                Console.WriteLine($"{context.Entry<JdCommodity001>(jdCommodity).State}");

                JdCommodity001 jdCommodity1 = new JdCommodity001
                {
                    //Id = 123,
                    ProductId = 456,
                    CategoryId = 789,
                    ImageUrl = "imageurl",
                    Price = 145678,
                    Title = "11111",
                    Url = "url"
                };
                //CRUD-C增加
                context.JdCommodity001s.Add(jdCommodity1);
                Console.WriteLine($"{context.Entry<JdCommodity001>(jdCommodity1).State}");

                context.SaveChanges();
                contextTransaction.Commit(); //成功的话直接提交
            }
            catch (Exception ex)
            {
                contextTransaction.Rollback();//出错回滚到原始状态
                throw;
            }           
        }
    }
}
