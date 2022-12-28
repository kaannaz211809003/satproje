using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DTO
{
 public   class AddSeizure
    {
        public int? UserId { get; set; }
        public DateTime? SeizuresDate { get; set; }
        public TimeSpan? SeizuresStartDate { get; set; }
        public TimeSpan? SeizuresEndDate { get; set; }
        public bool? PayMoney { get; set; }
        public string Location { get; set; }
    }
}
