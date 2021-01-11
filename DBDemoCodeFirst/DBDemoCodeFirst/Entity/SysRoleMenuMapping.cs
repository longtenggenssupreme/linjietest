using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoCodeFirst.Entity
{
    public partial class SysRoleMenuMapping
    {
        public int Id { get; set; }
        public int SysRoleId { get; set; }
        public int SysMenuId { get; set; }
    }
}
