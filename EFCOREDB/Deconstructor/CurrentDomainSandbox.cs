using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    public class CurrentDomainSandbox : IDisposable
    {
        ///// <summary>
        /////  程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
        ///// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll
        ///// </summary>
        //private AppDomain _CurrentDomian = AppDomain.CreateDomain("CurrentDomainSandbox", null, new AppDomainSetup
        //{
        //    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
        //    ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
        //});

        /// <summary>
        /// 程序集 System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        /// C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Runtime.dll
        /// </summary>
        private AppDomain _CurrentDomian = AppDomain.CreateDomain("CurrentDomainSandbox");

        ~CurrentDomainSandbox()
        {
            Console.WriteLine("释放。。。CurrentDomainSandbox");
            Dispose(false);
        }

        public T CreateInstance<T>(params object[] args)
        {
            return (T)CreateInstance(typeof(T), args);
        }

        public object CreateInstance(Type type, params object[] args)
        {
            if (_CurrentDomian == null)
            {
                throw new ObjectDisposedException(null);
            }

            return _CurrentDomian.CreateInstanceAndUnwrap(
                assemblyName: type.Assembly.FullName,
                typeName: type.FullName,
                ignoreCase: false,
                bindingAttr: default,
                binder: null,
                args: args,
                culture: null,
                activationAttributes: null
                );
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose && _CurrentDomian != null)
            {
                AppDomain.Unload(_CurrentDomian);
                _CurrentDomian = null;
            }
        }
    }
}
