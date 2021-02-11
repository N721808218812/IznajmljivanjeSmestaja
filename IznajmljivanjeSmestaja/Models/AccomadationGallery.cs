using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class AccomadationGallery
    {
        public int Id { get; set; }
        public int? IdAccomodation { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public int? IdAccomodationStaging { get; set; }

        public virtual Accomodation IdAccomodationNavigation { get; set; }
        
        public virtual AccomodationStaging IdAccomodationStagingNavigation { get; set; }
        public Accomodation accomodation;
        public AccomodationStaging accomodationStaging;
    }
}
