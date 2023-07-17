using System;
using System.Collections.Generic;

namespace Ass_SWD.Model
{
    public partial class Fee
    {
        public int FeeId { get; set; }
        public int RecordId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? PaiedDate { get; set; }
        public decimal Amount { get; set; }
        public string? Method { get; set; }

        public virtual Record Record { get; set; } = null!;
    }
}
