$(document).ready(function () {
    // Cambiar entre tabs
    $('.user-tab').click(function () {
        const tab = $(this).data('tab');

        // Actualizar tabs
        $('.user-tab').removeClass('active');
        $(this).addClass('active');

        // Mostrar formulario correspondiente
        $('.login-form').removeClass('active');
        $(`#form-${tab}`).addClass('active');

        // Ocultar mensajes de error
        $('#mensaje-error').hide();
    });

    // Login con Google
    $('#btn-google').click(function () {
        // Aquí iría la integración real con Google OAuth
        $('#mensaje-texto').text('Iniciando sesión con Google...');
        $('#mensaje-error').removeClass('alert-danger').addClass('alert-info').show();

        // Simulación de login exitoso
        setTimeout(function () {
            window.location.href = '/Home/Index';
        }, 1500);
    });

    // Login con Facebook
    $('#btn-facebook').click(function () {
        // Aquí iría la integración real con Facebook OAuth
        $('#mensaje-texto').text('Iniciando sesión con Facebook...');
        $('#mensaje-error').removeClass('alert-danger').addClass('alert-info').show();

        // Simulación de login exitoso
        setTimeout(function () {
            window.location.href = '/Home/Index';
        }, 1500);
    });

    // Formulario interno
    $('#form-login-interno').submit(function (e) {
        e.preventDefault();

        const email = $('#email').val();
        const password = $('#password').val();

        // Validaciones básicas
        if (!email || !password) {
            $('#mensaje-texto').text('Por favor, completa todos los campos.');
            $('#mensaje-error').removeClass('alert-info').addClass('alert-danger').show();
            return false;
        }

        // Validar formato de correo
        if (!isValidEmail(email)) {
            $('#mensaje-texto').text('Por favor, ingresa un correo válido.');
            $('#mensaje-error').removeClass('alert-info').addClass('alert-danger').show();
            return false;
        }

        // Aquí iría la llamada real al API de autenticación
        // Por ahora, simulamos login exitoso para correos del ayuntamiento

        $('#mensaje-texto').html('<i class="fas fa-spinner fa-spin"></i> Verificando credenciales...');
        $('#mensaje-error').removeClass('alert-danger').addClass('alert-info').show();

        // Simulación de petición al servidor
        setTimeout(function () {
            // Verificar si es correo institucional
            if (email.includes('@pozarica.gob.mx') || email.includes('@ayuntamiento.pr')) {
                // Simular login exitoso
                window.location.href = '/Home/Index';
            } else {
                $('#mensaje-texto').text('Solo se permiten correos institucionales del ayuntamiento.');
                $('#mensaje-error').removeClass('alert-info').addClass('alert-danger').show();
            }
        }, 2000);

        return false;
    });

    // Validar email
    function isValidEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }

    // Registro con email alternativo
    $('#link-registro-email').click(function (e) {
        e.preventDefault();
        alert('Próximamente: Registro con correo electrónico para ciudadanos.');
    });

    // Demo de credenciales (para testing)
    $(document).keypress(function (e) {
        // Alt + D para demo
        if (e.altKey && e.key === 'd') {
            $('#email').val('admin@pozarica.gob.mx');
            $('#password').val('demo123');
            alert('Credenciales demo cargadas. Envía el formulario para continuar.');
        }
    });
});