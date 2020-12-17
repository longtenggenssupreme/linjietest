using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestRestSharpController : ControllerBase
    {
        private static readonly List<string> Summaries = new List<string>
        {
            "张三", "李四", "王五", "赵六"
        };

        private readonly ILogger<TestRestSharpController> _logger;

        public TestRestSharpController(ILogger<TestRestSharpController> logger)
        {
            _logger = logger;
        }

        // GET: TestRestSharpController
        [HttpGet]
        public List<string> Get()
        {
            _logger.LogInformation("使用的HttpGet");
            return Summaries;
        }

        // GET: TestRestSharpController/5
        [HttpGet("{id}")]
        public string Details(int id)
        {
            _logger.LogInformation("使用的HttpGet,附带id");
            return Summaries[id];
        }

        //// POST: TestRestSharpController/Create
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public string Post/*([FromBody] string str)*//*([FromHeader] string str)*//*([FromQuery] string str)*/([FromForm] string str)
        //{
        //    _logger.LogInformation("使用的HttpPost");
        //    if (str is not null)
        //    {
        //        Summaries.Add(str);
        //    }
        //    int idne = Summaries.BinarySearch(str);
        //    return Summaries[idne < 0 ? 0 : idne] ?? "sss";
        //}

        // POST: TestRestSharpController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("{name?}")]
        public string Post([FromBody] string str)/*([FromHeader] string str)*//*([FromQuery] string str)*//*([FromForm] IFormCollection str)*//*([FromRoute(Name = "name")] string str)*//*([FromServices] ISecurityService securityService, string str)*/
        {
            _logger.LogInformation("使用的HttpPost");
            //securityService.Validate(str);//注入服务
            if (str is not null)
            {
                Summaries.Add("123");
            }
            int idne = Summaries.BinarySearch("123");
            return Summaries[idne < 0 ? 0 : idne] ?? "sss";
        }

        // GET: TestRestSharpController/5
        [HttpPut("{id}")]
        public string Edit(int id, [FromBody] string collection)
        {
            _logger.LogInformation("使用的HttpPut,附带id");
            Summaries[id] = collection;
            return Summaries[Summaries.BinarySearch(collection)];
        }

        // GET: TestRestSharpController/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _logger.LogInformation("使用的HttpDelete,附带id");
            var delet = Summaries[id];
            Summaries.RemoveAt(id);
            return delet;
        }
    }
}
