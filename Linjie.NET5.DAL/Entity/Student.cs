﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Linjie.NET5.DAL.Entity
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
