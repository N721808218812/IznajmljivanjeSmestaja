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
        public int IdUser { get; set; }
    }
}
