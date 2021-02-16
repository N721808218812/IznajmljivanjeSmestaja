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
        [Display(Name = "BrojSoba")]
        [Required(ErrorMessage = "obaveznoPolje")]
        public int Rooms { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [Display(Name = "BrojGostiju")]
        public int Guests { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [StringLength(150)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "obaveznoPolje")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [StringLength(100)]
        [Display(Name = "Amenities")]
        public string Amenities { get; set; }
        [StringLength(100)]
        [Display(Name = "Directions")]
        public string Directions { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [StringLength(50)]
        [Display(Name = "Checkin")]
        public string Checkin { get; set; }
        [Required(ErrorMessage = "obaveznoPolje")]
        [StringLength(50)]
        [Display(Name = "Checkout")]
        public string Checkout { get; set; }
        [Display(Name = "Wifi")]
        public bool? Wifi { get; set; }
        [Display(Name = "korisnickoIme")]
        public string IdUser { get; set; }
        [NotMappedAttribute]
        
        public IFormFile CoverPhoto { get; set; }
        [Display(Name = "coverUrl")]
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
