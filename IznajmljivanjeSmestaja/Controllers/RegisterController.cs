using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IznajmljivanjeSmestaja.Models;
using IznajmljivanjeSmestaja.Models.Interfaces;
using IznajmljivanjeSmestaja.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IznajmljivanjeSmestaja.Controllers
{
    public class RegisterController : Controller
    {
        public BookingContext database = new BookingContext();
        private readonly IRegisterRepository _registerRepository = null;
        public RegisterController()
        {
            _registerRepository = new RegisterRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAll()
        {
            return View(_registerRepository.ViewAll());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ViewAll");
            }
            return View(database.Accomodation.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
               _registerRepository.Edit(accomodation);
                return View();
            }
            else
                return View(accomodation);
        }
    }
}