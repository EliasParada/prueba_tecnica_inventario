$(document).ready(function () {

    $("#btnAdd").click(function () {
        const data = {
            nombreElectrodomestico: $("#txtNombre").val(),
            tipoCategoriaId: $("#cmbCategoria").val(),
            sucursalId: $("#cmbSucursal").val(),
            cantidadInventario: $("#txtCantidad").val(),
            habilitarProducto: true
        };

        $.ajax({
            url: "/Electrodomesticos/Create",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: () => location.reload()
        });
    });

    $(".btnDelete").click(function () {
        const id = $(this).closest("tr").data("id");

        $.post("/Electrodomesticos/Delete", { id }, () => location.reload());
    });

    $(".toggle").change(function () {
        const id = $(this).closest("tr").data("id");
        $.post("/Electrodomesticos/Edit", { id });
    });

});
