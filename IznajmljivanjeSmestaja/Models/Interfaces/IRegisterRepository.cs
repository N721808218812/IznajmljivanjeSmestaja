using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Interfaces
{
    public interface IRegisterRepository
    {
        Task<int> Create(AccomodationStaging accomodationStaging);//dodaj smestaj
        Accomodation GetBySmestajId(int id);//pronadji smestaj
        Task<int> Edit(Accomodation accomodation);//izmeni smestaj
        Task<int> Delete(int id);//obrisi smestaj

        IEnumerable<Accomodation> ViewAll();//svi smestaji
        IEnumerable<Reservation> ViewAllReservations();//sve rezervacije

        Reservation GetByReservationId(int id);//pronadji reservaciju
        void Reserve(Reservation reservation,int id);//rezervisi
        void CancelReservation(Reservation reservation); //otkazi reservaciju

        IEnumerable<Reservation> GetByUserId(string id); //metoda da korisnik vidi sve svoje rezervacije

        IEnumerable<Reservation> GetByAccomodation(int id); //korisnik vidi ko mu je rezervisao taj smestaj

        Task<Accomodation> DetailsAccomodation(int id);

        IEnumerable<AspNetUsers> GetAllUsers();




    }
}
