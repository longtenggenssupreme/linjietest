using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly Dictionary<int, string> authors = new Dictionary<int, string>();
        public DefaultController()
        {
            authors.Add(1, "Joydip Kanjilal");
            authors.Add(2, "Steve Smith");
            authors.Add(3, "Michele Smith");
        }
        [HttpGet]
        public List<string> Get()
        {
            List<string> lstAuthors = new List<string>();
            foreach (KeyValuePair<int, string> keyValuePair in authors)
                lstAuthors.Add(keyValuePair.Value);
            return lstAuthors;
        }
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return authors[id];
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
            authors.Add(4, value);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            authors[id] = value;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            authors.Remove(id);
        }
    }
}
