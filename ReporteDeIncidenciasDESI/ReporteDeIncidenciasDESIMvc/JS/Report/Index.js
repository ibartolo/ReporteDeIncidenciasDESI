
$(document).ready(function () {
    // Gráfica de categorías (Doughnut)
    
    const ctxCategorias = document.getElementById('chartCategorias').getContext('2d');
    const chartCategorias = new Chart(ctxCategorias, {
        type: 'doughnut',
        data: {
            labels: ['Alumbrado', 'Bacheo', 'Basura', 'Agua', 'Parques', 'Otros'],
            datasets: [{
                data: [342, 298, 256, 192, 160, 100],
                backgroundColor: [
                    'rgba(124, 25, 40, 0.8)',
                    'rgba(174, 139, 84, 0.8)',
                    'rgba(11, 78, 162, 0.8)',
                    'rgba(46, 125, 50, 0.8)',
                    'rgba(245, 124, 0, 0.8)',
                    'rgba(128, 128, 128, 0.8)'
                ],
                borderColor: '#ffffff',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 20,
                        usePointStyle: true
                    }
                }
            }
        }
    });

    // Gráfica de tendencia (Line)
    const ctxTendencia = document.getElementById('chartTendencia').getContext('2d');
    const chartTendencia = new Chart(ctxTendencia, {
        type: 'line',
        data: {
            labels: ['Sep', 'Oct', 'Nov', 'Dic', 'Ene'],
            datasets: [{
                label: 'Incidencias Reportadas',
                data: [980, 1050, 1120, 1180, 1248],
                borderColor: 'rgba(124, 25, 40, 1)',
                backgroundColor: 'rgba(124, 25, 40, 0.1)',
                borderWidth: 3,
                fill: true,
                tension: 0.4
            }, {
                label: 'Incidencias Resueltas',
                data: [720, 780, 830, 865, 892],
                borderColor: 'rgba(46, 125, 50, 1)',
                backgroundColor: 'rgba(46, 125, 50, 0.1)',
                borderWidth: 3,
                fill: true,
                tension: 0.4
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                x: {
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                }
            },
            plugins: {
                legend: {
                    position: 'top'
                }
            }
        }
    });

    // Gráfica de colonias (Bar)
    const ctxColonias = document.getElementById('chartColonias').getContext('2d');
    const chartColonias = new Chart(ctxColonias, {
        type: 'bar',
        data: {
            labels: ['Centro', 'Petrolera', 'Obrera', 'Lomas', 'Reforma'],
            datasets: [{
                label: 'Reportes',
                data: [437, 312, 249, 156, 94],
                backgroundColor: 'rgba(174, 139, 84, 0.8)',
                borderColor: 'rgba(174, 139, 84, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                x: {
                    grid: {
                        display: false
                    }
                }
            },
            plugins: {
                legend: {
                    display: false
                }
            }
        }
    });

    // Gráfica de estatus (Polar Area)
    const ctxEstatus = document.getElementById('chartEstatus').getContext('2d');
    const chartEstatus = new Chart(ctxEstatus, {
        type: 'polarArea',
        data: {
            labels: ['Resueltas', 'En Proceso', 'Pendientes', 'Urgentes'],
            datasets: [{
                data: [892, 236, 120, 85],
                backgroundColor: [
                    'rgba(46, 125, 50, 0.8)',
                    'rgba(245, 124, 0, 0.8)',
                    'rgba(128, 128, 128, 0.8)',
                    'rgba(211, 47, 47, 0.8)'
                ],
                borderColor: '#ffffff',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 20,
                        usePointStyle: true
                    }
                }
            },
            scales: {
                r: {
                    grid: {
                        color: 'rgba(0, 0, 0, 0.1)'
                    }
                }
            }
        }
    });

    // Botón generar reporte
    $('#btn-generar-reporte').click(function () {
        $(this).html('<i class="fas fa-spinner fa-spin"></i> Generando...').prop('disabled', true);

        setTimeout(() => {
            $(this).html('<i class="fas fa-chart-line"></i> Generar Reporte').prop('disabled', false);
            alert('Reporte actualizado con los nuevos filtros aplicados.');
        }, 1500);
    });

    // Botones de exportación
    $('.btn-export').click(function () {
        const tipo = $(this).find('i').hasClass('fa-file-pdf') ? 'PDF' :
            $(this).find('i').hasClass('fa-file-excel') ? 'Excel' : 'Impresión';

        $(this).html('<i class="fas fa-spinner fa-spin"></i> Preparando...').prop('disabled', true);

        setTimeout(() => {
            $(this).html('<i class="fas fa-file-' +
                (tipo === 'PDF' ? 'pdf' : tipo === 'Excel' ? 'excel' : 'print') +
                '"></i> Exportar ' + tipo).prop('disabled', false);

            if (tipo === 'Impresión') {
                window.print();
            } else {
                alert('Reporte ' + tipo + ' generado exitosamente.');
            }
        }, 2000);
    });

    // Actualizar fecha fin cuando cambia fecha inicio
    $('#fecha-inicio').change(function () {
        const fechaInicio = new Date($(this).val());
        const fechaFin = new Date(fechaInicio);
        fechaFin.setMonth(fechaFin.getMonth() + 1);

        $('#fecha-fin').val(fechaFin.toISOString().split('T')[0]);
    });
});