using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DTO
{
 public   class PersonelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tckn { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        [DisplayName("İzin Günleri")]
      
        public string PermissionDays { get; set; }
    }
}
