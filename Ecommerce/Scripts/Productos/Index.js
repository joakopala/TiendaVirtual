$("#btnInsertar").click(function () {

    $.ajax({
        url: '/Productos/Guardar',
        data: $('#frmProductoRegistro').serialize(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var obj = data;
            debugger;
            if (obj.EsCorrecto) {

                $(location).attr('href', '/Productos/Index')
                /*$("#divError").show('');*/
                /*$("#divError").text('ok sucio');*/
            }
            else {

                $("#divError").show('');
                $("#divError").text(obj.Mensaje);
                /*     $("#divError")[0].innerHTML = obj.Mensaje.split(';').join("<br>")*/
            }
        }

    });

});