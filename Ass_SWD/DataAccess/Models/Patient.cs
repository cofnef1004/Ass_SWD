using System;
using System.Collections.Generic;

namespace Ass_SWD.DataAccess.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Insurances = new HashSet<Insurance>();
            Records = new HashSet<Record>();
        }

        public int PatientId { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string NumberId { get; set; } = null!;

        public virtual ICollection<Insurance> Insurances { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
