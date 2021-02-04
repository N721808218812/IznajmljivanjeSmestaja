﻿using System;
using System.Collections.Generic;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int Rooms { get; set; }
        public int Guests { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        public string Directions { get; set; }
        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public bool? Wifi { get; set; }
        public string IdUser { get; set; }

        public virtual AspNetUsers IdUserNavigation { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
