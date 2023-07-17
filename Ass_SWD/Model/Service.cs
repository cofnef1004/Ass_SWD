using System;
using System.Collections.Generic;

namespace Ass_SWD.Model
{
    public partial class Service
    {
        public Service()
        {
            Records = new HashSet<Record>();
        }

        public int ServiceId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal? Fee { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
