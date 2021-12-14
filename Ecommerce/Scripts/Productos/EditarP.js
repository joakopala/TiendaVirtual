$("#btnEditarP").click(function () {


    $.ajax({
        url: '/Productos/Guardar',
        data: $('#frmProductoEditar').serialize(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var obj = data;
            debugger;
            if (obj.EsCorrecto) {

                $(location).attr('href', '/Productos/ListProductos');
            }
            else {

                $("#divError").show('');
                $("#divError").text(obj.Mensaje);

            }
        }

    });

});