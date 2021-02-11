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
            try
            { 
                Reservation r = database.Reservation.Where(i => i.Id.Equals(reservation.Id)).FirstOrDefault();
                database.Reservation.Remove(r);
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }//cancelReservation

        public async Task<int> Create(AccomodationStaging accomodationStaging)
        {
            AccomodationStaging a = new AccomodationStaging();
            a.Address = accomodationStaging.Address;
            a.Amenities = accomodationStaging.Amenities;
            a.Checkin = accomodationStaging.Checkin;
            a.Checkout = accomodationStaging.Checkout;
            a.Description = accomodationStaging.Description;
            a.Directions = accomodationStaging.Directions;
            a.Rooms = accomodationStaging.Rooms;
            a.Wifi = accomodationStaging.Wifi;
            a.Title = accomodationStaging.Title;
            a.Guests = accomodationStaging.Guests;
            a.IdUser = accomodationStaging.IdUser;
            a.CoverPhotoUrl = accomodationStaging.CoverPhotoUrl;

            a.AccomadationGallery = new List<AccomadationGallery>();

            await database.AccomodationStaging.AddAsync(a);
            //await database.SaveChangesAsync();


            var pom1 = a.Id;

            foreach (var file in accomodationStaging.Gallery)
            {
                AccomadationGallery ac = new AccomadationGallery();
                ac.Url = file.Url;
                ac.Name = file.Name;
                ac.IdAccomodationStaging = pom1;
                //database.AccomadationGallery.Add(ac);
                await database.AccomadationGallery.AddAsync(ac);

            }

            await database.SaveChangesAsync();
            //database.SaveChanges();

            //foreach(var pom in a.AccomadationGallery)
            //{
            //    database.AccomadationGallery.Add(pom);
            ////}


            return a.Id;
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
            List<Reservation> reservations = new List<Reservation>();
            foreach (Reservation reservation in database.Reservation)
            {
                if(reservation.IdAccomodation==id)
                    reservations.Add(reservation);
            }
            return reservations;
        }//getByAccomodation

        public Reservation GetByReservationId(int id)
        {
            Reservation r = new Reservation();
            foreach (Reservation reservation in database.Reservation)
            {
                if (reservation.Id == id)
                    r = reservation;
            }
            return r;
        }//getByReservationId

        public Accomodation GetBySmestajId(int id)
        {
            Accomodation a = new Accomodation();
            foreach (Accomodation accomodation in database.Accomodation)
            {
                if (accomodation.Id == id)
                    a= accomodation;
            }
            return a;
            
        }//getBySmestajId

        public IEnumerable<Reservation> GetByUserId(string id)
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach (Reservation reservation in database.Reservation)
            {
                if(reservation.IdUser.Equals(id))
                       reservations.Add(reservation);
            }
            return reservations;
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
                accomodations.Add(accomodation);
            }
            return accomodations;
        }//ViewAll

        public IEnumerable<Reservation> ViewAllReservations() //sve rezervacije
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach(Reservation reservation in database.Reservation)
            {
                reservations.Add(reservation);
            }
            return reservations;
        }//ViewAllReservations

    }//class
}//namespace
