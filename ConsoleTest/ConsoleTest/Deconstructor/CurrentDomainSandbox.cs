using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public class CurrentDomainSandbox : IDisposable
    {
        private AppDomain _CurrentDomian = AppDomain.CreateDomain("CurrentDomainSandbox", null, new AppDomainSetup
        {
            ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
        });

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
