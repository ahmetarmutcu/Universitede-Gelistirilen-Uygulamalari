var i = 0;
var app = angular
    .module("uyeModul", [])
    .controller("uyeController", function ($scope) {

        var uyeler = [
            { uyeadi: "Ahmet", uyesoyadi: "Armutcu",kullaniciadi:"ahmet1234",sifre:"123456",email:"ahmetarmutcuogr@sakarya.edu.tr"},
            { uyeadi: "Mehmet", uyesoyadi: "Durmaz",kullaniciadi:"kmehmet12",sifre:"2456666",email:"mehmet@sakarya.edu.tr" },
            { uyeadi: "Fatma", uyesoyadi: "Kığılı ",kullaniciadi:"KıgılıFatma",sifre:"5678910",email:"kıgılı@hotmail.com" }
        ];

        $scope.uyeler = uyeler;
        $scope.sutunSirala = "uyeadi";
        $scope.cevir = false;

        $scope.veriSirala = function (sutun) {
            $scope.cevir = ($scope.sutunSirala == sutun) ? !$scope.cevir : false;
            $scope.sutunSirala = sutun;
        }

        $scope.siralaClass = function (sutun) {

            if ($scope.sutunSirala == sutun) {
                return $scope.cevir ? 'azalan' : 'artan';
            }
            return '';
        }
    });

var i = 0;
var app = angular
    .module("haberModul", [])
    .controller("haberController", function ($scope) {

        var haberler = [
            { haberAdi: "Portekiz ‘evden’ 2.9 € milyar kazandı", icerik: "İspanya'nın kuzeyi ve Fransa'nın güneyinde bağımsız devlet kurmak için silahlı mücadele yürüten Bask Yurdu ve Özgürlük (ETA) örgütü, bu süreçte çatışma tarafı olmadıkları halde zarar görenlerden af diledi.", tarih: new Date(2018, 3, 20) },
            { haberAdi: "Portekiz Dünya kupasına katılıyor", icerik: "Portekiz takımı hakkında bilgi almak için", tarih: new Date(2018, 4, 18) },
            { haberAdi: "FIFA'dan Benfica ve Sporting Lizbon'a Para Cezası", icerik: "Dünya futbolunun patronu FIFA, Portekiz'in dev ekipleri Benfica ve Sporting Lizbon'da usulsüz transfer yapıldığı gerekçesiyle ceza verdi.\nFIFA'dan yapılan açıklamada Benfica'ya 132 bin euro, Sporting Lizbon'a ise 92 bin euro para cezası verildiği duyuruldu. ", tarih: new Date(2018, 3, 12) }
        ];

        $scope.haberler = haberler;
        $scope.sutunSirala = "haberAdi";
        $scope.cevir = false;

        $scope.veriSirala = function (sutun) {
            $scope.cevir = ($scope.sutunSirala == sutun) ? !$scope.cevir : false;
            $scope.sutunSirala = sutun;
        }

        $scope.siralaClass = function (sutun) {

            if ($scope.sutunSirala == sutun) {
                return $scope.cevir ? 'azalan' : 'artan';
            }
            return '';
        }
    });
   
var i = 0;
var app = angular
    .module("duyuruModul", [])
    .controller("duyuruController", function ($scope) {

        var duyurular = [
            { DuyuruAdi: "Site Çok güzel olmuş", icerik: "Site hakkında yorum yapıcak lütfen yorum sayfasına girsinler", tarih: new Date(2018, 4, 18) },
            { DuyuruAdi: "Şehirler Siteye Eklendi", icerik: "Şehir hakkında bilgi almak için lütfen tıklayınız", tarih: new Date(2018, 4, 18) },
            { DuyuruAdi: "Portekiz ‘evden’ 2.9 € milyar kazandı", icerik: "Portekiz vandaşlık programı sayesinde 2012'den beri 2.9 milyar euro değerinde gayrimenkul yatırım aldı.2012'de yasal ", tarih: new Date(2018, 4, 18) }
        ];

        $scope.duyurular = duyurular;
        $scope.sutunSirala = "DuyuruAdi";
        $scope.cevir = false;

        $scope.veriSirala = function (sutun) {
            $scope.cevir = ($scope.sutunSirala == sutun) ? !$scope.cevir : false;
            $scope.sutunSirala = sutun;
        }

        $scope.siralaClass = function (sutun) {

            if ($scope.sutunSirala == sutun) {
                return $scope.cevir ? 'azalan' : 'artan';
            }
            return '';
        }
    });
    var o = {
        "haberler": [
            { "haberadı": "Portekiz ‘evden’ 2.9 € milyar kazandı", "habericerik": "Portekiz vandaşlık programı sayesinde 2012'den beri 2.9 milyar euro değerinde gayrimenkul yatırım aldı.2012'de yasal", "tarih": "18/4/2018" },
            { "haberadı": "Portekiz Dünya kupasına katılıyor", "habericerik": "Portekiz takımı hakkında bilgi almak için", "tarih": "18/4/2018" },
            { "haberadı": "Portekiz ‘evden’ 2.9 € milyar kazandı", "habericerik": "Portekiz vandaşlık programı sayesinde 2012'den beri 2.9 milyar euro değerinde gayrimenkul yatırım aldı.2012'de yasal", "tarih": "18/12/2018" },
    
        ],
        "Duyurular": [
            { "Duyurubaslik": "Site Çok güzel olmuş", "DuyuruBilgi": "Site hakkında yorum yapıcak lütfen yorum sayfasına girsinler", "tarih": "15/12/2018" },
            { "Duyurubaslik": "Şehirler Siteye Eklendi", "DuyuruBilgi": "Şehir hakkında bilgi almak için lütfen tıklayınız", "tarih": "18/01/2018" },
            { "Duyurubaslik": "Portekiz ‘evden’ 2.9 € milyar kazandı", "DuyuruBilgi": "Portekiz vandaşlık programı sayesinde 2012'den beri 2.9 milyar euro değerinde gayrimenkul yatırım aldı.2012'de yasal", "tarih": "18/12/2018" },
    
        ]
    
    };
    window.onload = function () {
        var mevcut = o.haberler.length;
        var duyurumevcut = o.Duyurular.length;
        var habera = "";
        var haberi = "";
        var habert = "";
        var duyuru_baslik = "";
        var duyuru_bilgi = "";
        var duyuru_tarih = "";
        for (var i = 0; i < mevcut; i++) {
            var haber = o.haberler[i];
    
            habera = haber.haberadı + '<br>';
            haberi = haber.habericerik + '<br>';
            habert = haber.tarih + '<br>';
            document.getElementById("haberi").innerHTML += habera.fontsize(2).fontcolor("red").bold().toUpperCase() + "" + haberi.fontcolor("gray") + " " + habert.fontcolor("orange").fixed();
    
        }
        for (var i = 0; i < duyurumevcut; i++) {
            var duyuru = o.Duyurular[i];
            duyuru_baslik = duyuru.Duyurubaslik + '<br>';
            duyuru_bilgi = duyuru.DuyuruBilgi + '<br>';
            duyuru_tarih = duyuru.tarih + '<br>';
            document.getElementById("duyurular").innerHTML += duyuru_baslik.fontsize(2).fontcolor("red").toUpperCase().bold()+ "" + duyuru_bilgi.fontcolor("gray") + " " + duyuru_tarih.fontcolor("orange").fixed();
        }
    };  
    
    