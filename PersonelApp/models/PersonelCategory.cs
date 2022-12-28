using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class PersonelCategory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CategoryName { get; set; }
        public int? WeeklyWorkTime { get; set; }

        public virtual Personel User { get; set; }
    }
}
