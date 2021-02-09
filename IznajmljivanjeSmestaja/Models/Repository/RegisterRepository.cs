using IznajmljivanjeSmestaja.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        public BookingContext database = new BookingContext();
        public void CancelReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }//cancelReservation

        public void Create(AccomodationStaging accomodationStaging)
        {
            throw new NotImplementedException();
        }//create

        public void Delete(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }//delete

        public void Edit(Accomodation accomodation)
        {
            var a = database.Accomodation.SingleOrDefault(ac => ac.Id == accomodation.Id);
            a.Address = accomodation.Address;
            a.Amenities = accomodation.Amenities;
            a.Checkin = accomodation.Checkin;
            a.Checkout = accomodation.Checkout;
            a.Description = accomodation.Description;
            a.Directions = accomodation.Directions;
            a.Rooms = accomodation.Rooms;
            a.Wifi = accomodation.Wifi;
            a.Title = accomodation.Title;
            a.Guests = accomodation.Guests;

            try
            {
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }//edit

        public IEnumerable<Reservation> GetByAccomodation(int id)
        {
            throw new NotImplementedException();
        }//getByAccomodation

        public Reservation GetByReservationId(int id)
        {
            throw new NotImplementedException();
        }//getByReservationId

        public Accomodation GetBySmestajId(int id)
        {
            throw new NotImplementedException();
        }//getBySmestajId

        public IEnumerable<Reservation> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }//getByUserId

        public void Reserve(Reservation reservation,int id)
        {
            Reservation r = new Reservation();
            //r.Id = reservation.Id;
            r.DateCheckin = reservation.DateCheckin;
            r.DateCheckout = reservation.DateCheckout;
            r.IdAccomodation =id;
            
            r.IdUser = reservation.IdUser;
            if (database.AspNetUsers.Any(u => u.Id.Equals(r.IdUser)))
            {
                database.Reservation.Add(r);
                database.SaveChanges();
            }
            else
            {
                return;
            }
            
            //try
            //{
            //    database.SaveChanges();
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }//reserve

        

        public IEnumerable<Accomodation> ViewAll() //sva ponuda stanova
        {
            List<Accomodation> accomodations = new List<Accomodation>();
            foreach (Accomodation accomodation in database.Accomodation)
            {
                //Accomodation a = new Accomodation();
                //a.Address = accomodation.Address;
                //a.Amenities = accomodation.Amenities;
                //a.Checkin = accomodation.Checkin;
                //a.Checkout = accomodation.Checkout;
                //a.Description = accomodation.Description;
                //a.Directions = accomodation.Directions;
                //a.Rooms = accomodation.Rooms;
                //a.Wifi = accomodation.Wifi;
                //a.Title = accomodation.Title;
                //a.Guests = accomodation.Guests;
                //a.IdUser = accomodation.IdUser;

                accomodations.Add(accomodation);
            }
            return accomodations;
        }//ViewAll

    }//class
}//namespace
