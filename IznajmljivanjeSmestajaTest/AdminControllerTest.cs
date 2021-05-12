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
  }
}
