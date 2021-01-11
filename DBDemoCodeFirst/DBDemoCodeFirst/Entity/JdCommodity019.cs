using System;
using System.Collections.Generic;

#nullable disable

namespace DBDemoCodeFirst.Entity
{
    public partial class JdCommodity019
    {
        public int Id { get; set; }
        public long? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}
