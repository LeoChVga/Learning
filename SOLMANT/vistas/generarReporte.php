<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulario de Reporte</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>

<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
        <div class="container">
            <a class="navbar-brand" href="#">

                Sistema de reportes del Instituto Tecnologico de Ciudad Cuauhtemoc
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="panelJefe.php">Inicio</a>
                    </li>
</nav>
<?php
    require('../controlador/validaJefe.php');


?>

<form action="../controlador/funcion_agregar_reporte.php" method="post" enctype="multipart/form-data">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8"    >
                <div class="card" >
                    <div class="card-header bg-primary text-white">
                        <h3 class="mb-0">Formulario de Reporte</h3>
                    </div>

                    <div  class="card-body">
                        <form enctype="multipart/form-data" method="post" >
                            <div class="mb-3">
                                <label for="tituloReporte" class="form-label">Título del Reporte </label>
                                <input type="text" class="form-control" id="tituloReporte" name="tituloReporte" required>
                            </div>
                            <div class="mb-3">
                                <label for="descripcionReporte" class="form-label">Descripción del Reporte</label>
                                <textarea class="form-control" id="descripcionReporte" name="descripcionReporte" rows="4" required></textarea>
                            </div>
                            <div class="mb-3">
                                <label for="fechaReporte" class="form-label">Fecha del Reporte</label>
                                <input type="date" class="form-control" id="fechaReporte" name="fechaReporte" required>
                            </div>
                            <div class="mb-3">
                                <label for="edificio" class="form-label">Edificio o lugar de la falla o problema</label>
                                <input type="text" class="form-control" id="edificioReporte" name="edificioReporte" required>
                                
                            </div>
                            <div class="mb-3">
                                <label for="tipoFalla" class="form-label">Tipo de Falla</label>
                                <select class="form-select" id="tipoFalla" name="tipoFalla" required>
                                    <option value="" disabled selected>Seleccionar Tipo de Falla</option>
                                    <option value="Depto. de Mantenimiento de Equipo">Depto. de Mantenimiento de Equipo</option>
                                    <option value="Centro de Computo">Centro de Computo</option>
                                </select>
                            </div>
                            
                            <button type="submit" class="btn btn-success" name="btnenviarsolicitud" value= "ok">Enviar Solicitud</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
