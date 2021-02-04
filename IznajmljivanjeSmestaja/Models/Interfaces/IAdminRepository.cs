using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Interfaces
{
   public interface IAdminRepository
    {
        void Aprove(AccomodationStaging accomodationStaging);
        IEnumerable<AccomodationStaging> getAllStagging();
        IEnumerable<Accomodation> getAll();
        AccomodationStaging GetSmestajByStaggingId(int id);
        Accomodation GetBySmestajId(int id);
        void Edit(Accomodation accomodation);
        void Add(Accomodation accomodation);
        void Delete(int id);

        IEnumerable<AspNetUsers> GetAllUsers();
    }
}
