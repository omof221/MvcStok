using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbEntities db = new MvcDbEntities();
        public ActionResult Index()
        {   var deg=db.TblUrunlers.ToList();
            return View(deg);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        { // dropdown list ile kategorileri veritabınından çekerek kullanma
            List<SelectListItem> degerler =(from i in db.TblKategoris.ToList()
                                            select new SelectListItem
                                            { Text = i.kategoriad,
                                              Value = i.kategoriıd.ToString()
                                            }).ToList();



            ViewBag.dgr=degerler;   
            return View();
        
        }
        [HttpPost]
        public ActionResult UrunEkle(TblUrunler p1)
        { 
            var ktg = db.TblKategoris.Where(m => m.kategoriıd == p1.TblKategori.kategoriıd).FirstOrDefault();
            p1.TblKategori = ktg;   
            
            
            
            
            db.TblUrunlers.Add(p1);
         db.SaveChanges();
            return RedirectToAction("Index");   
        
        }


        public ActionResult Sil(int id)
        {
            var urun = db.TblUrunlers.Find(id);
           db.TblUrunlers.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int? id)
        {
            var urun = db.TblUrunlers.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriıd.ToString()
                                             }).ToList();



            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        
        }   
        public ActionResult Guncelle(TblUrunler p)
        {
            var urun = db.TblUrunlers.Find(p.urunıd);
            urun.urunad=p.urunad;   
            urun.marka = p.marka;
            urun.stok = p.stok;
            urun.fiyat = p.fiyat;
            // kategori bu şekilde güncelleme işlemine tabi tutulmaz çünkü veriler dropdown list içerisinden çekilirwwqsaawqsa
            // urun.urunkategori = p.urunkategori;
            var ktg = db.TblKategoris.Where(m => m.kategoriıd == p.TblKategori.kategoriıd).FirstOrDefault();
            urun.TblKategori = ktg;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }




    }
}