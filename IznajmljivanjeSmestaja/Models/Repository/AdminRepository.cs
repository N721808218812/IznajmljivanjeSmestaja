using IznajmljivanjeSmestaja.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IznajmljivanjeSmestaja.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public BookingContext database = new BookingContext();
        public void Add(Accomodation accomodation)
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
            database.Accomodation.Add(a);
            try
            {
                database.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

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
            database.Accomodation.Add(a);
            try
            {
                database.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

}

        public void Delete(int id)
        {
            try
            {
                Accomodation accomodation = database.Accomodation.Where(x => x.Id == id).FirstOrDefault();
                database.Accomodation.Remove(accomodation);
                database.SaveChanges();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

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
            }catch(Exception ex)
            {
             Console.WriteLine(ex);
            }
        }

        public IEnumerable<Accomodation> getAll()
        {
            List<Accomodation> accomodations = new List<Accomodation>();
            foreach (Accomodation accomodation in database.Accomodation)
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

                accomodations.Add(a);
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
    }
}
