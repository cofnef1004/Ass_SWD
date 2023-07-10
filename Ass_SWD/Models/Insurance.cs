using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Insurance
    {
        public int InsuranceId { get; set; }
        public string Number { get; set; } = null!;
        public int AccountId { get; set; }
        public string Type { get; set; } = null!;
        public string Supplier { get; set; } = null!;
        public decimal Percent { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
