function isValid(frm) {
    var adi = frm.adi.value;
    var soyadi = frm.soyadi.value;
    var kadi = frm.kadi.value;
    var sifre = frm.sifre.value;
    var sifretekrari = frm.sifretekrari.value;
    var email = frm.email.value;
    var atpos = email.indexOf("@");
    var dotpos = email.lastIndexOf(".");
    if (adi.length < 2) {
        document.getElementById("adikontrol").innerHTML = "Adınızı 2 karakter az olamaz";
        document.getElementById("adikontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("adikontrol").innerHTML = "Uygundur";
        document.getElementById("adikontrol").style.color = "green";
    }
    if (soyadi.length < 2) {
        document.getElementById("soyadikontrol").innerHTML = "Soyadınız 2 karakter az olamaz";
        document.getElementById("soyadikontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("soyadikontrol").innerHTML = "Uygundur";
        document.getElementById("soyadikontrol").style.color = "green";
    }
    if (kadi == null || kadi == "" || kadi.length < 4) {
        document.getElementById("kadikontrol").innerHTML = "Kullanıcı Adınız 4 karakter az olamaz";
        document.getElementById("kadikontrol").style.color = "red";

        return false;
    }
    else {
        document.getElementById("kadikontrol").innerHTML = "Uygundur";
        document.getElementById("kadikontrol").style.color = "green";
    }
    if (sifre == null || sifre == "" || sifretekrari == null || sifretekrari == "") {
        document.getElementById("sifrekontrol").innerHTML = "Lütfen Şifre giriniz";
        document.getElementById("sifrekontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("sifrekontrol").innerHTML = "Uygundur";
        document.getElementById("sifrekontrol").style.color = "green";
    }
    if (!(sifre == sifretekrari)) {

        document.getElementById("sifretekrarkontrol").innerHTML = "Şifreler uyuşmuyor";
        document.getElementById("sifretekrarkontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("sifretekrarkontrol").innerHTML = "Şifreler aynıdır";
        document.getElementById("sifretekrarkontrol").style.color = "green";
    }
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
        document.getElementById("emailkontrol").innerHTML = "Lütfen Uygun email adresi giriniz";
        document.getElementById("emailkontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("emailkontrol").innerHTML = "email uygundur";
        document.getElementById("emailkontrol").style.color = "green";
    }
    alert("Başarıyla Kayıt oldunz");
    return true;
};
function GirisKontrol() {
    if (document.Giris.kadi.value == "admin" && document.Giris.sifre.value == "1234") {
        window.location.href="Admin/Admin.html";
        alert("Admin Sayfasına Hoşgeldiniz")
    }
    else {
        alert("Kullanıcı adı ve şifre uyuşmuyor")
    }

};
function YorumKontrol(frm) {
    var adi = frm.adi.value;
    var soyadi = frm.soyadi.value;
    var email = frm.email.value;
    var mesaj = frm.mesaj.value;
    var atpos = email.indexOf("@");
    var dotpos = email.lastIndexOf(".");

    if (adi.length < 2) {
        document.getElementById("adikontrol").innerHTML = "Adınızı 2 karakter az olamaz";
        document.getElementById("adikontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("adikontrol").innerHTML = "Uygundur";
        document.getElementById("adikontrol").style.color = "green";
    }
    if (soyadi.length < 2) {
        document.getElementById("soyadikontrol").innerHTML = "Soyadınız 2 karakter az olamaz";
        document.getElementById("soyadikontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("soyadikontrol").innerHTML = "Uygundur";
        document.getElementById("soyadikontrol").style.color = "green";
    }
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
        document.getElementById("emailkontrol").innerHTML = "Lütfen Uygun email adresi giriniz";
        document.getElementById("emailkontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("emailkontrol").innerHTML = "email uygundur";
        document.getElementById("emailkontrol").style.color = "green";
    }
    if (mesaj.length < 10 || mesaj.length > 100) {
        document.getElementById("mesajkontrol").innerHTML = "Lütfen 10 ile 100 hece arası bilgi giriniz";
        document.getElementById("mesajkontrol").style.color = "red";
        return false;
    }
    else {
        document.getElementById("mesajkontrol").innerHTML = "Uygundur";
        document.getElementById("mesajkontrol").style.color = "green";
    }
    alert("Doğru girdiniz");
    return true;
};
