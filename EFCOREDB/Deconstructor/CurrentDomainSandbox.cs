using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    public class CurrentDomainSandbox : IDisposable
    {
        private AppDomain _CurrentDomian =AppDomain.CreateDomain()

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
