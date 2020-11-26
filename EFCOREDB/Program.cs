using Hangfire;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCOREDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region QuartZ定时任务
            TestQuartZ();
            #endregion

            #region 线程取消
            //TestThreancancel();
            #endregion

            #region task任务取消
            //TestTaskLinkedCancel();
            //TestTaskSync();
            //TestThreadCancel();
            //TestTaskCancel();
            //TestTaskCancel1(); 
            #endregion

            #region MyRegion
            //GetAsync();
            //var iterator = GetEnumerator();
            //while (iterator.MoveNext())
            //{
            //    Console.WriteLine($"输出{iterator.Current}");
            //} 
            #endregion

            #region 测试
            //TestConcurrentDictionary();
            //TestDBContext(); 
            #endregion

            Console.Read();
        }

        #region Hangfire定时任务
        /// <summary>
        /// Hangfire定时任务
        /// </summary>
        public static void TestHangfire()
        {
            var queueStr = BackgroundJob.Enqueue(() => WriteLog("任务添加到队列之中"));
            string v = BackgroundJob.Schedule(() => WriteLog("延时任务"), TimeSpan.FromSeconds(2));
            string v1 = BackgroundJob.ContinueJobWith(queueStr, () => WriteLog("queueStr任务执行之后的任务。。。。"));
            RecurringJob.AddOrUpdate(() => WriteLog("RecurringJob"), Cron.Minutely);
        }

        public static void WriteLog(string str)
        {
            Console.WriteLine($"queueStr任务执行{str}");
        }

        #endregion

        #region QuartZ定时任务
        /// <summary>
        /// QuartZ定时任务
        /// </summary>
        public static async void TestQuartZ()
        {
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();
            await scheduler.Start();
            var job = JobBuilder.Create<MyJob>().WithIdentity("job1", "group1").Build();
            var triger = TriggerBuilder.Create().WithIdentity("job1", "group1")
                .StartNow()
                .WithSimpleSchedule(sc => sc.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, triger);
        }
        public class MyJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                return Task.Run(() => { Console.WriteLine($"{DateTime.Now}:执行任务"); });
                //return Console.Out.WriteLineAsync($"{DateTime.Now}:执行任务");
            }
        }

        #endregion

        #region 线程取消
        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel()
        {
            using CancellationTokenSource source = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(_ => TestThreancancel1(source.Token));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source.Cancel();

            using CancellationTokenSource source1 = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem((_) => { TestThreancancel2(source1.Token); });
            //source1.CancelAfter(TimeSpan.FromSeconds(3));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source1.Cancel();

            using CancellationTokenSource source2 = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem((_) => { TestThreancancel3(source2.Token); });
            //source2.CancelAfter(TimeSpan.FromSeconds(3));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source2.Cancel();
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel1(CancellationToken token)
        {
            Console.WriteLine($"第一个线程开始执行");
            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"第一个线程已经取消了。。。");
                    return;
                }
                Console.WriteLine($"第一个线程TestThreancancel 输出值：{i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                //Console.WriteLine($"第一个线程TestThreancancel 输出值：{i}");
            }
            Console.WriteLine($"第一个线程成功执行");
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel2(CancellationToken token)
        {
            Console.WriteLine($"第二个线程开始执行");
            bool isCanceled = false;
            token.Register(() => { isCanceled = true; });
            for (int i = 0; i < 10; i++)
            {
                if (isCanceled)
                {
                    Console.WriteLine($"第二个线程已经取消了。。。");
                    return;
                }
                Console.WriteLine($"第二个线程TestThreancancel 输出值：{i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                //Console.WriteLine($"第二个线程TestThreancancel 输出值：{i}");
            }
            Console.WriteLine($"第二个线程成功执行");
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel3(CancellationToken token)
        {
            Console.WriteLine($"第三个线程开始执行");
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"第三个线程TestThreancancel 输出值：{i}");
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    //Console.WriteLine($"第三个线程TestThreancancel 输出值：{i}");
                }
                Console.WriteLine($"第三个线程成功执行");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"第三个线程已经取消了。。。");
            }
        }
        #endregion

        #region Task and CancellationTokenSource

        /// <summary>
        /// 任务的链式取消
        /// </summary>
        public async static void TestTaskLinkedCancel()
        {
            Console.WriteLine($"链接取消任务开始。。。。");
            await Task.Delay(TimeSpan.FromSeconds(1));
            CancellationTokenSource source1 = new CancellationTokenSource();
            var token1 = source1.Token;
            token1.Register(() => { Console.WriteLine($"任务--1--取消回调"); });
            CancellationTokenSource source2 = new CancellationTokenSource();
            var token2 = source2.Token;
            token2.Register(() => { Console.WriteLine($"任务--2--取消回调"); });
            CancellationTokenSource source3 = CancellationTokenSource.CreateLinkedTokenSource(token1, token2);
            var token3 = source3.Token;
            token3.Register(() => { Console.WriteLine($"任务--3--取消回调"); });
            source1.CancelAfter(TimeSpan.FromSeconds(3));
        }

        /// <summary>
        /// 同步任务和异步任务的对比
        /// </summary>
        public static void TestTaskSync()
        {
            Console.WriteLine($"当前线程:{ Thread.CurrentThread.ManagedThreadId}");
            //创建异步任务
            var taskAsync = Task.Run(() =>
            {
                Console.WriteLine($"异步任务：{Task.CurrentId}，运行的线程:{ Thread.CurrentThread.ManagedThreadId}");
                int sum = 0;
                Parallel.For(1, 10000, (i) => { Interlocked.Add(ref sum, i); });
                return sum;
            });

            //创建同步任务
            var taskSync = new Task<long>(() =>
           {
               Console.WriteLine($"同步任务：{Task.CurrentId}，运行的线程:{ Thread.CurrentThread.ManagedThreadId}");
               int sum2 = 0;
               Parallel.For(1, 10000, (i) => { Interlocked.Add(ref sum2, i); });
               return sum2;
           });

            taskSync.RunSynchronously();
            Console.WriteLine($"同步任务：{taskSync.Id}，运行的线程的结果:{ taskSync.Result}");
            Console.WriteLine($"异步任务：{taskAsync.Id}，运行的线程的结果:{ taskAsync.Result}");
        }

        public static void TestThreadCancel()
        {
            SpinLock spinLock = new SpinLock(false);
            object obj = new object();
            int sun1 = 0;
            int sun2 = 0;
            int sun3 = 0;

            //不加锁
            Parallel.For(1, 10000, i =>
                    {
                        sun1 += i;
                    });

            //不加锁
            Parallel.For(1, 10000, i =>
            {
                bool islock = false;
                try
                {
                    spinLock.Enter(ref islock);
                    sun2 += i;
                }
                finally
                {
                    if (islock)
                    {
                        spinLock.Exit(false);
                    }
                }
            });
            //不加锁
            Parallel.For(1, 10000, i =>
            {
                lock (obj)
                {
                    sun3 += i;
                }

            });

            Console.WriteLine($"sun1={sun1}");
            Console.WriteLine($"sun2={sun2}");
            Console.WriteLine($"sun3={sun3}");
        }

        /// <summary>
        /// 测试取消
        /// </summary>
        public static void TestTaskThreadCancel()
        {
            #region MyRegion
            //var tokenSource = new CancellationTokenSource();//创建取消task实例
            //var testTask = new Task(() =>
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //    }
            //}, tokenSource.Token);
            //Console.WriteLine(testTask.Status);
            //testTask.Start();
            //Console.WriteLine(testTask.Status);
            //tokenSource.Token.Register(() =>
            //{
            //    Console.WriteLine("task is to cancel");
            //});
            //tokenSource.Cancel();
            //Console.WriteLine(testTask.Status);
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    Console.WriteLine(testTask.Status);
            //} 
            #endregion
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                var task = new Task(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }, token);//TaskCreationOptions.LongRunning
                token.Register(() => { Console.WriteLine($"任务取消了。。。。"); });
                Console.WriteLine($"task 状态 :{task.Status}");

                task.Start();
                Console.WriteLine($"task 状态 :{task.Status}");
                tokenSource.Cancel();
                Console.WriteLine($"task 状态 :{task.Status}");
                Console.WriteLine($"task是否取消看下面的 状态 ");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"task 状态 :{task.Status}");
                }
            }
            catch (AggregateException agg)
            {
                foreach (var item in agg.InnerExceptions)
                {
                    if (item is TaskCanceledException ex)
                        Console.WriteLine($"任务取消:{ex.Message}");
                    else
                        Console.WriteLine($"任务取消:{item.GetType().Name}");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        /// <summary>
        /// 测试取消
        /// </summary>
        public static void TestTaskCancel()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            TaskFactory factory = new TaskFactory(token);
            List<Task<int[]>> list = new List<Task<int[]>>();
            Random random = new Random();
            object lockObj = new object();
            for (int i = 0; i <= 10; i++)
            {
                list.Add(factory.StartNew(() =>
                {
                    int[] vs = new int[10];
                    int randomNum;
                    for (int j = 0; j < 10; j++)
                    {
                        lock (lockObj)
                        {
                            randomNum = random.Next(0, 101);
                        }

                        if (randomNum == 0)
                        {
                            tokenSource.Cancel();
                            Console.WriteLine($"当前任务是:{i + 1}");
                            break;
                        }
                        vs[j] = randomNum;
                    }
                    return vs;
                }, token));
            }

            try
            {
                var ts = factory.ContinueWhenAll(list.ToArray(), (taskList) =>
                {
                    long sum = 0;
                    int accumulate = 0;
                    foreach (var item in taskList)
                    {
                        foreach (var subitem in item.Result)
                        {
                            sum = +subitem;
                            accumulate++;
                        }
                    }
                    return sum / (double)accumulate;
                }, token);
                Console.WriteLine($"所有任务累加的结果:{ts.Result}");
            }
            catch (AggregateException agg)
            {
                foreach (var item in agg.InnerExceptions)
                {
                    if (item is TaskCanceledException ex)
                        Console.WriteLine($"任务取消:{ex.Message}");
                    else
                        Console.WriteLine($"任务取消:{item.GetType().Name}");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        public static void TestTaskCancel1()
        {
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}",
                                          ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally
            {
                source.Dispose();
            }
        }
        #endregion

        #region 测试并发字典ConcurrentDictionary
        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async void GetAsync()
        {
            var iterator = GetEnumeratorAsyncFor();
            while (await iterator.MoveNextAsync())
            {
                Console.WriteLine($"输出{iterator.Current}");
            }
            #region MyRegion
            //var iterator = GetEnumeratorAsync();
            //    var result = await iterator.MoveNextAsync();
            //    while (result)
            //    {
            //        Console.WriteLine($"输出{iterator.Current}");
            //        result = await iterator.MoveNextAsync();
            //    }

            //    //while (await iterator.MoveNextAsync())
            //    //{
            //    //    Console.WriteLine($"输出{iterator.Current}");
            //    //} 
            #endregion
            Console.WriteLine("GetAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async IAsyncEnumerator<string> GetEnumeratorAsyncFor()
        {
            for (int i = 0; i < 10; i++)
            {
                //await Task.Delay(1000);
                //yield return i.ToString();

                await Task.Delay(1000).ContinueWith((_) =>
                {
                    Console.WriteLine($"迭代器--异步--{i}");
                });
                yield return i.ToString();
            }
            Console.WriteLine("GetEnumeratorAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async IAsyncEnumerator<string> GetEnumeratorAsync()
        {
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "B";
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "C";
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "D";
            Console.WriteLine("GetEnumeratorAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器
        /// </summary>
        /// <returns></returns>
        static IEnumerator<string> GetEnumerator()
        {
            yield return "A";
            //Console.WriteLine("输出A");
            yield return "B";
            //Console.WriteLine("输出A");
            yield return "C";
            //Console.WriteLine("输出A");
            yield return "D";
            Console.WriteLine("结束。。。。");
        }

        /// <summary>
        /// 测试并发字典ConcurrentDictionary
        /// </summary>
        static void TestConcurrentDictionary()
        {
            #region MyRegion
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();
            Parallel.For(1, 100, i =>
            {
                cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            });
            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);
            // Should return 100, as key 2 is not yet in the dictionary
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);

            // Should return 100, as key 2 is already set to that value
            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
            //Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);
            #endregion
        }
        #endregion

        #region Database数据库操作
        /// <summary>
        /// 测试数据库的分库分表，表映射，切换表
        /// </summary>
        static void TestDBContext()
        {
            #region DBContext
            //DateTime datetime1 = DateTime.Now;
            //using (var context = new DynamicContext { CreateDateTime = datetime1 })
            //{
            //    Console.WriteLine("开始删除数据库");
            //    context.Database.EnsureDeleted();
            //    Console.WriteLine("删除成功");
            //    Console.WriteLine("开始创建数据库");
            //    context.Database.EnsureCreated();
            //    Console.WriteLine("创建成功");
            //    var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();
            //    #region MyRegion
            //    //context.Tests.Add(new Test { Title = "Great News One", Content = $"Hello World! I am the news of {datetime1}", CreateDateTime = datetime1 });
            //    //更新实体的方式
            //    //0、查询实体，修改实体字段，context.SaveChanges();
            //    //1、创建实体，context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //2、创建实体，context.Update(创建的实体); context.SaveChanges();
            //    //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.ChangeTracker.DetectChanges(); context.SaveChanges();
            //    //3、创建实体，context.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //4、context.ChangeTracker.TrackGraph(ss, e => {
            //    //    if ((e.Entry.Entity as Test) != null)
            //    //    {
            //    //        e.Entry.State = EntityState.Unchanged;
            //    //    }
            //    //    else
            //    //    {
            //    //        e.Entry.State = EntityState.Modified;
            //    //    }
            //    //});
            //    //context.SaveChanges(); 
            //    #endregion

            //    var ss = new Test { Title = "11", Content = $"111 {datetime1}", CreateDateTime = datetime1 };
            //    Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
            //    //context.Attach(ss);//告诉EF Core开始跟踪person实体的更改，因为调用DbContext.Attach方法后，EF Core会将person实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改回EntityState.Unchanged，所以这里testDBContext.Attach(ss)一定要放在下面一行testDBContext.Entry(ss).Property(p => p.Content).IsModified = true的前面，否者后面的testDBContext.SaveChanges方法调用后，数据库不会被更新
            //    //context.Entry(ss).Property(p => p.Content).IsModified = true;//告诉EF Core实体ss的Content属性已经更改。将testDBContext.Entry(person).Property(p => p.Name).IsModified设置为true后，也会将ss实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改为EntityState.Modified，这样就保证了下面SaveChanges的时候会将ss实体的Content属性值Update到数据库中。
            //    //context.Entry(ss).Property(p => p.Content).IsModified = true;
            //    //context.Tests.Attach(ss);
            //    context.Attach(ss);
            //    Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
            //    //context.ChangeTracker.DetectChanges();
            //    context.SaveChanges();
            //}

            ////切换表
            //DateTime datetime2 = DateTime.Now.AddDays(-1);
            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();//查询实体映射到数据库中对应的表名称
            //    if (!tablename.Equals("20201118"))
            //    {
            //        //var str = GetMySQLSqls(datetime2);
            //        var str = GetSqlServerSqls(datetime2);

            //        //判断是否存在表，不存在则创建
            //        using var cmd = context.Database.GetDbConnection().CreateCommand();
            //        cmd.CommandText = str[0];
            //        if (cmd.Connection.State != System.Data.ConnectionState.Open)
            //        {
            //            cmd.Connection.Open();
            //        }
            //        var result = cmd.ExecuteScalar();
            //        if (result.ToString() == "0")
            //        {
            //            //创建新表
            //            context.Database.ExecuteSqlRaw(str[1]);
            //        }
            //    }

            //    //context.Database.EnsureCreated();
            //    context.Tests.Add(new Test { Title = "22", Content = $"222 {datetime2}", CreateDateTime = datetime2 });
            //    context.SaveChanges();
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime1 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of today
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of yesterday
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //} 
            #endregion
        }

        #region Database数据库操作
        private static string[] GetMySQLSqls(DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string decide = $"SELECT count(1) FROM information_schema.TABLES WHERE table_name='{tableName}'";
            string sqlRaw = $@"
CREATE TABLE IF NOT EXISTS `{tableName}` (
  `Id` int(20) NOT NULL,
  `Title` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Content` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateDateTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetSqlServerSqls(DateTime time)
        {
            //注意：[Id] int NOT NULL IDENTITY(1,1)中的 IDENTITY(1,1) 表示自增
            string tableName = time.ToString("yyyyMMdd");
            //-- 判断要创建的表名是否存在 select * from dbo.sysobjects where id=object_id(N'[dbo].[{0}]') and xtype='U'
            string decide = $"SELECT COUNT(1) FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[{tableName}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            string sqlRaw = $@"IF NOT EXISTS ( SELECT * FROM dbo.sysobjects WHERE id=object_id(N'[dbo].[{tableName}]') AND xtype='U')
BEGIN
CREATE TABLE [dbo].[{tableName}] (
[Id] int NOT NULL IDENTITY(1,1),
[Title] nvarchar(20) NULL ,
[Content] nvarchar(500) NULL ,
[CreateDateTime] datetime2(7) NOT NULL ,
);
ALTER TABLE [dbo].[{tableName}] ADD PRIMARY KEY ([Id]);
END";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetOracleSqls(string defaultSchema, DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string schema = defaultSchema;
            string id_seq = $"{tableName}_id_seq";
            var pk = $"PK_{tableName}";
            string decide = $"SELECT COUNT(1) FROM all_tables WHERE TABLE_NAME='{tableName}' AND OWNER='{schema}'";
            string sqlRaw =
$@"DECLARE num NUMBER;
BEGIN
	SELECT
		COUNT(1) INTO num 
	FROM
		all_tables 
	WHERE
		TABLE_NAME = '{tableName}' 
		AND OWNER = '{schema}';
	IF
		num = 0 THEN
			EXECUTE IMMEDIATE 'CREATE TABLE ""{schema}"".""{tableName}"" (
            ""Id"" NUMBER(10) NOT NULL,
            ""Title"" NVARCHAR2(20),
            ""Content"" NCLOB,
            ""CreateDateTime"" TIMESTAMP(7) NOT NULL,
            CONSTRAINT ""{pk}"" PRIMARY KEY(""Id""),
            )';

            EXECUTE IMMEDIATE 'CREATE SEQUENCE ""{schema}"".""{id_seq}"" START WITH 1 INCREMENT BY 1';
            END IF;
            END; ";
            return new string[] { decide, sqlRaw };
        }
        #endregion
        #endregion
    }
}

//顶级程序

//System.Console.WriteLine("After initial GetOrAdd");
//System.Console.Read();