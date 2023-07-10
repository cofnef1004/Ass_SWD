using System;
using System.Collections.Generic;

namespace Ass_SWD.Models
{
    public partial class Account
    {
        public Account()
        {
            Insurances = new HashSet<Insurance>();
            Patients = new HashSet<Patient>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FullName { get; set; }
        public DateTime Dob { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Cccd { get; set; } = null!;
        public int Age { get; set; }
        public bool Type { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
