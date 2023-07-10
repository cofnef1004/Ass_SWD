using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Fees = new HashSet<Fee>();
        }

        public int PatientId { get; set; }
        public int AccountId { get; set; }
        public int TreatMentType { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
