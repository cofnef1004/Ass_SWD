using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Fee
    {
        public int FeeId { get; set; }
        public int PatientId { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? PayedDate { get; set; }
        public decimal Total { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
