$(document).ready(function () {
    // Variables globales
    let userEmail = '';
    let timerInterval;
    let timeLeft = 300; // 5 minutos en segundos
    let resendTimeLeft = 60; // 60 segundos para reenviar
    let generatedCode = '';

    // Generar código de 6 dígitos
    function generateCode() {
        return Math.floor(100000 + Math.random() * 900000).toString();
    }

    // Mostrar mensaje
    function showMessage(text, type) {
        const $alert = $('#alert-message');
        const $text = $('#message-text');

        $alert.removeClass('alert-success alert-error alert-info');
        $alert.addClass(`alert-${type}`);
        $text.html(text);
        $alert.show();

        // Ocultar después de 5 segundos (excepto info)
        if (type !== 'info') {
            setTimeout(() => $alert.hide(), 5000);
        }
    }

    // Cambiar de paso
    function goToStep(step) {
        // Actualizar indicador
        $('.step').removeClass('active completed');

        for (let i = 1; i <= step; i++) {
            const $step = $(`#step-${i}`);
            if (i < step) {
                $step.addClass('completed');
            } else if (i === step) {
                $step.addClass('active');
            }
        }

        // Mostrar formulario correspondiente
        $('.recovery-form').removeClass('active');
        $(`#form-step-${step}`).addClass('active');

        // Limpiar mensajes
        $('#alert-message').hide();
    }

    // Iniciar temporizador
    function startTimer() {
        clearInterval(timerInterval);
        timeLeft = 300;

        timerInterval = setInterval(() => {
            timeLeft--;

            const minutes = Math.floor(timeLeft / 60);
            const seconds = timeLeft % 60;
            $('#timer .countdown').text(`${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`);

            if (timeLeft <= 0) {
                clearInterval(timerInterval);
                $('#timer').addClass('expired');
                $('#btn-verify-code').prop('disabled', true);
                showMessage('El código ha expirado. Solicita uno nuevo.', 'error');
            }
        }, 1000);

        // Iniciar temporizador de reenvío
        startResendTimer();
    }

    // Temporizador para reenviar
    function startResendTimer() {
        resendTimeLeft = 60;
        $('#btn-resend-code').prop('disabled', true);

        const resendInterval = setInterval(() => {
            resendTimeLeft--;
            $('#resend-timer').text(`(${resendTimeLeft.toString().padStart(2, '0')}s)`);

            if (resendTimeLeft <= 0) {
                clearInterval(resendInterval);
                $('#btn-resend-code').html('<i class="fas fa-redo"></i> Reenviar código').prop('disabled', false);
                $('#resend-timer').text('');
            }
        }, 1000);
    }

    // Validar email institucional
    function isValidInstitutionalEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!re.test(email)) return false;

        // Dominios institucionales permitidos
        const allowedDomains = [
            'pozarica.gob.mx',
            'ayuntamiento.pr',
            'gobiernopr.gob.mx',
            'pr.gob.mx'
        ];

        const domain = email.split('@')[1].toLowerCase();
        return allowedDomains.includes(domain);
    }

    // Paso 1: Enviar código
    $('#form-email').submit(function (e) {
        e.preventDefault();

        userEmail = $('#email').val().trim();

        if (!userEmail) {
            showMessage('Por favor, ingresa tu correo electrónico institucional.', 'error');
            return false;
        }

        if (!isValidInstitutionalEmail(userEmail)) {
            showMessage('Debes ingresar un correo institucional válido del ayuntamiento.', 'error');
            return false;
        }

        // Simular envío de código (en producción sería al servidor)
        generatedCode = generateCode();
        $('#btn-send-code').html('<i class="fas fa-spinner fa-spin"></i> Enviando...').prop('disabled', true);

        setTimeout(() => {
            // Mostrar éxito
            showMessage(`
                        <i class="fas fa-check-circle"></i>
                        Código enviado a <strong>${userEmail}</strong>.<br>
                        <small><strong>Código de prueba:</strong> ${generatedCode}</small>
                    `, 'info');

            // Actualizar UI
            $('#email-display').text(userEmail);
            $('#btn-send-code').html('<i class="fas fa-paper-plane"></i> Enviar Código de Verificación').prop('disabled', false);

            // Ir al paso 2
            goToStep(2);
            startTimer();

            // Enfocar primer input
            $('.code-input[data-index="0"]').focus();
        }, 2000);

        return false;
    });

    // Manejar inputs del código
    $('.code-input').on('input', function () {
        const index = parseInt($(this).data('index'));
        const value = $(this).val();

        // Solo números
        if (!/^\d*$/.test(value)) {
            $(this).val('');
            return;
        }

        // Mover al siguiente input si hay valor
        if (value.length === 1 && index < 5) {
            $(`.code-input[data-index="${index + 1}"]`).focus();
        }

        // Actualizar apariencia
        $(this).toggleClass('filled', value.length === 1);

        // Construir código completo
        let fullCode = '';
        $('.code-input').each(function () {
            fullCode += $(this).val();
        });

        $('#verification-code').val(fullCode);

        // Habilitar botón si código completo
        $('#btn-verify-code').prop('disabled', fullCode.length !== 6);
    });

    // Navegación con teclado en código
    $('.code-input').on('keydown', function (e) {
        const index = parseInt($(this).data('index'));

        if (e.key === 'Backspace' && $(this).val() === '' && index > 0) {
            $(`.code-input[data-index="${index - 1}"]`).focus();
        }

        if (e.key === 'ArrowLeft' && index > 0) {
            $(`.code-input[data-index="${index - 1}"]`).focus();
        }

        if (e.key === 'ArrowRight' && index < 5) {
            $(`.code-input[data-index="${index + 1}"]`).focus();
        }
    });

    // Reenviar código
    $('#btn-resend-code').click(function () {
        if ($(this).prop('disabled')) return;

        // Generar nuevo código
        generatedCode = generateCode();

        // Resetear inputs
        $('.code-input').val('').removeClass('filled');
        $('#verification-code').val('');
        $('#btn-verify-code').prop('disabled', true);

        // Restablecer temporizador
        clearInterval(timerInterval);
        timeLeft = 300;
        $('#timer').removeClass('expired');
        startTimer();

        // Mostrar mensaje
        showMessage(`
                    <i class="fas fa-check-circle"></i>
                    Nuevo código enviado a <strong>${userEmail}</strong>.<br>
                    <small><strong>Código de prueba:</strong> ${generatedCode}</small>
                `, 'info');

        // Enfocar primer input
        $('.code-input[data-index="0"]').focus();
    });

    // Verificar código
    $('#form-code').submit(function (e) {
        e.preventDefault();

        const enteredCode = $('#verification-code').val();

        if (enteredCode.length !== 6) {
            showMessage('El código debe tener 6 dígitos.', 'error');
            return false;
        }

        // Verificar código (en producción sería contra el servidor)
        if (enteredCode === generatedCode) {
            $('#btn-verify-code').html('<i class="fas fa-spinner fa-spin"></i> Verificando...').prop('disabled', true);

            setTimeout(() => {
                showMessage('<i class="fas fa-check-circle"></i> Código verificado correctamente.', 'success');

                // Ir al paso 3
                setTimeout(() => {
                    goToStep(3);
                    $('#btn-verify-code').html('<i class="fas fa-check-circle"></i> Verificar Código').prop('disabled', false);
                    clearInterval(timerInterval);
                }, 1500);
            }, 1000);
        } else {
            showMessage('Código incorrecto. Por favor, verifica e intenta nuevamente.', 'error');
        }

        return false;
    });

    // Mostrar/ocultar contraseñas
    $('#show-password').change(function () {
        const type = $(this).is(':checked') ? 'text' : 'password';
        $('#new-password, #confirm-password').attr('type', type);
    });

    // Validar fortaleza de contraseña
    $('#new-password').on('input', function () {
        const password = $(this).val();
        let strength = 0;
        let text = 'Débil';
        let color = '#d32f2f';
        let width = 20;

        // Validaciones
        if (password.length >= 8) strength++;
        if (password.length >= 12) strength++;
        if (/[A-Z]/.test(password)) strength++;
        if (/[a-z]/.test(password)) strength++;
        if (/[0-9]/.test(password)) strength++;
        if (/[^A-Za-z0-9]/.test(password)) strength++;

        // Determinar nivel
        if (strength >= 5) {
            text = 'Muy Fuerte';
            color = '#2e7d32';
            width = 100;
        } else if (strength >= 4) {
            text = 'Fuerte';
            color = '#4caf50';
            width = 80;
        } else if (strength >= 3) {
            text = 'Moderada';
            color = '#ff9800';
            width = 60;
        } else if (strength >= 2) {
            text = 'Débil';
            color = '#ff5722';
            width = 40;
        } else {
            text = 'Muy Débil';
            color = '#d32f2f';
            width = 20;
        }

        $('#strength-text').text(text);
        $('#strength-fill').css({
            'width': `${width}%`,
            'background-color': color
        });

        // Verificar coincidencia
        checkPasswordMatch();
    });

    // Verificar que las contraseñas coincidan
    $('#confirm-password').on('input', checkPasswordMatch);

    function checkPasswordMatch() {
        const pass1 = $('#new-password').val();
        const pass2 = $('#confirm-password').val();
        const $match = $('#password-match');

        if (pass2.length === 0) {
            $match.text('').removeClass('text-success text-danger');
        } else if (pass1 === pass2) {
            $match.html('<i class="fas fa-check-circle"></i> Las contraseñas coinciden').addClass('text-success').removeClass('text-danger');
        } else {
            $match.html('<i class="fas fa-times-circle"></i> Las contraseñas no coinciden').addClass('text-danger').removeClass('text-success');
        }
    }

    // Cambiar contraseña
    $('#form-password').submit(function (e) {
        e.preventDefault();

        const newPassword = $('#new-password').val();
        const confirmPassword = $('#confirm-password').val();

        // Validaciones
        if (newPassword.length < 8) {
            showMessage('La contraseña debe tener al menos 8 caracteres.', 'error');
            return false;
        }

        if (newPassword !== confirmPassword) {
            showMessage('Las contraseñas no coinciden.', 'error');
            return false;
        }

        // Validar fortaleza mínima
        const hasUpperCase = /[A-Z]/.test(newPassword);
        const hasLowerCase = /[a-z]/.test(newPassword);
        const hasNumbers = /[0-9]/.test(newPassword);
        const hasSpecialChar = /[^A-Za-z0-9]/.test(newPassword);

        if (!hasUpperCase || !hasLowerCase || !hasNumbers) {
            showMessage('La contraseña debe incluir mayúsculas, minúsculas y números.', 'error');
            return false;
        }

        // Simular cambio de contraseña
        $('#btn-change-password').html('<i class="fas fa-spinner fa-spin"></i> Procesando...').prop('disabled', true);

        setTimeout(() => {
            showMessage(`
                        <i class="fas fa-check-circle"></i>
                        Contraseña cambiada exitosamente.<br>
                        <small>Redirigiendo al inicio de sesión...</small>
                    `, 'success');

            // Redirigir después de 3 segundos
            setTimeout(() => {
                window.location.href = 'Login.html?message=password_changed';
            }, 3000);
        }, 2000);

        return false;
    });

    // Acceso rápido para testing
    $(document).keypress(function (e) {
        // Alt + T para cargar email de prueba
        if (e.altKey && e.key === 't') {
            $('#email').val('admin@pozarica.gob.mx');
            showMessage('Email de prueba cargado. Envía el formulario para continuar.', 'info');
        }

        // Alt + S para saltar al paso 3
        if (e.altKey && e.key === 's') {
            userEmail = 'admin@pozarica.gob.mx';
            generatedCode = '123456';
            $('#email-display').text(userEmail);
            goToStep(3);
            showMessage('Modo testing activado. Puedes probar el cambio de contraseña.', 'info');
        }
    });
});