$(document).ready(function () {


    $(document).on("click", "#btnCrearProduct", function (e) {

        $('#myModalCrea').modal('show');
    });

    $("#btnCreaProduct").click(function () {
       
        var uri = $('#urlCrearProducto').val();

        var Data = {
            Titulo: $('#txtTitulo').val(),
            Grupo: $('#txtGrupo').val(),
            Ano: $('#txtAno').val(),
            Genero: $('#txtGenero').val()
        };

        $.ajax({
            type: "post",
            datatype: 'json',
            url: uri,
            data: Data,
            success: function (response) {
                if (response.success) {
                    $('#myModalCrea').modal('hide');
                    swal({
                        title: "Correcto",
                        text: response.responseText,
                        icon: "success",
                        buttons: true,
                        dangerMode: true,
                    })
                        .then((willDelete) => {
                            if (willDelete) {
                           
                                location.reload();
                            } else {
                                
                                location.reload();
                            }
                        });
                } else {
                    $('#myModalCrea').modal('hide');
                    swal({
                        title: "Error !!",
                        text: response.responseText,
                        type: 'error',
                        confirmButtonColor: "#DD6B55",
                        allowOutsideClick: false,
                        confirmButtonText: "Aceptar"
                    }).then(function () {
                        location.reload();
                    }, function (dismiss) {
                        location.reload();
                    });
                }
            }
        });
        
    });

    

    $(document).on("click", "#btnEditProduct", function (e) {
       
        var uri = $('#urlEditarPostProductos').val();       
        var data = new FormData();
        data.append('id_Cancion', $('#txtId').val());
        data.append('Titulo', $('#txtTitulo').val());
        data.append('Grupo', $('#txtGrupo').val());
        data.append('Ano', $('#txtAno').val());
        data.append('Genero', $('#txtGenero').val());


        if ($('#txtDescripcion').val() == "")
        {
            swal("Warning!", "Falta Descripcion!", "warning")
            return;
        }
        else if ($('#txtUnidad').val() == "")
        {
            swal("Warning!", "Falta Tipo de Unidad!", "warning")
            return;
        }
        else if ($('#txtTipoProveedor').val() == "")
        {
            swal("Warning!", "Falta Tipo Proveedor!", "warning")
            return;
        } 

        $.ajax({
            type: "POST",
            url: uri,
            contentType: false,
            processData: false,
            data: data,
            success: function (response) {
                if (response.success) {
                    $('#myModal').modal('hide');
                    swal({
                        title: "Correcto",
                        text: response.responseText,
                        icon: "success",
                        buttons: true,
                        dangerMode: true,
                    })
                        .then((willDelete) => {
                            if (willDelete) {
                               
                                location.reload();
                            } else {
                               
                                location.reload();
                            }
                        });
                    
                } else {
                    $('#myModal').modal('hide');
                    swal({
                        title: "Error !!",
                        text: response.responseText,
                        type: 'error',
                        confirmButtonColor: "#DD6B55",
                        allowOutsideClick: false,
                        confirmButtonText: "Aceptar"
                    }).then(function () {

                    }, function (dismiss) {

                    });
                   

                }
            }
        });
    });

    

});


function editarCancion(idCancion)
{
    var url = $('#urlEditarGetProductos').val();
    var datos = {
        idCancion: idCancion
    };
    var jqxhr = $.get(url, datos)
        .done(function (data) {
            if (data.success) {
                $('#txtId').val(data.idCancion);
                $('#txtTitulo').val(data.Titulo);
                $('#txtGrupo').val(data.Grupo);
                $('#txtAno').val(data.Ano);
                $('#txtGenero').val(data.Genero);
                
                $('#myModal').modal('show');

            }
            else {
                dialog.modal('hide');
                swal({
                    title: "Error !!",
                    text: response.responseText,
                    type: 'error',
                    confirmButtonColor: "#DD6B55",
                    allowOutsideClick: false,
                    confirmButtonText: "Aceptar"
                }).then(function () {



                });

            }
        })
        .fail(function () {
            dialog.modal('hide');
            swal({
                title: "Error !!",
                text: response.responseText,
                type: 'error',
                confirmButtonColor: "#DD6B55",
                allowOutsideClick: false,
                confirmButtonText: "Aceptar"
            }).then(function () {

                location.reload();

            });
        });

}
