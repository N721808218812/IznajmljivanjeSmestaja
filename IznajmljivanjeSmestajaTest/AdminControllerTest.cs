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


        //nije prosao ne znam da li je dobar test
        [TestMethod]
        public void AddAccomodation_Should_Add_Accomodation_In_Database()
        {
            //Arange
            var mock = new Mock<IHostingEnvironment>();
            AdminController admin = new AdminController(mock.Object);
            Accomodation accomodation = new Accomodation();
          
            var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BokingContext").Options;
            var database = new BookingContext(options);

            //Act

            admin.database = database;
            admin.AddAccomodation(accomodation).Wait();

           
            // Assert

            CollectionAssert.Contains(database.Accomodation.ToList(), accomodation);
            
        }

      
    }
}
