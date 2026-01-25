// Script para mejorar la experiencia móvil
$(document).ready(function () {
    // Ajustar tabla para móviles
    function ajustarTablaMovil() {
        if ($(window).width() < 768) {
            // Ya está manejado por CSS
            console.log("Modo móvil activado");
        }
    }

    // Ejecutar al cargar y al redimensionar
    ajustarTablaMovil();
    $(window).resize(ajustarTablaMovil);

    // Mejorar experiencia táctil
    $('.btn-accion-tabla').on('touchstart', function () {
        $(this).css('opacity', '0.7');
    }).on('touchend', function () {
        $(this).css('opacity', '1');
    });

    // Validación básica de formularios
    $('.btn-filtro-primario').click(function () {
        var fecha = $('#fecha').val();
        if (fecha) {
            alert('Buscando incidencias con fecha: ' + fecha);
            // Aquí iría la lógica real de búsqueda
        }
    });
});