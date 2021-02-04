using IznajmljivanjeSmestaja.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        public void CancelReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void Create(AccomodationStaging accomodationStaging)
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

        public IEnumerable<Reservation> GetByAccomodation(int id)
        {
            throw new NotImplementedException();
        }

        public Reservation GetByReservationId(int id)
        {
            throw new NotImplementedException();
        }

        public Accomodation GetBySmestajId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void Reserve(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> ViewAll()
        {
            throw new NotImplementedException();
        }
    }
}
