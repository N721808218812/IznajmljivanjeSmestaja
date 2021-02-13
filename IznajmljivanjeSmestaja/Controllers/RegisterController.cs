﻿using System;
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

        public async Task<ActionResult> Edit(int id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = id;
            var data = await _registerRepository.DetailsAccomodation(id);

            return View(data);
        }//edit

        [HttpPost]
        public async Task<ActionResult> Edit(Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {

                if (accomodation.CoverPhoto != null)
                {
                    string folder = "images/cover/";
                    accomodation.CoverPhotoUrl = await UploadImage(folder, accomodation.CoverPhoto);
                }

                if (accomodation.GalleryFiles != null)
                {
                    string folder = "images/gallery/";

                    accomodation.Gallery = new List<AccomadationGallery>();

                    foreach (var file in accomodation.GalleryFiles)
                    {
                        var gallery = new AccomadationGallery()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file),


                        };
                        accomodation.Gallery.Add(gallery);
                    }


                }

                int id = await _registerRepository.Edit(accomodation);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Edit), new { isSuccess = true, bookId = id });
                }
            }


            return View();
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

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ViewAll");
            }
            var getcategorydetails = await database.Accomodation.FindAsync(id);
            return View(getcategorydetails);
        }//delete

        [HttpPost]

        public async Task<ActionResult> Delete(int id)
        {
            if (id != null)
            {
                var getAccomodationdetails = await database.Accomodation.FindAsync(id);
                var name = getAccomodationdetails.CoverPhotoUrl;
                if (name != null)
                {
                    name = getAccomodationdetails.CoverPhotoUrl.Remove(0, 14);
                }

                var path = _webHostEnvironment.WebRootPath + "\\images\\cover\\" + name;

                /* var path = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\cover", name);*/
                FileInfo fi = new FileInfo(path);
                if (fi != null)
                {
                    System.IO.File.Delete(path); fi.Delete();
                }


                List<AccomadationGallery> getAccomodationGallerydetails = database.AccomadationGallery.Where(x => x.IdAccomodation == id).ToList();

                foreach (var pom in getAccomodationGallerydetails)
                {
                    if (pom != null)
                    {
                        var name2 = pom.Url.Remove(0, 15);
                        /*  var path2 = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\gallery", name2);*/
                        var path2 = _webHostEnvironment.WebRootPath + "\\images\\gallery\\" + name2;
                        FileInfo fi2 = new FileInfo(path2);
                        if (fi2 != null)
                        {
                            System.IO.File.Delete(path2); fi2.Delete();
                        }
                    }
                }


                int i = await _registerRepository.Delete(id);

            }

            return RedirectToAction("ViewAll");

        }

    }//class
}//namespace