using Linjie.NET5.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linjie.NET5.BLL
{
    public class LinjieNET5BLLServices : LinjieNET5BLLServicesBase
    {
        private LinjieNET5DALDbContext _linjieNET5DALDbContext = null;

        public LinjieNET5BLLServices()
        {

        }

        public LinjieNET5BLLServices(LinjieNET5DALDbContext linjieNET5DALDbContext)
        {
            //构造函数依赖注入
            _linjieNET5DALDbContext = linjieNET5DALDbContext;
        }

        public bool Add<T>(T t) where T : class
        {
            _linjieNET5DALDbContext = _linjieNET5DALDbContext ?? new LinjieNET5DALDbContext();
            _linjieNET5DALDbContext.Set<T>().Add(t);
            return _linjieNET5DALDbContext.SaveChanges() > 0;
        }

        protected override void Disposing(bool isDisposing)
        {
            if (_linjieNET5DALDbContext!=null)
            {
                _linjieNET5DALDbContext.Dispose();
            }
            //base.Disposing(isDisposing);
        }
    }
}
