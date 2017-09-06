
window.onload = function () {
    load();
};
var prm = Sys.WebForms.PageRequestManager.getInstance();
if (prm != null) {
    prm.add_endRequest(function (sender, e) {
        if (sender._postBackSettings.panelsToUpdate != null) {
            load();
        }
    });
};


function load() {
    var URLActual = "" + window.location;

    if (URLActual.includes("Portal/Articulo/Crear")) {

        //evento de observaciones de contador
        var txtObsGen = document.getElementById('MainContent_txtObsGen'),
            count1 = document.getElementById('count1'),
            aler1t = document.getElementById('alert1'),
            maxLength = 100;

        var txtObsArt = document.getElementById('MainContent_txtObsArt'),
            count2 = document.getElementById('count2'),
            alert2 = document.getElementById('alert2'),
            maxLength = 300;


        txtObsGen.addEventListener('input', function (e) {
            var value = e.target.value.replace(/\r?\n/g, '\r\n'),
                length = value.length;


            if (length >= maxLength) {
                if (length > maxLength) {
                    length = maxLength - 1;
                    e.target.value = value.slice(0, length);
                } else {
                    alert1.classList.remove('hidden');
                }
            } else {
                alert1.classList.add('hidden');
            }

            count1.textContent = length;

        }, false);
        txtObsArt.addEventListener('input', function (e) {
            var value = e.target.value.replace(/\r?\n/g, '\r\n'),
                length = value.length;


            if (length >= maxLength) {
                if (length > maxLength) {
                    length = maxLength - 1;
                    e.target.value = value.slice(0, length);
                } else {
                    alert2.classList.remove('hidden');
                }
            } else {
                alert2.classList.add('hidden');
            }

            count2.textContent = length;
        }, false);
        
        //Asignar evento de ceros a columna en la tabla Ubicacion
        var Columnas = [$('#MainContent_txtColumna0')];  
        for (var i = 1; i <= 50; i++) {
            Columnas.push($('#MainContent_txtColumna'+i)); 
        }
        $.each(Columnas,function (){
            $(this).focusout(function () {
                var _valor = $(this).val();
                $(this).val(_valor.padStart(4, "0"));
            });
        });
        
    }

}
