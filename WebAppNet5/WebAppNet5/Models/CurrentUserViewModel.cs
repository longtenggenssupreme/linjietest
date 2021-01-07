using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



//namespace WebAppNet5.Models
//{
//    public class ErrorViewModel
//    {
//        public string RequestId { get; set; }

//        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
//    }
//}

namespace WebAppNet5
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class CurrentUserViewModel
    {
        public string Id { get; set; }
        [Display(Order = 15000)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "用户名不能大于{2} 且要小于{1}")]
        //[Remote("User", "Validate", HttpMethod = "post", ErrorMessage = "用户名已经存在")]//后台验证
        public string Name { get; set; }
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空")]
        [StringLength(60, MinimumLength = 20, ErrorMessage = "密码必须在{2} 和{1}之间")]
        public string Password { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
