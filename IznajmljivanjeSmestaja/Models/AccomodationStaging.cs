using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class AccomodationStaging
    {
        public AccomodationStaging()
        {
            AccomadationGallery = new HashSet<AccomadationGallery>();
            
        }
        [Key]
        public int Id { get; set; }

        public int Rooms { get; set; }
        [Required]
        public int Guests { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        [StringLength(100)]
        public string Amenities { get; set; }
        [StringLength(100)]
        public string Directions { get; set; }
        [Required]
        [StringLength(50)]
        public string Checkin { get; set; }
        [Required]
        [StringLength(50)]
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
