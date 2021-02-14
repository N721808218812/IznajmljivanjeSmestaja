using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            Accomodation = new HashSet<Accomodation>();
            AccomodationStaging = new HashSet<AccomodationStaging>();
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Reservation = new HashSet<Reservation>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Accomodation> Accomodation { get; set; }
        public virtual ICollection<AccomodationStaging> AccomodationStaging { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
