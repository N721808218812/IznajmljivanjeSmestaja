using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IznajmljivanjeSmestaja.Models;
using IznajmljivanjeSmestaja.Models.Interfaces;
using IznajmljivanjeSmestaja.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace IznajmljivanjeSmestaja.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //public BookingContext database = new BookingContext();
        public  BookingContext database { get; set; }
        
        private readonly AdminRepository _adminRepository = null;

        private readonly IHostingEnvironment _webHostEnvironment = null;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IHostingEnvironment webHostEnvironment)
        {
            _adminRepository = new AdminRepository();

          
            _webHostEnvironment = webHostEnvironment;

            database = new BookingContext();
          
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
            ViewBag.Users = _adminRepository.GetAllUsers();
            return View("AddAccomodation",model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccomodation(Accomodation accomodation)
        {
           
                if (accomodation.IdUser != null && accomodation.Title!=null && accomodation.Address!=null &&
                    accomodation.Description!=null && accomodation.Checkin!=null && accomodation.Checkout!=null)

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

                    int id = await _adminRepository.Add(accomodation);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(AddAccomodation), new { isSuccess = true, bookId = id });
                    }
                }
                else
                {
                    ViewBag.IsSuccess = false;
                    ViewBag.Users = _adminRepository.GetAllUsers();
                    return View("AddAccomodation",accomodation);
                }
            }
            else
            {
                ViewBag.IsSuccess = false;
                ViewBag.Users = _adminRepository.GetAllUsers();
                return View("AddAccomodation",accomodation);

            }
            ViewBag.Users = _adminRepository.GetAllUsers();
            return View("AddAccomodation",accomodation);



        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public ActionResult ViewAllAccomodation()
        {
            return View(_adminRepository.getAll());
        }



        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ViewAllAccomodation");
            }
            var getcategorydetails = await database.Accomodation.FindAsync(id);
            return View("Delete",getcategorydetails);
        }

        [HttpPost]

        public async Task<ActionResult> Delete(int id)
        {
            if (id != null)
            {
                //    var getAccomodationdetails = await database.Accomodation.FindAsync(id);
                //    var name = getAccomodationdetails.CoverPhotoUrl;
                //    if (name != null)
                //    {
                //        name = getAccomodationdetails.CoverPhotoUrl.Remove(0, 14);
                //    }

                //    var path = _webHostEnvironment.WebRootPath + "\\images\\cover\\" + name;

                //    /* var path = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\cover", name);
                //    FileInfo fi = new FileInfo(path);
                //    if (fi != null)
                //    {
                //        System.IO.File.Delete(path); fi.Delete();
                //    }


                //    List<AccomadationGallery> getAccomodationGallerydetails = database.AccomadationGallery.Where(x => x.IdAccomodation == id).ToList();

                //    foreach (var pom in getAccomodationGallerydetails)
                //    {
                //        if (pom != null)
                //        {
                //            var name2 = pom.Url.Remove(0, 15);
                //            /*  var path2 = Path.Combine(_webHostEnvironment.WebRootPath, "\\images\\gallery", name2);*/
                //            var path2 = _webHostEnvironment.WebRootPath + "\\images\\gallery\\" + name2;
                //            FileInfo fi2 = new FileInfo(path2);
                //            string p= "fi2";
                //        if (fi2 != null)
                //            {
                //                using (FileStream stream = new FileStream(p, FileMode.Open, FileAccess.Read))
                //                {

                //                    pictureBox1.Image = Image.FromStream(stream);
                //                    stream.Dispose();
                //                    System.IO.File.Delete(path2);
                //                 fi2.Delete(); }
                //            }
                //        }
                //    }


                int i = await _adminRepository.Delete(id);

            }
          
            return RedirectToAction("ViewAllAccomodation");

        }

        public ActionResult GetAllUsers()
        {
            return View(_adminRepository.GetAllUsers());
        }

        public ActionResult ViewAllStaggingAccomodation()
        {
            return View(_adminRepository.getAllStagging());
        }


        public async Task<ActionResult> Details(int id)
        {
            var data = await _adminRepository.DetailsAccomodation(id);

            return View(data);
        }

        public async Task<ActionResult> Edit(int id,bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = id;
            var data = await _adminRepository.DetailsAccomodation(id);
            

            return View("Edit", data);
         
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Accomodation accomodation)
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

                int id = await _adminRepository.Edit(accomodation);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Edit), new { isSuccess = true, bookId = id });
                }
            }


            return View("Edit");
        }

        public ActionResult Aprove(int id)
        {
            AccomodationStaging a = database.AccomodationStaging.Where(p => p.Id == id).FirstOrDefault();

            if (a != null)
            {
                _adminRepository.Aprove(a);
            }
            return RedirectToAction("ViewAllAccomodation",_adminRepository.getAll());
        }

        public ActionResult Choose()
        {
            return View("Choose",_adminRepository.getAll());
        }
    }
}