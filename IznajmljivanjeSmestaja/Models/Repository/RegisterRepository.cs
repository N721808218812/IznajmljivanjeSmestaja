using IznajmljivanjeSmestaja.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingContext database = new BookingContext();
        public RegisterRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public RegisterRepository() { }
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
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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
            a.IdUser = userId;
            if (accomodationStaging.CoverPhotoUrl != null)
            {
                a.CoverPhotoUrl = accomodationStaging.CoverPhotoUrl;
            }
                

            a.AccomadationGallery = new List<AccomadationGallery>();

            await database.AccomodationStaging.AddAsync(a);
            //await database.SaveChangesAsync();


            var pom1 = a.Id;
            if (accomodationStaging.Gallery != null)
            {
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
            }
           
            //database.SaveChanges();

            //foreach(var pom in a.AccomadationGallery)
            //{
            //    database.AccomadationGallery.Add(pom);
            ////}


            return a.Id;
        }//create

        public async Task<int> Delete(int id)
        {
            try
            {
                var getAccomodationdetails = await database.Accomodation.FindAsync(id);
                List<AccomadationGallery> accomadationGallery = database.AccomadationGallery.Where(x => x.IdAccomodation == getAccomodationdetails.Id).ToList();
                List<Reservation> reservation = database.Reservation.Where(x => x.IdAccomodation == getAccomodationdetails.Id).ToList();

                if (accomadationGallery != null)
                {
                    foreach (var pom in accomadationGallery)
                        database.AccomadationGallery.Remove(pom);

                }
                if (reservation != null)
                {
                    foreach (var pom in reservation)
                        database.Reservation.Remove(pom);
                }
                database.Accomodation.Remove(getAccomodationdetails);
                database.SaveChanges();
                await database.SaveChangesAsync();
                int i = 1;

                return i;
            }
            catch (Exception ex)
            {
                int i = 0;
                Console.WriteLine(ex);
                return i;
            }
        }//delete

        public async Task<Accomodation> DetailsAccomodation(int id)
        {
            Accomodation accomodation = database.Accomodation.Where(x => x.Id == id).FirstOrDefault();
            List<AccomadationGallery> g = database.AccomadationGallery.Where(x => x.IdAccomodation == id).ToList();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Accomodation a = new Accomodation()
            {
                 
            Id =accomodation.Id,
                Address = accomodation.Address,
                Amenities = accomodation.Amenities,
                Checkin = accomodation.Checkin,
                Checkout = accomodation.Checkout,
                Description = accomodation.Description,
                Directions = accomodation.Directions,
                Rooms = accomodation.Rooms,
                Wifi = accomodation.Wifi,
                Title = accomodation.Title,
                Guests = accomodation.Guests,
                CoverPhotoUrl = accomodation.CoverPhotoUrl,
                IdUser = userId,
                Gallery = g


            };

            return a;
        }//details

        public async Task<int> Edit(Accomodation accomodation)
        {

            Accomodation a = database.Accomodation.Where(p => p.Id == accomodation.Id).FirstOrDefault();
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
            a.IdUser = accomodation.IdUser;
            if (accomodation.CoverPhotoUrl != null)
            {
                a.CoverPhotoUrl = accomodation.CoverPhotoUrl;
            }

            await database.SaveChangesAsync();


            if (accomodation.Gallery != null)
            {
                a.AccomadationGallery = new List<AccomadationGallery>();



                //await database.SaveChangesAsync();


                var pom1 = a.Id;

                List<AccomadationGallery> lista = database.AccomadationGallery.Where(pa => pa.IdAccomodation == pom1).ToList();
                foreach (var l in lista)
                {
                    database.AccomadationGallery.Remove(l);
                }

                database.SaveChanges();



                foreach (var file in accomodation.Gallery)
                {
                    AccomadationGallery ac = new AccomadationGallery();

                    ac.Url = file.Url;
                    ac.Name = file.Name;
                    ac.IdAccomodation = pom1;
                    //database.AccomadationGallery.Add(ac);
                    await database.AccomadationGallery.AddAsync(ac);

                }

                await database.SaveChangesAsync();

            }

            //database.SaveChanges();

            //foreach(var pom in a.AccomadationGallery)
            //{
            //    database.AccomadationGallery.Add(pom);
            ////}


            return a.Id;
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
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Reservation r = new Reservation();
            //r.Id = reservation.Id;
            r.DateCheckin = reservation.DateCheckin;
            r.DateCheckout = reservation.DateCheckout;
            r.IdAccomodation =id;
            
            r.IdUser = userId;
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

        public IEnumerable<AspNetUsers> GetAllUsers()
        {
            List<AspNetUsers> aspNetUsers = new List<AspNetUsers>();
            foreach (AspNetUsers aspNetUser in database.AspNetUsers)
            {
                AspNetUsers a = new AspNetUsers();
                a.Id = aspNetUser.Id;
                a.UserName = aspNetUser.UserName;
                a.Email = aspNetUser.Email;
                a.PhoneNumber = aspNetUser.PhoneNumber;
                aspNetUsers.Add(a);
            }
            return aspNetUsers;
        }//getAllUsers

    }//class
}//namespace
