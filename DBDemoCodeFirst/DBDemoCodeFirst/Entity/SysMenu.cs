using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoCodeFirst.Entity
{
    public partial class SysMenu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public byte MenuLevel { get; set; }
        public byte MenuType { get; set; }
        public string MenuIcon { get; set; }
        public string Description { get; set; }
        public string SourcePath { get; set; }
        public int Sort { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }
    }
}
