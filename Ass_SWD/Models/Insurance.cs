using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Insurance
    {
        public int InsuranceId { get; set; }
        public string Number { get; set; } = null!;
        public int PatientId { get; set; }
        public string Type { get; set; } = null!;
        public string Supplier { get; set; } = null!;
        public decimal Percent { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
