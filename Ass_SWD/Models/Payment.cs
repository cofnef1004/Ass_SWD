using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? PayedDate { get; set; }
        public decimal Total { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
