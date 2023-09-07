<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <title>Dashboard</title>
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
                        <a class="nav-link" href="panelAdmin.php">Inicio</a>
                    </li>
</nav>
    <?php
    session_start();
    require('../controlador/validaAdmin.php');
    $idAdmin=$_SESSION["iduser"]  
    ?>

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-4" method="POST">
            
                <!-- Formulario para dar de alta usuarios -->
                <form action="../controlador/agregar_usuario_empleado.php" method="POST">
                    <div class="form-group">
                        <label for="nombre">Nombre:</label>
                        <input type="text" class="form-control" name="nombre" required>
                    </div>
                    <div class="form-group">
                        <label for="apellido">Apellido:</label>
                        <input type="text" class="form-control" name="apellido" required>
                    </div>
                    <div class="form-group">
                        <label for="usuario">Usuario:</label>
                        <input type="text" class="form-control" name="usuario" required>
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña:</label>
                        <input type="password" class="form-control" name="password" required>
                    </div>
                    <div class="form-group">
                        <label for="area">Area:</label>
                        <input type="text" class="form-control" name="area" required>
                    </div>
                    <button type="submit" class="btn btn-success" name="btnguardar">Guardar Usuario</button>
                </form>
            </div>
            <div class="col-md-8">

                <!-- Tabla para visualizar, modificar y eliminar usuarios -->
                
<div class="container">
    <h3 class="mt-3 mb-4">Empleados</h3>
    <div class="table-responsive">
    <table class="table table-bordered table-striped custom-table">
    <thead>
        <tr>
            
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Usuario</th>
            <th>Password</th>
            
            <th>Area</th>
            <th>Acciones</th>
        </tr>
    </thead>
<tbody>
<?php

$enlace = mysqli_connect("127.0.0.1", "root", "", "bdtecnologico");

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuración: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuración: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

$sql = $enlace->query("SELECT * FROM usersempleados  WHERE idAdmin=$idAdmin");
while($datos = $sql->fetch_object()){?>

 <tr>   
        <td style="display: none;"><?= $datos->idEmpleados?></td>
        <td> <?=$datos->Nombre?>  </td>
        <td> <?=$datos->Apellido ?></td>
        <td> <?=$datos->Usuario ?> </td>
        <td> <?=$datos->Password ?> </td>
        
        <td> <?=$datos->Area ?> </td>
        <td>
            
            <a href="#" class="btn btn-sm btn-info" data-toggle="modal" data-target="#editarModal<?= $datos->idEmpleados ?>">Editar</a>

            <a href="#" class="btn btn-sm btn-danger" data-toggle="modal" data-target="#eliminarModal<?=$datos->idEmpleados ?>">Eliminar</a>
        </td>
 </tr>


                      <!-- modal para editar el usuario jefe  -->
                        <div class="modal fade" id="editarModal<?= $datos->idEmpleados ?>" tabindex="-1" role="dialog"   aria-labelledby="editarModalLabel<?= $datos->idEmpleados?>" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="editarModalLabel<?= $datos->idEmpleados ?>">Editar Usuario</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                               
                                                <div class="modal-body">
                                                    <form action="../controlador/modificar_usuario_empleado.php" method="POST">
                                                        <input type="hidden" name="idEmpleados" value="<?= $datos->idEmpleados ?>">
                                                        <label for="nombre">Nombre</label>
                                                        <input type="text" class="form-control" name="nombre" value="<?= $datos->Nombre ?>">
                                                        <label for="apellido">Apellido</label>
                                                        <input type="text" class="form-control" name="apellido" value="<?= $datos->Apellido ?>">
                                                        <label for="usuario">Usuario</label>
                                                        <input type="text" class="form-control" name="usuario" value="<?= $datos->Usuario ?>">
                                                        <label for="password">Password:</label>
                                                        <input type="text" class="form-control" name="password" value="<?= $datos->Password ?>">
                                                        <label for="area">Area:</label>
                                                        <input type="text" class="form-control" name="area" value="<?=$datos->Area ?>">
                                                        <!-- ... otros campos ... -->
                                                        <button type="submit" class="btn btn-primary">Guardar Cambios</button>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                     <!-- termina modal para editar el usuario jefe  -->


<!-- modal para eliminar el usuario jefe  -->
<div class="modal fade" id="eliminarModal<?= $datos->idEmpleados ?>" tabindex="-1" role="dialog"   aria-labelledby="eliminarModalLabel<?= $datos->idEmpleados ?>" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="eliminarModalLabel<?= $datos->idEmpleados ?>">Eliminar Usuario</h5>

                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                               
                                                <div class="modal-body">
                                                <p class="text-danger">DESEAS ELIMINAR EL USUARIO</p>
                                                    <form action="../controlador/eliminar_usuario_empleado.php" method="POST">
                                                        <input type="hidden" name="idEmpleados" value="<?= $datos->idEmpleados ?>">
                                                        <label for="nombre">Nombre</label>
                                                        <input type="text" class="form-control" name="nombre" value="<?= $datos->Nombre ?>">
                                                        <label for="apellido">Apellido</label>
                                                        <input type="text" class="form-control" name="apellido" value="<?= $datos->Apellido ?>">
                                                        <label for="usuario">Usuario</label>
                                                        <input type="text" class="form-control" name="usuario" value="<?= $datos->Usuario ?>">
                                                        <label for="password">Password:</label>
                                                        <input type="text" class="form-control" name="password" value="<?= $datos->Password ?>">
                                                        <label for="departamento">Departamento:</label>
                                                        <input type="text" class="form-control" name="area" value="<?=$datos->Area ?>">
                                                        <!-- ... otros campos ... -->
                                                        <button type="submit" class="btn btn-danger">Eliminar</button>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                     <!-- termina modal para eliminar el usuario jefe  -->



   <?PHP  }
        ?>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</div>
</div>
</body>
</html>