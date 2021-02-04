using System;
using System.Collections.Generic;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime DateCheckin { get; set; }
        public DateTime DateCheckout { get; set; }
        public int IdAccomodation { get; set; }
        public string IdUser { get; set; }

        public virtual Accomodation IdAccomodationNavigation { get; set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }
    }
}
