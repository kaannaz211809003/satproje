using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DTO
{
   public class VardiyaDetailDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? SeizuresDate { get; set; }
        public TimeSpan? SeizuresStartDate { get; set; }
        public TimeSpan? SeizuresEndDate { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
