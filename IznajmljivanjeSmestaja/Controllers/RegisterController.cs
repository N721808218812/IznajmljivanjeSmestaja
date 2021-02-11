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
        }//constructor

        public IActionResult Index()
        {
            return View();
        }//index

        public IActionResult ViewAll()
        {
            return View(_registerRepository.ViewAll());
        }//viewAll

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ViewAll");
            }
            return View(database.Accomodation.Where(a => a.Id == id).FirstOrDefault());
        }//edit

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
        }//edit

        public IActionResult Reserve()
        {
            return View();
        }//reserve

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve(Reservation reservation,int id)
        {
            if (ModelState.IsValid)
            {
                _registerRepository.Reserve(reservation,id);
                return View("Uspesno");
            }else
                return View(reservation);
        }//reserve

        public IActionResult ViewAllReservations()
        {
            return View(_registerRepository.ViewAllReservations());
        }//viewAllReservations


        public IActionResult GetByUserId(string id)
        {
            return View(_registerRepository.GetByUserId(id));
        }//getByUserId


        public IActionResult GetByAccomodation(int id)
        {
            return View(_registerRepository.GetByAccomodation(id));
        }//getByUserId

        public IActionResult CancelReservation(int id)
        {
            if (id == null)
            {
                return RedirectToAction("ViewAllReservations");
            }
            return View(_registerRepository.GetByReservationId(id));
        }//getByReservationId

        [HttpPost]
        public IActionResult CancelReservation(Reservation reservation)
        {
            try
            {
                _registerRepository.CancelReservation(reservation);
                 return RedirectToAction("ViewAllReservations");
            }
            catch
            {
                 return RedirectToAction("ViewAllreservations");
            }
        }//getByReservationId

        public IActionResult ViewPreviousReservations(string id)
        {
            return View(_registerRepository.GetByUserId(id));
        }//viewPreviousreservations prethodne rezervacije tog korisnika

        public IActionResult ViewReservations(int id)
        {
            return View(_registerRepository.GetByAccomodation(id));
        }//viewReservations ko je rezervisao taj smestaj
    }
}