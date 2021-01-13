using System;
using System.Collections.Generic;

#nullable disable

namespace Linjie.NET5.DAL.Entity
{
    public partial class SysUserRoleMapping
    {
        public int Id { get; set; }
        public int SysUserId { get; set; }
        public int SysRoleId { get; set; }
    }
}
