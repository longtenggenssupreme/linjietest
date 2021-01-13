using System;
using System.Collections.Generic;

#nullable disable

namespace Linjie.NET5.DAL.Entity
{
    public partial class SysLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Introduction { get; set; }
        public string Detail { get; set; }
        public byte LogType { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }
    }
}
