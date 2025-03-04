using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbEntities db = new MvcDbEntities(); 
        public ActionResult Index()
        { var deger=db.TblMusterilers.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        { return View(); }  
        
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteriler p1)
        {
            if (!ModelState.IsValid)
            { return View("YeniMusteri"); }
            db.TblMusterilers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var urune = db.TblMusterilers.Find(id);
            db.TblMusterilers.Remove(urune);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var mst= db.TblMusterilers.Find(id);
            return View("MusteriGetir", mst);

         
        }
        public ActionResult Guncelle(TblMusteriler p1)
        {
            var mus = db.TblMusterilers.Find(p1.musteriıd);
            mus.musteriad = p1.musteriad;
            mus.musterisoyad = p1.musterisoyad; 
            db.SaveChanges();   
            return RedirectToAction("Index");   

            //var ktg = db.TblKategoris.Find(p1.kategoriıd);
            //ktg.kategoriad = p1.kategoriad;
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

    }
}