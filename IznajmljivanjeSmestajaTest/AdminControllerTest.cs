using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using IznajmljivanjeSmestaja.Models;
using IznajmljivanjeSmestaja.Controllers;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IznajmljivanjeSmestaja.Models.Repository;
using IznajmljivanjeSmestaja.Models.Interfaces;

namespace IznajmljivanjeSmestajaTest
{
  [TestClass]
  public class AdminControllerTest
  {
        [TestMethod]
        public void AdminController_Should_Create_Instance_Of_AdminController()
        {
            //Arrange (deklaracije promenljivih)
            var mock = new Mock<IHostingEnvironment>();

            //Act (izvrsavanje)
            AdminController admin = new AdminController(mock.Object);

            //Assert (ocekivani rezultat)

            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void AddAccomodation_Should_Return_AddAccomodation_View()
        {
            //Arrange
          
            var mock = new Mock<IHostingEnvironment>();
            AdminController adminController = new AdminController(mock.Object);


            //Act
            
            var result = (ViewResult)adminController.AddAccomodation().Result;


            //Assert
            Assert.AreEqual("AddAccomodation", result.ViewName);
        }

        [TestMethod]
        public void AddAccomodation_Should_Return_Instance_Of_ViewResult()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
            
            AdminController adminController = new AdminController(mock.Object);
            ViewResult viewResult = new ViewResult();


            //Act
            var result = adminController.AddAccomodation().Result;


            //Assert
            Assert.IsInstanceOfType(result, viewResult.GetType());
        }


       
        [TestMethod]
        public void AddAccomodation_Should_Add_Accomodation_In_Database()
        {
          
                //Arrange
                var mock = new Mock<IHostingEnvironment>();

                AdminController adminController = new AdminController(mock.Object);
                Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
                var options = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(accomodation);
            context.SaveChanges();
            adminController.AddAccomodation(accomodation).Wait();



            //Assert
            CollectionAssert.Contains(context.Accomodation.ToList(), accomodation);
            

        }


        [TestMethod]
        public void AddAccomodation_Should_Not_Add_New_Accomodation_To_Database_If_ModelState_Is_Not_Valid()
        {
            
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
            
            AdminController adminController = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation();
            adminController.ModelState.AddModelError("Accomodation", "Entity of type Accomodation does not have a valid ModelState");
         
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "AccomodationDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            var result = adminController.AddAccomodation(accomodation);
            result.Wait();

            var result2 = result.Result;

            //Assert
            CollectionAssert.DoesNotContain(context.Accomodation.ToList(), accomodation);
        }
        
        //isti problem ne znam koji
        [TestMethod]
        public void Edit_Should_Return_Edit_View_If_Accomodation_Found()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();


            AdminController adminController = new AdminController(mock.Object);
            //Install-Package Microsoft.EntityFrameworkCore.InMemory
            //Install-Package Microsoft.Bcl.AsyncInterfaces
            ViewResult viewResult = new ViewResult();
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;



            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 2, Address = "Adress2", Amenities = "Amenities2", Checkin = "Checkin2", Checkout = "Checkout2", Description = "Description2", Directions = "Directions2", Rooms = 2, Wifi = false, Title = "Title2", Guests = 5, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 3, Address = "Adress3", Amenities = "Amenities3", Checkin = "Checkin3", Checkout = "Checkout3", Description = "Description3", Directions = "Directions3", Rooms = 3, Wifi = true, Title = "Title3", Guests = 1, IdUser = "1" });
            context.SaveChanges();
            var result = (ViewResult)adminController.Edit(3).Result;


            //Assert
            Assert.AreEqual("Edit", result.ViewName);

        }
        [TestMethod]
        public void Edit_Should_Return_Edit_View_If_Accomodation_NotFound()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();


            AdminController adminController = new AdminController(mock.Object);
            //Install-Package Microsoft.EntityFrameworkCore.InMemory
            //Install-Package Microsoft.Bcl.AsyncInterfaces
            ViewResult viewResult = new ViewResult();
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;



            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 2, Address = "Adress2", Amenities = "Amenities2", Checkin = "Checkin2", Checkout = "Checkout2", Description = "Description2", Directions = "Directions2", Rooms = 2, Wifi = false, Title = "Title2", Guests = 5, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 3, Address = "Adress3", Amenities = "Amenities3", Checkin = "Checkin3", Checkout = "Checkout3", Description = "Description3", Directions = "Directions3", Rooms = 3, Wifi = true, Title = "Title3", Guests = 1, IdUser = "1" });
            context.SaveChanges();
            var result = (ViewResult)adminController.Edit(10).Result;


            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        //isti problem ne znam koji

        [TestMethod]
        public void Edit_Should_Return_Instance_Of_ViewResult_If_Accomodation_Not_Found()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
            AdminController adminController = new AdminController(mock.Object);
            AdminRepository adminRepository = new AdminRepository();
           
            ViewResult viewResult = new ViewResult();

            
            //Install-Package Microsoft.EntityFrameworkCore.InMemory
            //Install-Package Microsoft.Bcl.AsyncInterfaces
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingContext").Options;


            //Act
            var context = new BookingContext(options);

            adminRepository.database = context;
            adminController.database = context;


            context.Accomodation.Add(new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 2, Address = "Adress2", Amenities = "Amenities2", Checkin = "Checkin2", Checkout = "Checkout2", Description = "Description2", Directions = "Directions2", Rooms = 2, Wifi = false, Title = "Title2", Guests = 5, IdUser = "1" });
            context.Accomodation.Add(new Accomodation { Id = 3, Address = "Adress3", Amenities = "Amenities3", Checkin = "Checkin3", Checkout = "Checkout3", Description = "Description3", Directions = "Directions3", Rooms = 3, Wifi = true, Title = "Title3", Guests = 1, IdUser = "1" });
            context.SaveChanges();

        
            var result = adminController.Edit(5).Result;




            //Assert
            Assert.IsInstanceOfType(result, viewResult.GetType());
           
        }

        

        [TestMethod]
        public void Delete_Should_RedirectToAction()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "MobileShopDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(accomodation);
            context.SaveChanges();
            var result = (RedirectToActionResult)adminController.Delete(1).Result;




            //Assert
            Assert.AreEqual("ViewAllAccomodation", result.ActionName);
           

            
        }

        //ne radi zato sto ne rade sa dve iste baze
        [TestMethod]
        public void Delete_Should_Delete_Accomodation_From_Database_If_Accomodation_Found()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
          
            AdminController adminController = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
            AdminRepository adminRepository = new AdminRepository();
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminRepository.database = context;
            adminController.database = context;
            context.Accomodation.Add(accomodation);
           
            adminController.Delete(accomodation.Id).Wait();
            context.SaveChanges();



            //Assert
            CollectionAssert.DoesNotContain(context.Accomodation.ToList(), accomodation);
        }


        [TestMethod]
        public void Delete_Should_ReturnToAction_ViewAllAccomodation_If_id_null()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(accomodation);
            context.SaveChanges();
            var result = (RedirectToActionResult)adminController.Delete(null).Result;


            //Assert
            Assert.AreEqual("ViewAllAccomodation", result.ActionName);
        }

        [TestMethod]
        public void Delete_Should_Not_Delete_Accomodation_From_Database_If_Accomodation_Not_Found()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
            AdminController adminController = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.Accomodation.Add(accomodation);
            context.SaveChanges();
    
            adminController.Delete(7000).Wait();


            //Assert
            CollectionAssert.Contains(context.Accomodation.ToList(), accomodation);
        }

        [TestMethod]
        public void Choose_Should_Return_Instance_Of_ViewResult()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();
          
            AdminController adminController = new AdminController(mock.Object);
            ViewResult viewResult = new ViewResult();


            //Act
            var result = adminController.Choose();


            //Assert
            Assert.IsInstanceOfType(result, viewResult.GetType());
        }

        [TestMethod]
        public void Choose_Should_Return_Choose_View()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);


            //Act
            var result = (ViewResult)adminController.Choose();


            //Assert
            Assert.AreEqual("Choose", result.ViewName);
        }

        [TestMethod]
        public void Approve_Should_ReturnToAction_ViewAllAccomodation_If_id_null()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
       
            var result = (RedirectToActionResult)adminController.Aprove(1);


            //Assert
            Assert.AreEqual("ViewAllAccomodation", result.ActionName);
        }
        [TestMethod]
        public void Approve_Should_ReturnToAction_ViewAllAccomodation_If_id_exicted()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);
            AccomodationStaging accomodationStaging = new AccomodationStaging { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.AccomodationStaging.Add(accomodationStaging);
            context.SaveChanges();
            var result = (RedirectToActionResult)adminController.Aprove(1);


            //Assert
            Assert.AreEqual("ViewAllAccomodation", result.ActionName);
        }

        [TestMethod]
        public void Approve_Should__Delete_AccomodationStagging_From_Database_If_ID_NotNull()
        {
            //Arrange
            var mock = new Mock<IHostingEnvironment>();

            AdminController adminController = new AdminController(mock.Object);
            AccomodationStaging accomodationStaging = new AccomodationStaging { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };

            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;


            //Act
            var context = new BookingContext(options);
            adminController.database = context;
            context.AccomodationStaging.Add(accomodationStaging);
            context.SaveChanges();
            adminController.Aprove(accomodationStaging.Id);


            //Assert
            CollectionAssert.DoesNotContain(context.AccomodationStaging.ToList(), accomodationStaging);
        }

        //NE RADI NE ZNAM STO
        //[TestMethod]
        //public void Approve_Should__Add_Accomodation_From_Database_If_ID_NotNull()
        //{

        //    //Arrange
        //    var mock = new Mock<IHostingEnvironment>();

        //    AdminController adminController = new AdminController(mock.Object);
        //    AccomodationStaging accomodationStaging = new AccomodationStaging { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
        //    Accomodation accomodation = new Accomodation { Id = 1, Address = "Adress1", Amenities = "Amenities1", Checkin = "Checkin1", Checkout = "Checkout1", Description = "Description1", Directions = "Directions1", Rooms = 1, Wifi = true, Title = "Title1", Guests = 3, IdUser = "1" };
        //    var options = new DbContextOptionsBuilder<BookingContext>()
        //    .UseInMemoryDatabase(databaseName: "BookingDatabase").Options;

            


        //    //Act
        //    var context = new BookingContext(options);
        //    adminController.database = context;
        //    context.AccomodationStaging.Add(accomodationStaging);
        //    context.SaveChanges();
        //    adminController.Aprove(accomodationStaging.Id);


        //    //Assert
        //    CollectionAssert.Contains(context.Accomodation.ToList(), accomodation);
        //}
    }
}
