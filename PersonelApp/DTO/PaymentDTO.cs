using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string PaymentDescription { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string Name { get; set; }
    }
}
