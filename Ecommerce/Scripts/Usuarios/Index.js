$("#btnRegistrarse").click(function () {

    //var resultado = validarFormulario();

    ///*debugger;*/

    //if (resultado.replaceAll(';', '').trim().length > 0) {


    //    $("#divError").text(resultado);
    //    $("#divError").show('slow');
    //}

    //else {

    //    $("#frmUsuarioRegistro").submit();
    //}


    $.ajax({
        url: '/Usuarios/Guardar',
        data: $('#frmUsuarioRegistro').serialize(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var obj = data;
            debugger;
            if (obj.EsCorrecto) {

                /* $(location).attr('href', '/Home/Index')*/
                $("#divError").show('');
                $("#divError").text('ok sucio');
            }
            else {

                $("#divError").show('');
                $("#divError").text(obj.Mensaje);
                /*     $("#divError")[0].innerHTML = obj.Mensaje.split(';').join("<br>")*/
            }
        }

    });

});

//function validarFormulario() {

//    var resultado;

//    debugger;

//    resultado = validaCampoVacio("Nombre");
//    resultado = resultado + '; ' + validaCampoVacio("Apellido");
//    resultado = resultado + '; ' + validaCampoVacio("Email");
//    resultado = resultado + '; ' + validaCampoVacio("Direccion");
//    resultado = resultado + '; ' + validaCampoVacio("Clave");
//    resultado = resultado + '; ' + validaCampoVacio("Edad");
//    resultado = resultado + '; ' + validaCampoVacio("FechaNacimiento");

//    return resultado;
//}