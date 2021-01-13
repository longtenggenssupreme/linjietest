using System;
using System.Collections.Generic;
using System.Text;

namespace Linjie.NET5.BLL
{
    public abstract class LinjieNET5BLLServicesBase : IDisposable
    {
        private bool isDisposed = false;

        protected virtual void Disposing(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    //释放托管资源
                }
                //释放非托管资源，如：句柄，文件流，GDI+绘图对象等
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }
    }
}
