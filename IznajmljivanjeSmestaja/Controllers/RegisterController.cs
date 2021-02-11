using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IznajmljivanjeSmestaja.Models;
using IznajmljivanjeSmestaja.Models.Interfaces;
using IznajmljivanjeSmestaja.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IznajmljivanjeSmestaja.Controllers
{
    public class RegisterController : Controller
    {
        public BookingContext database = new BookingContext();
        private readonly IRegisterRepository _registerRepository = null;
        private readonly IHostingEnvironment _webHostEnvironment = null;
        public RegisterController(IHostingEnvironment webHostEnvironment)
        {
            _registerRepository = new RegisterRepository();
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<ViewResult> AddAccomodation(bool isSuccess = false, int bookId = 0)
        {
            var model = new AccomodationStaging();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }//addAccomodatioStaging

        [HttpPost]
        public async Task<IActionResult> AddAccomodation(AccomodationStaging accomodationStaging)
        {
            if (ModelState.IsValid)
            {
                if (accomodationStaging.CoverPhoto != null)
                {
                    string folder = "images/cover/";
                    accomodationStaging.CoverPhotoUrl = await UploadImage(folder, accomodationStaging.CoverPhoto);
                }

                if (accomodationStaging.GalleryFiles != null)
                {
                    string folder = "images/gallery/";

                    accomodationStaging.Gallery = new List<AccomadationGallery>();

                    foreach (var file in accomodationStaging.GalleryFiles)
                    {
                        var gallery = new AccomadationGallery()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file),


                        };
                        accomodationStaging.Gallery.Add(gallery);
                    }


                }

                int id = await _registerRepository.Create(accomodationStaging);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddAccomodation), new { isSuccess = true, bookId = id });
                }
            }


            return View();
        }//addAccomodation

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }//uploadImage

    }//class
}//namespace