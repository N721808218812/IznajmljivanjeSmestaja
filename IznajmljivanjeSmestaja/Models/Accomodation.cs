using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            AccomadationGallery = new HashSet<AccomadationGallery>();
            Reservation = new HashSet<Reservation>();
        }
        [Key]
        [Display(Name = "idAccomodation")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "BrojSoba")]
        public int Rooms { get; set; }
        [Required]
        [Display(Name = "BrojGostiju")]
        public int Guests { get; set; }
        //[Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        //[Required]
        [StringLength(150)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [StringLength(1000)]
        //[Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [StringLength(100)]
        [Display(Name = "Amenities")]
        public string Amenities { get; set; }
        [StringLength(100)]
        [Display(Name = "Directions")]
        public string Directions { get; set; }
        //[Required]
        [StringLength(50)]
        [Display(Name = "Checkin")]
        public string Checkin { get; set; }
        //[Required]
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
        public virtual ICollection<Reservation> Reservation { get; set; }





        [NotMappedAttribute]
       
        public IFormFileCollection GalleryFiles { get; set; }

        [NotMappedAttribute]
        [ForeignKey("Accomodation")]
        public List<AccomadationGallery> Gallery { get; set; }

    }
}
