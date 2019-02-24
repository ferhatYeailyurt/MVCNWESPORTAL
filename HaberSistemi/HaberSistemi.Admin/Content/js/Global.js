function KategoriEkle() {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    Kategori.URL = $("#KategoriUrl").val();
    Kategori.AktifMi = $("#KategoriAktif").is(":checked");
    Kategori.ParentId = $("#ParentId").val();
    alert(Kategori.ParentId);
   

    $.ajax({
        url: "/Kategori/Ekle",
        data: Kategori,
        type: "POST",
        dataType:'json',
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                //geri dönüş değeri isteyeceğmiz zaman bunu kullanırız.
                });
            }
        }
    })



    
}


function KullaniciEkle() {
    Kullanici = new Object();
    Kullanici.AdSoyad = $("#AdSoyad").val();
    Kullanici.Email = $("#Email").val();
    Kullanici.Sifre = $("#Sifre").val();
    Kullanici.Rol_Id = 1;
    Kullanici.KayitTarihi = new Date(1923,10,10)
    Kullanici.AktifMi = $("#AktifMi").is(":checked");
    alert(Kullanici.AdSoyad);

    $.ajax({
        url: "/Account/Ekle",
        data: Kullanici,
        type: "POST",
        dataType: 'json',
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //geri dönüş değeri isteyeceğmiz zaman bunu kullanırız.
                });
            }
        }
    })




}