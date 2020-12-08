using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 产生模拟数据
    /// </summary>
    public class GenerateMockData
    {
        /// <summary>
        /// 产生指定数据量的数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<Test> GetTests(int count)
        {
            var profileGenerator = new Faker<Test>()
                 .RuleFor(p => p.Title, v => v.Person.FirstName)
                 .RuleFor(p => p.Content, v => v.Person.LastName)
                 .RuleFor(p => p.CreateDateTime, v => v.Person.DateOfBirth);
            return profileGenerator.Generate(count);
        }        
    }
}
