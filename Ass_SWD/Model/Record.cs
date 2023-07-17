using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Record
    {
        public Record()
        {
            Fees = new HashSet<Fee>();
        }

        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime RecordDate { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
        public string? TestResult { get; set; }
        public string? ImagingResult { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
