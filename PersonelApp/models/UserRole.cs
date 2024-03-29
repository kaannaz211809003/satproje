﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Personel User { get; set; }
    }
}
