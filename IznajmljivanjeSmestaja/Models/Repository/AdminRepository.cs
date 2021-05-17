using IznajmljivanjeSmestaja.Controllers;
using IznajmljivanjeSmestaja.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public BookingContext database { get; set; }
        public AdminRepository()
        {
            database = new BookingContext();


        }

        //public BookingContext database = new BookingContext();
        public async Task<int> Add(Accomodation accomodation)
        {
            
            Accomodation a = new Accomodation();
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
            
            a.AccomadationGallery = new List<AccomadationGallery>();

          

            await database.Accomodation.AddAsync(a);
            //await database.SaveChangesAsync();


            var pom1 = a.Id;
            if (accomodation.Gallery != null)
            {

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
            
        }

        public void Aprove(AccomodationStaging accomodationStaging)
        {
            Accomodation a = new Accomodation();
            a.Address = accomodationStaging.Address;
            a.Amenities = accomodationStaging.Amenities;
            a.Checkin = accomodationStaging.Checkin;
            a.Checkout = accomodationStaging.Checkout;
            a.Description = accomodationStaging.Description;
            a.Directions = accomodationStaging.Directions;
            a.IdUser = accomodationStaging.IdUser;
            a.Rooms = accomodationStaging.Rooms;
            a.Wifi = accomodationStaging.Wifi;
            a.Title = accomodationStaging.Title;
            a.Guests = accomodationStaging.Guests;
            a.CoverPhotoUrl = accomodationStaging.CoverPhotoUrl;

            

            database.Accomodation.Add(a);
            try
            {

               
                database.SaveChanges();

                //List<AccomadationGallery> ag = database.AccomadationGallery.Where(p => p.IdAccomodationStaging == accomodationStaging.Id).ToList();
                //if (ag != null)
                //{
                //    foreach (var file in ag)
                //    {
                //        AccomadationGallery ac = new AccomadationGallery();
                //        ac.Url = file.Url;
                //        ac.Name = file.Name;
                //        ac.IdAccomodation = a.Id;
                //        //database.AccomadationGallery.Add(ac);
                //        database.AccomadationGallery.Add(ac);
                //        database.AccomadationGallery.Remove(file);

                //    }
                //}
                database.AccomodationStaging.Remove(accomodationStaging);
                database.SaveChanges();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

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
                int i= 1;

                return i;
            }
            catch (Exception ex)
            {
                int i = 0;
                Console.WriteLine(ex);
                return i;
            }
        }

        public async Task<int> Edit(Accomodation accomodation)
        {

            Accomodation a = database.Accomodation.Where(p => p.Id == accomodation.Id).FirstOrDefault();
            if (a != null) { 
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


            }

            //database.SaveChanges();

            //foreach(var pom in a.AccomadationGallery)
            //{
            //    database.AccomadationGallery.Add(pom);
            ////}


            return a.Id;

        }

        public IEnumerable<Accomodation> getAll()
        {
           
            List<Accomodation> accomodations = new List<Accomodation>();
            foreach (Accomodation accomodation in database.Accomodation)
            {
               

                accomodations.Add(accomodation);
            }
            return accomodations;
        }

        public IEnumerable<AccomodationStaging> getAllStagging()
            
        {
            List<AccomodationStaging> accomodationsStaging = new List<AccomodationStaging>();
            foreach (AccomodationStaging accomodationStaging in database.AccomodationStaging)
            {
                AccomodationStaging a = new AccomodationStaging();
                a.Address = accomodationStaging.Address;
                a.Amenities = accomodationStaging.Amenities;
                a.Checkin = accomodationStaging.Checkin;
                a.Checkout = accomodationStaging.Checkout;
                a.Description = accomodationStaging.Description;
                a.Directions = accomodationStaging.Directions;
                a.IdUser = accomodationStaging.IdUser;
                a.Rooms = accomodationStaging.Rooms;
                a.Wifi = accomodationStaging.Wifi;
                a.Title = accomodationStaging.Title;
                a.Guests = accomodationStaging.Guests;
                a.Id = accomodationStaging.Id;
                a.CoverPhotoUrl = accomodationStaging.CoverPhotoUrl;
                accomodationsStaging.Add(a);
            }
            return accomodationsStaging;
        }

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
        }

        public Accomodation GetBySmestajId(int id)
        {

            return (database.Accomodation.Where(x => x.Id == id).FirstOrDefault());

        }

        public AccomodationStaging GetSmestajByStaggingId(int id)
        {
            return (database.AccomodationStaging.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<Accomodation> DetailsAccomodation(int id)
        {
            
           
            Accomodation accomodation=database.Accomodation.Where(x => x.Id == id).FirstOrDefault();

            if (accomodation != null)
            {
                List<AccomadationGallery> g = database.AccomadationGallery.Where(x => x.IdAccomodation == id).ToList();
                Accomodation a = new Accomodation()
                {

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
                    IdUser = accomodation.IdUser,
                    Gallery = g


                };


                return a;
            }
            else
            {
                accomodation = null;
                return accomodation;
            }

            
        }
    }
}
