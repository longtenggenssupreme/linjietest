using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
