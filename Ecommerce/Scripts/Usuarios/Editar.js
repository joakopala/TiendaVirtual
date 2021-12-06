$("#btnEditar").click(function () {


    $.ajax({
        url: '/Usuarios/Guardar',
        data: $('#frmUsuarioEditar').serialize(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var obj = data;
            debugger;
            if (obj.EsCorrecto) {

                $(location).attr('href', '/Usuarios/Administracion');
            }
            else {

                $("#divError").show('');
                $("#divError").text(obj.Mensaje);

            }
        }

    });

});