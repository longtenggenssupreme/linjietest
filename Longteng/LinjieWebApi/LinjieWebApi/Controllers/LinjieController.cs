using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinjieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinjieController : ControllerBase
    {
        private readonly ILinjieServiceBase _linjieServiceBase;

        public LinjieController(ILinjieServiceBase linjieServiceBase)
        {
            _linjieServiceBase = linjieServiceBase;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            _linjieServiceBase.Show();
            return Enumerable.Range(1, 20).ToArray();
        }
    }
}
