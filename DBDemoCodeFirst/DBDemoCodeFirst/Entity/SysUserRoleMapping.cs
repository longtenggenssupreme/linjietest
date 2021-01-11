using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoCodeFirst.Entity
{
    public partial class SysUserRoleMapping
    {
        public int Id { get; set; }
        public int SysUserId { get; set; }
        public int SysRoleId { get; set; }
    }
}
