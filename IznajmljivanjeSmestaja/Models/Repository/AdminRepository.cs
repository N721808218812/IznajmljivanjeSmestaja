using IznajmljivanjeSmestaja.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public void Add(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }

        public void Aprove(AccomodationStaging accomodationStaging)
        {
            throw new NotImplementedException();
        }

        public void Delete(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }

        public void Edit(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> getAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccomodationStaging> getAllStagging()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Accomodation GetBySmestajId(int id)
        {
            throw new NotImplementedException();
        }

        public AccomodationStaging GetSmestajByStaggingId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
