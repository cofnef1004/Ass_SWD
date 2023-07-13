﻿using System;
using System.Collections.Generic;

namespace Ass_SWD.DataAccess.Models
{
    public partial class staff
    {
        public int StaffId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string NumberId { get; set; } = null!;
        public string? Role { get; set; }
    }
}
