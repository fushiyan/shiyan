using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shiyan.Models;

namespace shiyan.Controllers
{
    public class Gallerie : Controller
    {
        private SMZEntities db = new SMZEntities();

        // GET: Galleries
        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        public ActionResult Photos()
        {
            using (SMZEntities db = new SMZEntities())
            {
                return View(db.Galleries.ToList());
            }
        }

        // GET: Galleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Galleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase ImagePath,string Title, string Description)
        {
            if (ImagePath != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);

                if ((img.Width != 800) || (img.Height != 533))
                {
                    ModelState.AddModelError("", "Image resolution must be 800x533 pixels");
                    return View("photos");
                }
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), pic);
                ImagePath.SaveAs(path);
                using (SMZEntities db = new SMZEntities())
                {

                    Gallery gallery = new Gallery { ImagePath = "~/Content/Images/" + pic,Title=Title,Description=Description};
                    db.Galleries.Add(gallery);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("photos");
        } 

        // GET: Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImagePath")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);

            string imgPath = Server.MapPath(gallery.ImagePath); 
            if (System.IO.File.Exists(imgPath))
            {
                System.IO.File.Delete(imgPath);
            } 
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("photos");
        }


        public ActionResult DeleteImages(IEnumerable<int> ImagesIds)
        {
            using (SMZEntities db = new Models.SMZEntities())
            {
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
