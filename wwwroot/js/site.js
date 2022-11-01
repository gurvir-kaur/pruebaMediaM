// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#datatableProductos').DataTable({
        language: {
            url: "//cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json"
        }
    });
});