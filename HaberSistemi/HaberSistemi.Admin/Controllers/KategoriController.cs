using HaberSistemi.Admin.Class;
using HaberSistemi.Admin.CostumFilter;
using HaberSistemi.Core.InfraStructure;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    [LoginFilter]
    public class KategoriController : Controller
    {
        #region Kategori

        private readonly IKategoriRepository _kategoriRepository;

        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            return View(_kategoriRepository.GetAll().ToList());
        }
        public ActionResult Sil(int id)
        {
            Kategori dbkategori = _kategoriRepository.GetById(id);
            if (dbkategori==null)
            {
                throw new Exception("Kategori Bulanamadı");
            }
            _kategoriRepository.Delete(id);
            _kategoriRepository.Save();
            return RedirectToAction("Index","Kategori");
        }


        #region Kategori Ekle
        [HttpGet]
        public ActionResult Ekle()
        {
            SetKategoriListele();
            return View();
        }
        
        [HttpPost]
        public JsonResult Ekle(Kategori kategori)
        {
            try
            {
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori ekleme işlemi başarılı." });
            }
            catch (Exception)
            {

               return Json(new ResultJson { Success =false,Message="Kategori eklemede hata oluştu"});
            }
            
        }
        #endregion

        #region set KategoriList
        public void SetKategoriListele()
        {
            var KategoriList = _kategoriRepository.GetMany(x => x.ParentId == 0).ToList();

            ViewBag.Kategori = KategoriList;

        }
        #endregion
    }
}