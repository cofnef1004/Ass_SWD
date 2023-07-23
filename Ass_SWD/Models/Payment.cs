using Ass_SWD.Models;
using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceNumber { get; set; }
        public int CategoryId { get; set; }
        public DateTime? PayedDate { get; set; }
        public string? BillingInformation { get; set; }
        public decimal Amount { get; set; }
        public bool? Status { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
