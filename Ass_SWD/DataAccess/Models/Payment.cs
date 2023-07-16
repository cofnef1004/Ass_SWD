using System;
using System.Collections.Generic;

namespace Ass_SWD.DataAccess.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceNumber { get; set; }
        public int CategoryId { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? PayedDate { get; set; }
        public string? Partner { get; set; }
        public int? DepartmentId { get; set; }
        public decimal Amount { get; set; }
        public bool? Status { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
