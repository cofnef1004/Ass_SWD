using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Category
    {
        public Category()
        {
            Payments = new HashSet<Payment>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; }

    }
}
