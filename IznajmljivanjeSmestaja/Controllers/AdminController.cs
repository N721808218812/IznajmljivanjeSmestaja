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
    public class AdminController : Controller
    {
        public BookingContext database = new BookingContext();
        private readonly IAdminRepository _adminRepository = null;

        private readonly IHostingEnvironment _webHostEnvironment = null;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IHostingEnvironment webHostEnvironment)
        {
            _adminRepository = new AdminRepository();

            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ViewResult> AddAccomodation(bool isSuccess = false, int bookId = 0)
        {
            var model = new Accomodation();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccomodation(Accomodation accomodation)
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



                    int id = await _adminRepository.Add(accomodation);
                    
                    
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}