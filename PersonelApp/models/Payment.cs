using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string PaymentDescription { get; set; }
        public decimal? PaymentAmount { get; set; }

        public virtual Personel User { get; set; }
    }
}
