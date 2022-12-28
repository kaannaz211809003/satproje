using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class Seizure
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? SeizuresDate { get; set; }
        public TimeSpan? SeizuresStartDate { get; set; }
        public TimeSpan? SeizuresEndDate { get; set; }
      
        public virtual Personel User { get; set; }
          public string Location { get; set; }
    }
}
