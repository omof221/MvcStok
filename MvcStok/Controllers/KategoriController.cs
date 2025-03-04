
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity; // entity tanımlaması gerçekleştirildi bu kısımda
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Default
        MvcDbEntities db=new MvcDbEntities(); // entity den nesen üretilide class a erişebilmek için
        public ActionResult Index(int sayfa=1)
        {      //var degerler=db.TblKategoris.ToList();// nesne içindeki veriler listelenddi bu kısımda
            var degerler = db.TblKategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
            { return View(); }  
        [HttpPost]
        public ActionResult YeniKategori(TblKategori p1)
        { //boş kategori eklendiğinde validation mesajı döndürüp aynı sayfaya yönlendirme
            if(!ModelState.IsValid)
                { return View("YeniKategori"); }
            
            db.TblKategoris.Add(p1);
           db.SaveChanges();
            return RedirectToAction("Index");   
        }
        // sil kısmına cshtml kısmından 
         public ActionResult Sil(int id)   
            { var kategori= db.TblKategoris.Find(id);
             db.TblKategoris.Remove(kategori);
            db.SaveChanges();   
            return RedirectToAction("Index");
        
        }
        // sayfalar arasında veri taşıma
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategoris.Find(id);
                return View("KategoriGetir",ktgr);
                }
        public ActionResult Guncelle(TblKategori p1)
        {
            var ktg = db.TblKategoris.Find(p1.kategoriıd);
            ktg.kategoriad=p1.kategoriad;
            db.SaveChanges();   
            return RedirectToAction("Index");   

        
        
        }


    }
}