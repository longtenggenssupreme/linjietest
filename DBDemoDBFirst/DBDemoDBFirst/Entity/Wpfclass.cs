using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoDBFirst.Entity
{
    public partial class Wpfclass
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}
