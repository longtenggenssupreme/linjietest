using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 自定义权限验证
    /// </summary>
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            if (requirement.Name == "police1")//根据据时间需要进行相应的处理
            {
            }
            if (requirement.Name == "police2")//根据据时间需要进行相应的处理
            {

            }
            if (requirement.Name == "policy01")
            {
                var user = context.User.FindFirst(a => a.Value.Contains("Admin"));//"Admin Teacher Stdent"
                if (user != null)
                {
                    //验证成功"custompolicy"
                    context.Succeed(requirement);
                }
            }

            //验证失败
            return Task.CompletedTask;
        }
    }
}
