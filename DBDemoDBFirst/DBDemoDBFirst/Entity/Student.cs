using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoDBFirst.Entity
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? ClassId { get; set; }

        public virtual Wpfclass IdNavigation { get; set; }
    }
}
