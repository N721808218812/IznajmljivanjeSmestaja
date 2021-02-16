using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class Reservation
    {
        [Key]
        [Display(Name = "idReservation")]
        public int Id { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [Display(Name = "Checkin")]
        public DateTime DateCheckin { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [Display(Name = "Checkout")]
        public DateTime DateCheckout { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        public int IdAccomodation { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [Display(Name = "korisnickoIme")]
        public string IdUser { get; set; }

        public virtual Accomodation IdAccomodationNavigation { get; set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }
    }
}
