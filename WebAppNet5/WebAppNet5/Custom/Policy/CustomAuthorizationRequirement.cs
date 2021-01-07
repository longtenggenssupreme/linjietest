using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 可以自定义验证需要的内容信息
    /// </summary>
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public CustomAuthorizationRequirement(string policy)
        {
            Name = policy;
        }
    }
}
