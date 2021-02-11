﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class AccomodationStaging
    {
        public AccomodationStaging()
        {
            AccomadationGallery = new HashSet<AccomadationGallery>();
            
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
        [NotMappedAttribute]
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoUrl { get; set; }

        public virtual AspNetUsers IdUserNavigation { get; set; }
        public virtual ICollection<AccomadationGallery> AccomadationGallery { get; set; }

        [NotMappedAttribute]
        public IFormFileCollection GalleryFiles { get; set; }

        [NotMappedAttribute]
        [ForeignKey("AccomodationStaging")]
        public List<AccomadationGallery> Gallery { get; set; }
    }
}
