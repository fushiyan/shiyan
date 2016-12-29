using shiyan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shiyan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
         
       


        public ActionResult DeleteImages() {
            using (SMZEntities db = new SMZEntities()) {
                return View(db.Galleries.ToList());
            }
        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImagesIds) { 
            using (SMZEntities db = new Models.SMZEntities()) {
                foreach (var id in ImagesIds)
                {
                   
                    var image = db.Galleries.Single(s => s.Id == 4);
                    string imgPath = Server.MapPath(image.ImagePath);
                    db.Galleries.Remove(image);
                    if (System.IO.File.Exists(imgPath))
                      {
                        System.IO.File.Delete(imgPath);
                    } 
                }
                db.SaveChanges(); 
            }
            return RedirectToAction("DeleteImages");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}