//##### RECEIVER ŞEHİR ÇEKME #####//
var receiverCity;
var receiverDistrict;
var receiverNeighborhood;
var selectedReceiverCityID = 0;
var selectedReceiverDistrictID = 0;

$(document).ready(function () {
    // Gönderi alacak şehirlerin yüklenmesi ve seçim değiştiğinde ilçelerin yüklenmesi
    $.ajax({
        url: '/Admin/GetCities',
        method: 'GET',
        dataType: 'json',
        success: function (cities) {
            receiverCity = $('#receiverCity');
            receiverCity.empty();
            receiverCity.append('<option selected disabled hidden value="">Alıcı Şehri...</option>');

            $.each(cities, function (index, city) {
                receiverCity.append('<option value="' + city.SehirId + '">' + city.SehirAdi + '</option>');
            });
        },
        error: function (error) {
            console.error('Alıcı şehirler çekilirken hata oluştu:', error);
        }
    });
});

// Alıcı ilçelerin yüklenmesi (Şehir seçildiğinde çalışacak)
$(document).on('change', '#receiverCity', function () {
    selectedReceiverCityID = $(this).val();
    $.ajax({
        url: '/Admin/GetDistricts',
        method: 'GET',
        data: { SehirId: selectedReceiverCityID },
        dataType: 'json',
        success: function (districts) {
            receiverDistrict = $('#receiverDistrict');
            receiverDistrict.empty();
            receiverDistrict.append('<option selected disabled hidden value="">Alıcı İlçesi...</option>');

            $.each(districts, function (index, district) {
                receiverDistrict.append('<option value="' + district.ilceId + '">' + district.IlceAdi + '</option>');
            });

            // Alıcı ilçe değiştiğinde mahalle seçimini sıfırla
            receiverNeighborhood = $('#receiverNeighborhood');
            receiverNeighborhood.empty();
            receiverNeighborhood.append('<option selected disabled hidden value="">Alıcı Mahallesi...</option>');
        },
        error: function (error) {
            console.error('Alıcı ilçeler çekilirken hata oluştu:', error);
        }
    });
});

// Alıcı mahallelerin yüklenmesi (İlçe seçildiğinde çalışacak)
$(document).on('change', '#receiverDistrict', function () {
    selectedReceiverDistrictID = $(this).val();
    $.ajax({
        url: '/Admin/GetNeighbors',
        method: 'GET',
        data: { ilceId: selectedReceiverDistrictID },
        dataType: 'json',
        success: function (neighbors) {
            receiverNeighborhood = $('#receiverNeighborhood');
            receiverNeighborhood.empty();
            receiverNeighborhood.append('<option selected disabled hidden value="">Alıcı Mahallesi...</option>');

            $.each(neighbors, function (index, neighbor) {
                receiverNeighborhood.append('<option value="' + neighbor.SemtMahId + '">' + neighbor.MahalleAdi + '</option>');
            });
        },
        error: function (error) {
            console.error('Alıcı mahalleler çekilirken hata oluştu:', error);
        }
    });
});

//##### RECEIVER ŞEHİR ÇEKME SONU #####//

//##### SENDER ŞEHİR ÇEKME #####//

var senderrCity;
var senderDistrict;
var senderNeighborhood;
var selectedCityID = 0;
var selectedDistrictID = 0;

$(document).ready(function () {
    // Şehirlerin yüklenmesi ve seçim değiştiğinde ilçelerin yüklenmesi
    $.ajax({
        url: '/Admin/GetCities',
        method: 'GET',
        dataType: 'json',
        success: function (cities) {
            senderrCity = $('#senderCity');
            senderrCity.empty();
            senderrCity.append('<option selected disabled hidden value="">Gönderici Şehri...</option>');

            $.each(cities, function (index, city) {
                senderrCity.append('<option value="' + city.SehirId + '">' + city.SehirAdi + '</option>');
            });
        },
        error: function (error) {
            console.error('Şehirler çekilirken hata oluştu:', error);
        }
    });
});

// İlçelerin yüklenmesi (Şehir seçildiğinde çalışacak)
$(document).on('change', '#senderCity', function () {
    selectedCityID = $(this).val();
    $.ajax({
        url: '/Admin/GetDistricts',
        method: 'GET',
        data: { SehirId: selectedCityID },
        dataType: 'json',
        success: function (districts) {
            senderDistrict = $('#senderDistrict');
            senderDistrict.empty();
            senderDistrict.append('<option selected disabled hidden value="">Gönderici İlçesi...</option>');

            $.each(districts, function (index, district) {
                senderDistrict.append('<option value="' + district.ilceId + '">' + district.IlceAdi + '</option>');
            });

            // İlçe değiştiğinde mahalle seçimini sıfırla
            senderNeighborhood = $('#senderNeighborhood');
            senderNeighborhood.empty();
            senderNeighborhood.append('<option selected disabled hidden value="">Gönderici Mahallesi...</option>');
        },
        error: function (error) {
            console.error('İlçeler çekilirken hata oluştu:', error);
        }
    });
});

// Mahallelerin yüklenmesi (İlçe seçildiğinde çalışacak)
$(document).on('change', '#senderDistrict', function () {
    selectedDistrictID = $(this).val();
    $.ajax({
        url: '/Admin/GetNeighbors',
        method: 'GET',
        data: { ilceId: selectedDistrictID },
        dataType: 'json',
        success: function (neighbors) {
            senderNeighborhood = $('#senderNeighborhood');
            senderNeighborhood.empty();
            senderNeighborhood.append('<option selected disabled hidden value="">Gönderici Mahallesi...</option>');

            $.each(neighbors, function (index, neighbor) {
                senderNeighborhood.append('<option value="' + neighbor.SemtMahId + '">' + neighbor.MahalleAdi + '</option>');
            });
        },
        error: function (error) {
            console.error('Mahalleler çekilirken hata oluştu:', error);
        }
    });
});

//##### SENDER ŞEHİR ÇEKME SONU #####//


var cargoWidthInput = document.getElementById("cargoWidth");
var cargoSizeInput = document.getElementById("cargoSize");
var cargoHeightInput = document.getElementById("cargoHeight");

function desiCalculate() {
    var cargoWidth = document.getElementById("cargoWidth").value;
    var cargoSize = document.getElementById("cargoSize").value;
    var cargoHeight = document.getElementById("cargoHeight").value;
    var cargoDesi = document.getElementById("desiBox");
    var cargoUcret = document.getElementById("priceBox");

    var desi = (parseInt(cargoWidth) * parseInt(cargoHeight) * parseInt(cargoSize)) / 3000;

    cargoDesi.value = "Desi : " + desi;

    if (desi <= 10) { cargoUcret.value = "Ücret :  52, 49 ₺"; }
    else if (desi > 10 && desi <= 20) { cargoUcret.value = "Ücret : 90, 99 ₺"; }
    else if (desi > 20 && desi <= 30) { cargoUcret.value = "Ücret : 137,79 ₺"; }
    else if (desi > 30 && desi <= 40) { cargoUcret.value = "Ücret : 176,66 ₺"; }
    else if (desi > 40 && desi <= 50) { cargoUcret.value = "Ücret : 204,55 ₺"; }
    else if (desi > 50 && desi <= 60) { cargoUcret.value = "Ücret : 241,12 ₺"; }
    else if (desi > 60 && desi <= 70) { cargoUcret.value = "Ücret : 277,45 ₺"; }
    else if (desi > 70 && desi <= 80) { cargoUcret.value = "Ücret : 313,90 ₺"; }
    else if (desi > 80 && desi <= 90) { cargoUcret.value = "Ücret : 350,35 ₺"; }
    else if (desi > 90 && desi <= 100) { cargoUcret.value = "Ücret : 386,80 ₺"; }
    else if (desi > 100) { cargoUcret.value = "Ücret : 400,00 ₺"; }
}

cargoWidthInput.addEventListener('input', desiCalculate);
cargoSizeInput.addEventListener('input', desiCalculate);
cargoHeightInput.addEventListener('input', desiCalculate);

function validateAndSave() {
    var form = document.getElementById("createOrderForm");
    if (form.checkValidity()) {
        // Required doğrulaması başarılı, saveData() fonksiyonunu çağırabiliriz
        saveData();
        // Modalı kapat
        $('#Modal').modal('hide');
    } else {
        // Required doğrulaması başarısız, formu gönderme ve saveData() fonksiyonunu çağırma
        form.reportValidity();
    }
}

function validateInput(input)
{
    var regex = /[^a-zA-ZğüşıöçĞÜŞİÖÇ\s]/g;
    input.value = input.value.replace(regex, "");
}

//Alıcı gönderici tc ve vergi no karşılaştırma başlangıç

var senderTCData = document.getElementById("senderTC");
var receiverTCData = document.getElementById("receiverTC");

receiverTCData.addEventListener("input", function ()
{
    var senderTCDataValue = senderTCData.value;
    var receiverTCDataValue = receiverTCData.value;

    var isValid = /^[0-9]{11}$/.test(receiverTCDataValue);
    if (!isValid)
    {
        this.setCustomValidity("Lütfen Geçerli Bir TC Kimlik No Giriniz !");
    }
    else
    {
        this.setCustomValidity("");
    }

    if (senderTCDataValue === receiverTCDataValue && senderTCDataValue !== "" && receiverTCDataValue!== "")
    {
        receiverTCData.value = receiverTCDataValue.substring(0, receiverTCDataValue.length - 1);
        alert("Gönderici ve alıcı TC kimlik numaraları aynı olmaz !")
    }
});

senderTCData.addEventListener("input", function () {
    var senderTCDataValue = senderTCData.value;
    var receiverTCDataValue = receiverTCData.value;

 var   isValid = /^[0-9]{11}$/.test(senderTCDataValue);

    if (!isValid)
    {
        senderTCData.setCustomValidity("Lütfen Geçerli Bir TC Kimlik No Giriniz !");
    }
    else
    {
        senderTCData.setCustomValidity("");
    }

    if (senderTCDataValue === receiverTCDataValue && senderTCDataValue !== "" && receiverTCDataValue!=="") {
        senderTCData.value = senderTCDataValue.substring(0, senderTCDataValue.length - 1);
        alert("Gönderici ve alıcı TC kimlik numaraları aynı olmaz !")
    }
});

//Alıcı gönderici tc ve vergi no karşılaştırma sonu

//Telefonlar İnput sadece Numeric Başlangıç

var senderPhoneData = document.getElementById("senderPhone");
var receiverPhoneData = document.getElementById("receiverPhone");

senderPhoneData.addEventListener("input", function()
{
    var senderPhoneDataValue = senderPhoneData.value;

    var isValid = /^[0-9]{11}$/.test(senderPhoneDataValue);
    if (!isValid)
    {
        senderPhoneData.setCustomValidity("Lütfen Geçerli Bir Telefon No Giriniz !");
    }

    else
    {
        senderPhoneData.setCustomValidity("");
    }
});

receiverPhoneData.addEventListener ("input", function () {
    var receiverPhoneDataValue = receiverPhoneData.value;

    var isValid = /^[0-9]{11}$/.test(receiverPhoneDataValue);
    if (!isValid) {
        receiverPhoneData.setCustomValidity("Lütfen Geçerli Bir Telefon No Giriniz !");
    }

    else {
        receiverPhoneData.setCustomValidity("");
    }
});


//Telefonlar İnput sadece Numeric Sonu

//Kargo Bilgileri İnput Kontrol Başlangıç

var cargoWidthData = document.getElementById("cargoWidth");
var cargoHeightData = document.getElementById("cargoHeight");
var cargoSizeData = document.getElementById("cargoSize");
var cargoWeightData = document.getElementById("cargoWeight");

cargoWidthData.addEventListener("input", function ()
{
    cargoWidthDataValue = cargoWidthData.value;

    var isValid = /^[0-9]{1,3}$/.test(cargoWidthDataValue);

    if (!isValid)
    {
        cargoWidthData.setCustomValidity("Lütfen Geçerli Bir Değer Giriniz !");
    }

    else
    {
        cargoWidthData.setCustomValidity("");
    }
});

cargoHeightData.addEventListener("input", function () {
    cargoHeightDataValue = cargoHeightData.value;

    var isValid = /^[0-9]{1,3}$/.test(cargoHeightDataValue);

    if (!isValid) {
        cargoHeightData.setCustomValidity("Lütfen Geçerli Bir Değer Giriniz !");
    }

    else {
        cargoHeightData.setCustomValidity("");
    }
});

cargoSizeData.addEventListener("input", function () {
    cargoSizeDataValue = cargoSizeData.value;

    var isValid = /^[0-9]{1,3}$/.test(cargoSizeDataValue);

    if (!isValid) {
        cargoSizeData.setCustomValidity("Lütfen Geçerli Bir Değer Giriniz !");
    }

    else {
        cargoSizeData.setCustomValidity("");
    }
});

cargoWeightData.addEventListener("input", function () {
    cargoWeightDataValue = cargoWeightData.value;

    var isValid = /^[0-9]{1,3}$/.test(cargoWeightDataValue);

    if (!isValid) {
        cargoWeightData.setCustomValidity("Lütfen Geçerli Bir Değer Giriniz !");
    }

    else {
        cargoWeightData.setCustomValidity("");
    }
});


//Kargo Bilgileri İnput Kontrol Sonu


// Radio Butonları Bireysel Ve Kurumsal Seçtiğinde Olacaklar (2.Sütun) Başlangıç

var receiverTC = document.getElementById("receiverTC");
var receiverPhone = document.getElementById("receiverPhone");
var receiverName = document.getElementById("receiverName");
var receiverSurname = document.getElementById("receiverSurname");
var receiverCity = document.getElementById("receiverCity");
var receiverDistrict = document.getElementById("receiverDistrict");
var receiverAdress = document.getElementById("receiverAdress");
var receiverNeighborhood = document.getElementById("receiverNeighborhood");

var receiveroption1 = document.getElementById("receiverradio1");
var receiveroption2 = document.getElementById("receiverradio2");
var option1 = document.getElementById("radio1");
var option2 = document.getElementById("radio2");

var senderTC = document.getElementById("senderTC");
var senderPhone = document.getElementById("senderPhone");
var senderName = document.getElementById("senderName");
var senderSurname = document.getElementById("senderSurname");
var senderCity = document.getElementById("senderCity");
var senderDistrict = document.getElementById("senderDistrict");
var senderAdress = document.getElementById("senderAdress");
var senderNeighborhood = document.getElementById("senderNeighborhood");

var senderNameDiv = document.getElementById("senderNameDiv");
var senderSurnameDiv = document.getElementById("senderSurnameDiv");
var receiverNameDiv = document.getElementById("receiverNameDiv");
var receiverSurnameDiv = document.getElementById("receiverSurnameDiv");


// Radio Butonları Bireysel Ve Kurumsal Seçtiğinde Olacaklar (1.Sütun) Başlangıç

option1.addEventListener("change", function ()
{
    if (this.checked)
    {
        senderSurnameDiv.classList.remove("d-none");
        senderSurnameDiv.classList.remove("col-md-0");
        senderNameDiv.classList.remove("col-md-12");
        senderName.placeholder = 'Gönderi Adı...';
        senderPhone.placeholder = 'Gönderici Telefonu...';
        senderTC.placeholder = "*Gönderici TC'si...";
        senderTC.value = "";
        senderPhone.value = "";
        senderName.value = "";
        senderSurname.value = "";
        senderAdress.value = "";


        senderSurname.setAttribute("required", "true");
    }
});

option2.addEventListener("change", function () {
    if (this.checked) {

        senderSurnameDiv.classList.add("d-none");
        senderSurnameDiv.classList.add("col-md-0");
        senderNameDiv.classList.add("col-md-12");
        senderName.placeholder = 'Şirket Adı...';
        senderTC.placeholder = "*Şirket Vergi No'su...";
        senderPhone.placeholder = 'Şirket Telefonu...';
        senderTC.value = "";
        senderPhone.value = "";
        senderName.value = "";
        senderSurname.value = "";
        senderAdress.value = "";

        senderSurname.removeAttribute("required");
    }
});

// Radio Butonları Bireysel Ve Kurumsal Seçtiğinde Olacaklar (1.Sütun) Sonu

receiveroption1.addEventListener("change", function() 
{
    if (this.checked) {
        //document.getElementById("receiverbireyselKisi").classList.remove("d-none");

       
        receiverSurnameDiv.classList.remove("d-none");
        receiverSurnameDiv.classList.remove("col-md-0");
        receiverNameDiv.classList.remove("col-md-12");
        receiverName.placeholder = 'Gönderi Adı...';
        receiverPhone.placeholder = 'Gönderici Telefonu...';
        receiverTC.placeholder = "*Gönderici TC'si...";
        receiverTC.value = "";
        receiverPhone.value = "";
        receiverName.value = "";
        receiverSurname.value = "";
        receiverAdress.value = "";


        receiverSurname.setAttribute("required", "true");
    }
});

receiveroption2.addEventListener("change", function() 
{
    if (this.checked)
    {
        receiverSurnameDiv.classList.add("d-none");
        receiverSurnameDiv.classList.add("col-md-0");
        receiverNameDiv.classList.add("col-md-12");
        receiverName.placeholder = 'Şirket Adı...';
        receiverTC.placeholder = "*Şirket Vergi No'su...";
        receiverPhone.placeholder = 'Şirket Telefonu...';
        receiverTC.value = "";
        receiverPhone.value = "";
        receiverName.value = "";
        receiverSurname.value = "";
        receiverAdress.value = "";

        receiverSurname.removeAttribute("required")
    }
});

// Radio Butonları Bireysel Ve Kurumsal Seçtiğinde Olacaklar (2.Sütun) Sonu



//Navbarda Butonlara Basıldığındaki Efekt ve Aynı Sayfa İçinde Sayfa Bölme Başlangıç

var css1 = `
  .navbar-section1 {
    background-color: #fff;
    border-top-right-radius: 25px;
    border-top-left-radius: 25px;
    z-index: 1;
  }
`;

var css2 = `
  .navbar-section2 {
    background-color: #fff;
    border-top-right-radius: 25px;
    border-top-left-radius: 25px;
    z-index: 1;
  }
`;

var css3 = `
  .navbar-section3 {
    background-color: #fff;
    border-top-right-radius: 25px;
    border-top-left-radius: 25px;
    z-index: 1;
  }
`;

window.onload = function() 
{
  // Tüm sayfaların görünürlüğünü kapat
  var pages = document.getElementsByClassName("container")[0].children;
  for (var i = 0; i < pages.length; i++) {
    pages[i].style.display = "none";
  }

  // Tüm stil öğelerini kaldır
  var existingStyles = document.querySelectorAll('style');
  for (var j = 0; j < existingStyles.length; j++) {
    existingStyles[j].parentNode.removeChild(existingStyles[j]);
  }

  // İkinci butonun sayfasını aç ve stil uygula
  var pageId = "page2";
  var page = document.getElementById(pageId);
  page.style.display = "block";
  var styleElement = document.createElement('style');
  styleElement.innerHTML = css2;
  document.head.appendChild(styleElement);
}

function openPage(pageId) 
{
  // Tüm sayfaların görünürlüğünü kapat
  var pages = document.getElementsByClassName("container")[0].children;
  for (var i = 0; i < pages.length; i++) {
    pages[i].style.display = "none";
  }

  // Tüm stil öğelerini kaldır
  var existingStyles = document.querySelectorAll('style');
  for (var j = 0; j < existingStyles.length; j++) {
    existingStyles[j].parentNode.removeChild(existingStyles[j]);
  }

  // Seçilen sayfanın görünürlüğünü aç
  var page = document.getElementById(pageId);
  page.style.display = "block";

  // Seçilen sayfaya özel stil ekle
  var styleElement = document.createElement('style');
  if (pageId == "page1") {
    styleElement.innerHTML = css1;
  } else if (pageId == "page2") {
    styleElement.innerHTML = css2;
  } else if (pageId == "page3") {
    styleElement.innerHTML = css3;
  }
  document.head.appendChild(styleElement);
}
 //Navbarda Butonlara Basıldığındaki Efekt ve Aynı Sayfa İçinde Sayfa Bölme sonu
