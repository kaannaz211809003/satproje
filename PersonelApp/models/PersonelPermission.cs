using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class PersonelPermission
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PermissionHour { get; set; }
        public string Description { get; set; }
        public virtual Personel User { get; set; }
    }
}
