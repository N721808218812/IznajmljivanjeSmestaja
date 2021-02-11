using Microsoft.AspNetCore.Mvc;
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
        Task<int> Edit(Accomodation accomodation);
        Task<int> Add(Accomodation accomodation);
        Task<int> Delete(int id);
        Task<Accomodation> DetailsAccomodation(int id);

        IEnumerable<AspNetUsers> GetAllUsers();
    }
}
