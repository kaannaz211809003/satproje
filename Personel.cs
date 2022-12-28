using System;
using System.Collections.Generic;

#nullable disable

namespace PersonelApp.Models
{
    public partial class Personel
    {
        public Personel()
        {
            Payments = new HashSet<Payment>();
            PersonelCategories = new HashSet<PersonelCategory>();
            PersonelPermissions = new HashSet<PersonelPermission>();
            Seizures = new HashSet<Seizure>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tckn { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string PermissionDays { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PersonelCategory> PersonelCategories { get; set; }
        public virtual ICollection<PersonelPermission> PersonelPermissions { get; set; }
        public virtual ICollection<Seizure> Seizures { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
