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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace EFCOREDB
{
    public class Program
    {
        public static int y = 5;
        public static int x = y;
        //static int y = 5;

        static void Main(string[] args)
        {
            #region 自定义容器IOC(控制反转)，使用DI(依赖注入)

            #endregion

            #region 全部
            #region TestExpression
            //TestDynamicExpressionToSql();
            //TestDynamicExpressionVisitor();
            //TestDynamicExpression();
            //TestExpression();
            #endregion

            #region TestHashSet
            //TestHashSet();
            #endregion

            #region static
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(Program.x);
            //Console.WriteLine(Program.y);
            ////Console.WriteLine(Program.x);
            //Program.x = 99;
            //Program.y = 66;
            //Console.WriteLine(Program.x); 

            //TestStatic();
            #endregion

            #region QuartZ定时任务
            //TestQuartZ();
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
            #endregion

            Console.Read();
        }

        #region 自定义容器IOC(控制反转)，使用DI(依赖注入)

        #region 开始处理思路--出现情况1、创建A对象的实例时候遇到属性赋值》A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //创建对象实例
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        var subPropertyType = Activator.CreateInstance(subtype);
        //                        property.SetValue(typeInstant, subPropertyType);

        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    }
        //                }
        //            }
        //        }
        //    }            
        //}
        #endregion

        #region 问题1
        //使用递归方法 解决出现情况1、创建A对象的实例时候遇到属性赋值》A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A，又出现新问题，创建对象以及属性赋值的时候foreach嵌套2次循环会有性能问题

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //创建对象实例
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                        property.SetValue(typeInstant, CreateObject(subtype, types));                               
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(Type type, Type[] types)
        //    {
        //        //创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            foreach (var subtype in types)
        //            {
        //                if (property.PropertyType.Name.Equals(subtype.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(subtype, types));
        //                }
        //            }
        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }
        //}
        #endregion

        #region 解决问题1，出现问题2
        //使用哈希字典 把foreach嵌套2次循环改成分开的2次foreach循环 解决出现问题：创建对象以及属性赋值的时候2次foreach循环会有性能问题，又出现新问题，如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            typesDict.Add(type.Name, type);
        //        }

        //        //第一次循环 创建对象实例
        //        foreach (var type in types)
        //        {
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                        property.SetValue(typeInstant, CreateObject(subtype, types));
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(Type type, Type[] types)
        //    {
        //        //创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            foreach (var subtype in types)
        //            {
        //                if (property.PropertyType.Name.Equals(subtype.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(subtype, types));
        //                }
        //            }
        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }
        //}
        #endregion

        #region 解决问题2，出新问题3
        //构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 
        //解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        //出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            typesDict.Add(type.Name, type);
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(string typeName)
        //    {
        //        //从哈希字典存储程序集中的所有的类对象查询对应类名的类
        //        Type type = typesDict[typeName];

        //        //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
        //        if (iocContainerDict.ContainsKey(typeName))
        //        {
        //            return iocContainerDict[typeName];
        //        }

        //        //第一次循环 创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            if (typesDict.ContainsKey(property.PropertyType.Name))
        //            {
        //                //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //            }

        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }

        //    /// <summary>
        //    /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
        //    /// </summary>
        //    /// <param name="typeName">需要创建的类名称</param>
        //    /// <returns>创建对应类的实例化对象</returns>
        //    public object GetCreateObject(string typeName)
        //    {
        //        if (typeName is null)
        //        {
        //            return null;
        //        }
        //        return CreateObject(typeName);
        //    }
        //}
        #endregion

        #region 解决问题3 出现问题4
        ////出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的
        ////使用attribute 特性标记需要的类和属性，那么就需要自定义标记需要的类的特性类和标记属性的特性类，
        ////自定义标记需要的类的特性类 ==》和标记属性的特性类
        ////构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        ////出现新问题 ：创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //获取带有[CustomPropertyAttribute]特性标记的类，只有带有自定义特性类的类型才可以通过容器来创建
        //            var customAttr = type.GetCustomAttribute(typeof(CustomTypeAttribute));
        //            if (customAttr is not null)
        //            {
        //                typesDict.Add(type.Name, type);
        //            }
        //            //typesDict.Add(type.Name, type);
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(string typeName)
        //    {
        //        //从哈希字典存储程序集中的所有的类对象查询对应类名的类
        //        Type type = typesDict[typeName];

        //        //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
        //        if (iocContainerDict.ContainsKey(typeName))
        //        {
        //            return iocContainerDict[typeName];
        //        }

        //        //第一次循环 创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //获取带有[CustomPropertyAttribute]特性标记的属性，只有带有自定义特性类的属性才可以通过容器来创建
        //            var customAttr = property.GetCustomAttribute(typeof(CustomPropertyAttribute));
        //            if (customAttr is not null)
        //            {
        //                if (typesDict.ContainsKey(property.PropertyType.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //                }
        //            }
        //            ////情况1 A对象中有属性B
        //            //if (typesDict.ContainsKey(property.PropertyType.Name))
        //            //{
        //            //    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //            //    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //            //}

        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }

        //    /// <summary>
        //    /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
        //    /// </summary>
        //    /// <param name="typeName">需要创建的类名称</param>
        //    /// <returns>创建对应类的实例化对象</returns>
        //    public object GetCreateObject(string typeName)
        //    {
        //        if (typeName is null)
        //        {
        //            return null;
        //        }
        //        return CreateObject(typeName);
        //    }
        //}
        #endregion

        #region 解决问题4 创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁
        //出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的
        //使用attribute 特性标记需要的类和属性，那么就需要自定义标记需要的类的特性类和标记属性的特性类，
        //自定义标记需要的类的特性类 ==》和标记属性的特性类
        //构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        //出现新问题 ：创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁

        /// <summary>
        /// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        /// </summary>
        public class ContainerFactory
        {
            /// <summary>
            /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

            /// <summary>
            /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

            /// <summary>
            /// 临时容器 解决死锁问题，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, object> iocTempContainerDict = new Dictionary<string, object>();

            public ContainerFactory()
            {
                //加载指定程序集
                Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
                //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
                //第一次循环
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    //获取带有[CustomPropertyAttribute]特性标记的类，只有带有自定义特性类的类型才可以通过容器来创建
                    var customAttr = type.GetCustomAttribute(typeof(CustomTypeAttribute));
                    if (customAttr is not null)
                    {
                        typesDict.Add(type.Name, type);
                    }
                    //typesDict.Add(type.Name, type);
                }
            }

            /// <summary>
            /// 创建对象的实例，包括对象中的所有属性的实例化等
            /// </summary>
            /// <param name="typeName">创建对象的名称</param>
            /// <returns>创建对象的实例</returns>
            public object CreateObject(string typeName)
            {
                //iocTempContainerDict 先取值 解决死锁问题

                //从哈希字典存储程序集中的所有的类对象查询对应类名的类
                Type type = typesDict[typeName];

                //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
                if (iocContainerDict.ContainsKey(typeName))
                {
                    return iocContainerDict[typeName];
                }

                //第一次循环 创建对象实例
                var typeInstant = Activator.CreateInstance(type);

                //iocTempContainerDict 存值 解决死锁问题

                //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    //获取带有[CustomPropertyAttribute]特性标记的属性，只有带有自定义特性类的属性才可以通过容器来创建
                    var customAttr = property.GetCustomAttribute(typeof(CustomPropertyAttribute));
                    if (customAttr is not null)
                    {
                        if (typesDict.ContainsKey(property.PropertyType.Name))
                        {
                            //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
                            property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
                        }
                    }
                    ////情况1 A对象中有属性B
                    //if (typesDict.ContainsKey(property.PropertyType.Name))
                    //{
                    //    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
                    //    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
                    //}

                }
                //添加待哈希字典中，供以后DI使用
                iocContainerDict.Add(type.Name, typeInstant);
                return typeInstant;
            }

            /// <summary>
            /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
            /// </summary>
            /// <param name="typeName">需要创建的类名称</param>
            /// <returns>创建对应类的实例化对象</returns>
            public object GetCreateObject(string typeName)
            {
                if (typeName is null)
                {
                    return null;
                }
                return CreateObject(typeName);
            }
        }
        #endregion
        #endregion

        #region Expression表达式树

        #region 表达式树的访问过程，并转化成sql语句
        /// <summary>
        /// 访问 表达式树 Expression<Func<MyClass, bool>> expressionFunc = x => x.Age > 5 &&  x.Id == 8;
        /// 并转化成sql语句 select * from MyClass where age > 5 and id = 8
        /// </summary>
        public class OperatorExpressionToSql : ExpressionVisitor
        {
            /// <summary>
            /// 存放Expression表达式树的内容
            /// </summary>
            public Stack<string> StackSet { get; set; }


            public OperatorExpressionToSql()
            {
                StackSet = new Stack<string>();
                StackSet.Push("(");
            }
            /// <summary>
            /// 修改表达式树的形式
            /// </summary>
            /// <param name="expression"></param>
            /// <returns></returns>
            public Expression Modify(Expression expression)
            {
                //base.Visit(expression);
                //if (expression is BinaryExpression binary)
                //{
                //    if (binary.NodeType == ExpressionType.Add)
                //    {
                //        var left = base.Visit(binary.Left); ;
                //        var right = base.Visit(binary.Right);
                //        var result = Expression.Subtract(left, right);
                //        return result;
                //    }
                //}
                return base.Visit(expression);
            }

            /// <summary>
            /// 表达式树的二元操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (node.NodeType == ExpressionType.AndAlso)
                {
                    base.Visit(node.Left);
                    StackSet.Push("and");
                    base.Visit(node.Right);
                    //var result = Expression.Subtract(left, right);
                    //return result;
                    StackSet.Push(")");
                }
                else if (node.NodeType == ExpressionType.GreaterThan)
                {
                    if (node.Left is MemberExpression member)
                    {
                        StackSet.Push(member.Member.Name);
                    }
                    StackSet.Push(">");
                    if (node.Right is ConstantExpression constant)
                    {
                        StackSet.Push(constant.Value.ToString());
                    }
                }
                else if (node.NodeType == ExpressionType.Equal)
                {
                    if (node.Left is MemberExpression member)
                    {
                        StackSet.Push(member.Member.Name);
                    }
                    StackSet.Push("=");
                    if (node.Right is ConstantExpression constant)
                    {
                        StackSet.Push(constant.Value.ToString());
                    }
                }

                //StackSet.Push(node.Value.ToString());
                return node;
                //return base.VisitBinary(node);
            }

            /// <summary>
            /// 表达式树的常量操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitConstant(ConstantExpression node)
            {
                StackSet.Push(node.Value.ToString());
                return base.VisitConstant(node);
            }
        }

        /// <summary>
        /// 测试表达式树的访问过程，并转化成sql语句
        /// </summary>
        public static void TestDynamicExpressionToSql()
        {
            //访问 表达式树 
            Expression<Func<MyClass, bool>> expressionFunc = x => x.Age > 5 && x.Name == "8";
            /// 并转化成sql语句 select * from MyClass where age > 5 and id = 8
            OperatorExpressionToSql visitor = new OperatorExpressionToSql();
            var expression = visitor.Modify(expressionFunc.Body);
            var d = string.Join(' ', visitor.StackSet.Reverse().ToArray());
            //while (visitor.StackSet.Count > 0)
            //{
            //    Console.WriteLine($"结果：{visitor.StackSet.Pop()}");
            //}
            Console.WriteLine($"结果：{d}");
        }
        #endregion

        #region 访问 表达式树
        /// <summary>
        /// 访问 表达式树 Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
        /// (m, n) => m * n + 2;改成(m, n) => m * n - 2;
        /// </summary>
        public class OperatorExpressionVisitor : ExpressionVisitor
        {
            /// <summary>
            /// 存放Expression表达式树的内容
            /// </summary>
            public Stack<string> StackSet { get; set; }


            /// <summary>
            /// 修改表达式树的形式
            /// </summary>
            /// <param name="expression"></param>
            /// <returns></returns>
            public Expression Modify(Expression expression)
            {
                //base.Visit(expression);
                if (expression is BinaryExpression binary)
                {
                    if (binary.NodeType == ExpressionType.Add)
                    {
                        var left = base.Visit(binary.Left); ;
                        var right = base.Visit(binary.Right);
                        var result = Expression.Subtract(left, right);
                        return result;
                    }
                }
                return expression;
            }

            /// <summary>
            /// 表达式树的二元操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitBinary(BinaryExpression node)
            {
                return base.VisitBinary(node);
            }

            /// <summary>
            /// 表达式树的常量操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitConstant(ConstantExpression node)
            {
                return base.VisitConstant(node);
            }
        }

        /// <summary>
        /// 测试表达式树的访问过程
        /// </summary>
        public static void TestDynamicExpressionVisitor()
        {
            Expression<Func<int, int, int>> predicate = (m, n) => m * n + 2;
            //修改之前
            var func1 = predicate.Compile();
            var result1 = func1.Invoke(2, 3);
            Console.WriteLine($"参数2，3");
            Console.WriteLine($"修改---前");
            Console.WriteLine($"body：{predicate.Body}");
            Console.WriteLine($"结果：{result1}");
            OperatorExpressionVisitor visitor = new OperatorExpressionVisitor();
            var expression = visitor.Modify(predicate.Body);
            Expression<Func<int, int, int>> lam = Expression.Lambda<Func<int, int, int>>(expression, predicate.Parameters);
            var func = lam.Compile();
            var result = func.Invoke(2, 3);
            Console.WriteLine($"修改---后");
            Console.WriteLine($"body：{lam.Body}");
            Console.WriteLine($"结果：{result}");
        }
        #endregion

        /// <summary>
        /// 测试动态表达式树一般拼接Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
        /// </summary>
        public static void TestDynamicExpression()
        {
            //IEnuable与IQueryable
            //var list = new List<int>().AsQueryable();
            //list = list.Where(c => c > 1);//参数：Expression<Func<TSource, bool>> predicate，如：Expression<Func<int, bool>> predicate = c => c > 1;
            Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
            //注意：Expression不能使用大括号，来写lambda表达式，如下写法，会报错
            //Expression<Func<int, int, int>> predicate2 = delegate (m, n) { return m* n +2};


            //var list1 = new List<int>();
            //var list2 = list1.Where(c => c > 1);//参数：Func<TSource, bool> predicate，如：Func<int, bool> predicate1 = c => c > 1;
            Func<int, bool> predicate6 = c => c > 1;
            Func<int, bool> predicate7 = delegate (int c)//delegate可以使用大括号，来写lambda表达式
            {
                return c > 1;
            };

            if (predicate7.Invoke(3))
            {
                Console.WriteLine("调用 Func<int, bool> predicate7 predicate7.Invoke(3) 成功。。。");
            }

            //构造=====》Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
            //(m, n) => m * n + 2;
            //1、左边的参数 (m, n)
            var paramM = Expression.Parameter(typeof(int));
            var paramN = Expression.Parameter(typeof(int));
            //2、m * n + 2;
            //2.1 右边的成员字段 m, n
            //var fieldM = Expression.Field(typeof(int),"m");
            //var fieldN = Expression.Variable(typeof(int), "n");
            //2.2 右边的成员字段 m * n
            var fieldMN = Expression.Multiply(paramM, paramN);
            //2.3 右边的成员常量字段 2
            var fieldConstant = Expression.Constant(2, typeof(int));
            //2.4 右边的成员m * n + 2;
            var memberField = Expression.Add(fieldMN, fieldConstant);
            //2.5 右边的成员常量字段 2
            Expression<Func<int, int, int>> lam = Expression.Lambda<Func<int, int, int>>(memberField, new ParameterExpression[] { paramM, paramN });
            var func = lam.Compile();

            var result = func.Invoke(2, 3);
            Console.WriteLine($"构造=====》Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2 输出结果：{result}");

            #region #region 区分IEnuable与IQueryable 测试lambda expression 动态拼接方式2

            //List<int> grades1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Expression<Func<int, bool>> expression = t => true;
            //expression = expression.And1(t => t >2);
            //expression = expression.And1(t => t <8);
            //var ds = grades1.AsQueryable().Where(expression).ToList();
            //foreach (var item in ds)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //}
            #endregion

            //Console.WriteLine($"###########");
            #region 区分IEnuable与IQueryable 测试lambda expression 动态拼接方式1
            //var list0 = new List<MyClass>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list0.Add(new MyClass { Age = i, Name = i.ToString() });
            //}

            ////IEnuable
            //var result = list0.Where(a => a.Age > 5).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"IEnuable Age:{item.Age},Name:{item.Name}");
            //}
            //Console.WriteLine($"###########");

            ////IQueryable
            //Expression<Func<MyClass, bool>> exp = a => a.Age > 5;
            //Expression<Func<MyClass, bool>> exp2 = a => a.Name == "8";
            //exp = exp.And(exp2);
            //result = list0.AsQueryable<MyClass>().Where(exp).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"IQueryable:Age:{item.Age},Name:{item.Name}");
            //} 
            #endregion

            //Console.WriteLine($"###########");
            #region 测试lambda expression 的查询条件拼接
            //List<int> grades = new List<int> { 78, 92, 100, 37, 81 };
            //// Convert the List to an IQueryable<int>.
            //IQueryable<int> iqueryable = grades.AsQueryable();
            //Expression<Func<int, bool>> exp3 = a => a > 81;
            //Expression<Func<int, bool>> exp4 = a => a < 101;
            //exp3 = exp3.And(exp4);
            //var result3 = iqueryable.Where(exp3).ToList();
            //foreach (var item in result3)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //}

            //Console.WriteLine($"###########");
            //List<int> grades1 = new List<int> { 78, 92, 100, 37, 81 };
            //Expression<Func<int, bool>> expression = t => true;
            //expression = expression.And(t => t == 92);
            //expression = expression.And(t => t > 78);
            //var ds = grades1.AsQueryable().Where(expression).ToList();
            //foreach (var item in ds)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //} 
            #endregion

            //expression_t => false;
            //expression_t = expression_t.Or(x => x.AAA == 1);
            //expression_t = expression_t.Or(x => x.BBB == 2);
            //expression = expression.And(expression_t);

        }

        /// <summary>
        /// 测试动态表达式树一般拼接Expression<Func<MyClass, int>> expressionFunc = x => x.Age + 1;
        /// </summary>
        public static void TestExpression()
        {
            #region Expression simple
            //Expression<Func<int, int>> expressionFunc = x => x + 1;
            //var func = expressionFunc.Compile();
            //var result = func(22);
            //Console.WriteLine($"Expression<Func<int, int>>执行结果：{result}");
            #endregion

            #region Expression complex
            //Expression<Func<MyClass, int>> expressionFunc = x => x.Age + 1;
            //x => x.Age + 1 lambda表达式的具体构造过程，如下，
            //lambda表达式 等号 左边的参数parameter
            ParameterExpression paramLeft = Expression.Parameter(typeof(MyClass));

            //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 x.Age 
            MemberExpression memberRight = Expression.PropertyOrField(paramLeft, "Age"); //MyClass的Age属性，可以再构造lambda表达式的时候传入，这样就可以根据需要来构造表达式了
            //MemberExpression memberRight2 = Expression.Field(paramLeft, "Age"); 
            //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 1 常量 
            ConstantExpression constantRight = Expression.Constant(1, typeof(int));

            //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 + 加号
            BinaryExpression binaryRight = Expression.Add(memberRight, constantRight);

            //lambda表达式 等号 两边的参数parameter  x => x.Age + 1;中的 => goto符号 x => x + 1;
            Expression<Func<MyClass, int>> expressionFunc = Expression.Lambda<Func<MyClass, int>>(binaryRight, paramLeft);

            //Expression<Func<int, int>> expressionFunc = x => x + 1;
            var func = expressionFunc.Compile();
            MyClass myClass = new() { Age = 11 };
            var result = func(myClass);
            //result = func.Invoke(myClass);
            Console.WriteLine($"自定义构造lambda表达式树，产生Expression<Func<MyClass, int>>执行结果：{result}");
            #endregion
        }

        #endregion

        #region HashSet

        public static void TestHashSet()
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("123");
            hs.Add("456");
            hs.Add("789");
            //if (hs.Contains("123"))
            //{
            //    Console.WriteLine($"HashSet的长度：{hs.Count}");
            //    if (hs.Remove("123"))
            //    {
            //        Console.WriteLine($"HashSet删除元素之后的长度：{hs.Count}");
            //    }
            //    Console.WriteLine($"HashSet的长度：{hs.Count}");
            //}
            hs.Add("1");
            hs.Add("2");
            hs.Add("3");
            //foreach (var item in hs)
            //{
            //    Console.WriteLine($"{item}");
            //}

            HashSet<string> hs1 = new HashSet<string>(Enumerable.Range(1, 10).Select(x => x.ToString()));
            var result = hs.Intersect(hs1);
            Console.WriteLine($"----------------------");
            foreach (var item in hs)
            {
                Console.WriteLine($"{item}");
            }
            hs.IntersectWith(hs1);
            Console.WriteLine($"####################");
            foreach (var item in hs)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"----------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }
        }

        #endregion

        #region static
        public static void TestStatic()
        {
            List<MyClass> myClasses = new();
            for (int i = 0; i < 10; i++)
            {
                //myClasses.Add(new MyClass { ClassName = "一班", Name = i.ToString(), Age = i });

                var c = new MyClass { Name = i.ToString(), Age = i };
                MyClass.ClassName = i.ToString();
                myClasses.Add(c);
            }
            foreach (var item in myClasses)
            {
                //Console.WriteLine($"输出信息：班级：{item.ClassName}，姓名：{item.Name}，年龄：{item.Age}");
                Console.WriteLine($"输出信息：班级：{MyClass.ClassName}，姓名：{item.Name}，年龄：{item.Age}");
            }
        }
        #endregion

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

    /// <summary>
    /// 测试类
    /// </summary>
    public class MyClass
    {
        //public MyClass()
        //{
        //    ClassName = "一般";
        //}
        public int Age { get; set; }
        public string Name { get; set; }
        public static string ClassName { get; set; } = "一般";

    }

    #region lambda expression 拼接方式1
    /// <summary>
    /// Expression表达式树
    /// </summary>
    public class LambdaParameteRebinder : ExpressionVisitor
    {
        /// <summary>
        /// 存放表达式树的参数的字典
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map"></param>
        public LambdaParameteRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 重载参数访问的方法，访问表达式树参数，如果字典中包含，则取出
        /// </summary>
        /// <param name="node">表达式树参数</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (map.TryGetValue(node, out ParameterExpression expression))
            {
                node = expression;
            }
            return base.VisitParameter(node);
        }

        public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new LambdaParameteRebinder(map).Visit(exp);
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExtension
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="merge"></param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var parameterMap = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = LambdaParameteRebinder.ReplaceParameter(parameterMap, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() => f => false;

        /// <summary>
        /// Expression表达式树lambda参数拼接-true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() => f => true;

        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);
    }
    #endregion

    #region lambda expression 拼接方式2
    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法扩展类
    /// </summary>
    public class LambdaExpressionParameter : ExpressionVisitor
    {
        /// <summary>
        /// 表达式数的lambda参数
        /// </summary>
        public ParameterExpression parameterExpression { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameterExpression"></param>
        public LambdaExpressionParameter(ParameterExpression parameterExpression)
        {
            this.parameterExpression = parameterExpression;
        }

        /// <summary>
        /// 替代方法
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Expression Replace(Expression expression)
        {
            return base.Visit(expression);
        }

        /// <summary>
        /// 重载参数访问的方法，处理参数表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.parameterExpression;
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExpressionExtend
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not1<T>(this Expression<Func<T, bool>> expression)
        {
            var param = expression.Parameters[0];//指定参数和参数名称
            //var param = Expression.Parameter(typeof(T), "w");
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
    #endregion

    #region 源码
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> map;

    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    //    {
    //        return new ParameterRebinder(map).Visit(exp);
    //    }

    //    protected override Expression VisitParameter(ParameterExpression p)
    //    {
    //        ParameterExpression replacement;
    //        if (map.TryGetValue(p, out replacement))
    //        {
    //            p = replacement;
    //        }
    //        return base.VisitParameter(p);
    //    }
    //}

    //public static class PredicateBuilder
    //{

    //    public static Expression<Func<T, bool>> True<T>() { return f => true; }
    //    public static Expression<Func<T, bool>> False<T>() { return f => false; }
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        // build parameter map (from parameters of second to parameters of first)  
    //        var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

    //        // replace parameters in the second lambda expression with parameters from the first  
    //        var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

    //        // apply composition of lambda expression bodies to parameters from the first expression   
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    //    {
    //        return first.Compose(second, Expression.And);
    //    }

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    //    {
    //        return first.Compose(second, Expression.Or);
    //    }

    //} 
    #endregion

    #region MyRegion
    ///// <summary>
    ///// Expression表达式树
    ///// </summary>
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    /// <summary>
    //    /// 存放表达式树的参数的字典
    //    /// </summary>
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> map;

    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="map"></param>
    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) => new ParameterRebinder(map).Visit(exp);
    //    //{
    //    //    return new ParameterRebinder(map).Visit(exp);
    //    //}

    //    /// <summary>
    //    /// 访问表达式树参数，如果字典中包含，则取出
    //    /// </summary>
    //    /// <param name="node">表达式树参数</param>
    //    /// <returns></returns>
    //    protected override Expression VisitParameter(ParameterExpression node)
    //    {
    //        if (map.TryGetValue(node, out ParameterExpression replace))
    //        {
    //            node = replace;
    //        }
    //        return base.VisitParameter(node);
    //    }

    //}

    ///// <summary>
    ///// 表达式数的lambda参数的拼接扩展方法
    ///// </summary>
    //public static class ExpressionExtension
    //{

    //    //public static Expression<Func<T, bool>> True<T>() { return f => true; }
    //    //public static Expression<Func<T, bool>> False<T>() { return f => false; }
    //    //public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    //{
    //    //    // build parameter map (from parameters of second to parameters of first)  
    //    //    var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

    //    //    // replace parameters in the second lambda expression with parameters from the first  
    //    //    var secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

    //    //    // apply composition of lambda expression bodies to parameters from the first expression   
    //    //    return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    //}
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        var dict = first.Parameters.Select((f, index) => new { f, s = second.Parameters[index] }).ToDictionary(a => a.s, a => a.f);
    //        var secondBody = ParameterRebinder.ReplaceParameter(dict, second.Body);
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--or
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);
    //    //{
    //    //    return first.Compose(second, Expression.Or);
    //    //}

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--and
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>
    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);
    //    //{
    //    //    return first.Compose(second, Expression.And);
    //    //}


    //    public static Expression<Func<T, bool>> True<T>() => f => true;
    //    //{
    //    //    return f => true;
    //    //}

    //    public static Expression<Func<T, bool>> False<T>() => f => false;
    //    //{
    //    //    return f => false;
    //    //}
    //}
    #endregion

    //#region MyRegion
    ///// <summary>
    ///// Expression表达式树
    ///// </summary>
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    /// <summary>
    //    /// 存放表达式树的参数的字典
    //    /// </summary>
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> Map;

    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="map"></param>
    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.Map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) /*=> new ParameterRebinder(map).Visit(exp);*/
    //    {
    //        return new ParameterRebinder(map).Visit(exp);
    //    }

    //    /// <summary>
    //    /// 访问表达式树参数，如果字典中包含，则取出
    //    /// </summary>
    //    /// <param name="node">表达式树参数</param>
    //    /// <returns></returns>
    //    protected override Expression VisitParameter(ParameterExpression node)
    //    {
    //        if (Map.TryGetValue(node, out ParameterExpression replace))
    //        {
    //            node = replace;
    //        }
    //        return base.VisitParameter(node);
    //    }

    //}

    ///// <summary>
    ///// 表达式数的lambda参数的拼接扩展方法
    ///// </summary>
    //public static class ExpressionExtension
    //{
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        var dict = first.Parameters.Select((f, index) => new { f, s = second.Parameters[index] }).ToDictionary(a => a.f, a => a.s);
    //        var secondBody = ParameterRebinder.ReplaceParameter(dict, second.Body);
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--or
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) /*=> first.Compose(second, Expression.Or);*/
    //    {
    //        return first.Compose(second, Expression.Or);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--and
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>
    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) /*=> first.Compose(second, Expression.And);*/
    //    {
    //        return first.Compose(second, Expression.And);
    //    }


    //    public static Expression<Func<T, bool>> True<T>() /*=> f => true;*/
    //    {
    //        return f => true;
    //    }

    //    public static Expression<Func<T, bool>> False<T>() /*=> f => false;*/
    //    {
    //        return f => false;
    //    }
    //}
    //#endregion
}

//顶级程序

//System.Console.WriteLine("After initial GetOrAdd");
//System.Console.Read();