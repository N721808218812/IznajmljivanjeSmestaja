using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Interfaces
{
    public interface IRegisterRepository
    {
        void Create(AccomodationStaging accomodationStaging);
        Accomodation GetBySmestajId(int id);
        void Edit(Accomodation accomodation);
        void Delete(Accomodation accomodation);

        IEnumerable<Accomodation> ViewAll();

        Reservation GetByReservationId(int id);
        void Reserve(Reservation reservation,int id);
        void CancelReservation(Reservation reservation);

        IEnumerable<Reservation> GetByUserId(int id); //metoda da korisnik vidi sve svoje rezervacije

        IEnumerable<Reservation> GetByAccomodation(int id); //korisnik vidi ko mu je rezervisao taj smestaj




    }
}
