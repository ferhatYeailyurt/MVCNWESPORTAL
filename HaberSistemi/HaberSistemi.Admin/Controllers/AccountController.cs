using HaberSistemi.Admin.Class;
using HaberSistemi.Core.InfraStructure;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Kullanıcı
        private readonly IKullaniciRepository _kullaniciRepository;

        public AccountController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }
        #endregion



        
        [HttpGet]
        public ActionResult Login()
        {
            SetRolListele();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var KullaniciVarMi = _kullaniciRepository.GetMany(x => x.Email == kullanici.Email && x.Sifre == kullanici.Sifre && x.Aktif == true).SingleOrDefault();

            if (KullaniciVarMi!=null)
            {
                if (KullaniciVarMi.Rol.RolAdi=="Admin")
                {
                    Session["KullaniciEmail"] = KullaniciVarMi.Email;
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Mesaj="Yetkisiz Kullanıcı";
                return View();

            }

            ViewBag.Mesaj="Kullanıcı Bulanamadı";

            return View();
        }

     
        public JsonResult Ekle(Kullanici kullanici)
        {
            try
            {
                _kullaniciRepository.Insert(kullanici);
                _kullaniciRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori ekleme işlemi başarılı." });
            }
            catch (Exception)
            {

                return Json(new ResultJson { Success = false, Message = "Kayıt olmada hata oluştu." });
            }
        }


        public void SetRolListele()
        {
            var KullaniciList = _kullaniciRepository.GetMany(x => x.Id== 0).ToList();

            ViewBag.Kullanici = KullaniciList;

        }

    }
}