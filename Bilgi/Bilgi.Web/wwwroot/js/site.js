
//Anasaysa Sepete Ekleme
function submitForm(id, adet) {
    $.ajax({
        url: "/Sepet/SepeteEkle",
        type: "POST",
        data: { id: id, adet: adet },
        success: function (response) {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Sepete Eklendi',
                showConfirmButton: false,
                timer: 1500
            })
            $("#sepetsayi").load("/Sepet/GuncelSepetSayisi");
        },
        error: function (xhr, status, error) {
            // İsteğin başarısız olduğu durumda yapılacak işlemler
        }
    });
}


//Admin Urun Durumu değişimi
function durumGuncelle(id) {
    $.ajax({
        url: "/Urun/UrunDurumDegis",
        type: "GET",
        data: { id: id },
        success: function (response) {
            $("#urunlerliste").load("/Urun/ListeGuncelle");
        },
        error: function (xhr, status, error) {
            // İsteğin başarısız olduğu durumda yapılacak işlemler
        }
    });

}

function adet(id) {

    
    var adet = $('#'+id).val();
    console.log(adet)
    $.ajax({
        url: "/Sepet/AdetGuncelle",
        type: "GET",
        data: { id: id, adet: adet },
        success: function (response) {
            window.location.reload();
          
        },
        error: function (xhr, status, error) {
            // İsteğin başarısız olduğu durumda yapılacak işlemler
        }
    });

}