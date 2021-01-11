using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoDBFirst.Entity
{
    public partial class SysRole
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }
    }
}
