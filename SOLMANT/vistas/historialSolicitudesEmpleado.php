<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HISTORIAL EMPLEADO</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .custom-table {
            background-color: #0C6EFB;
        }

        /* Estilos adicionales para los encabezados de columna (opcional) */
        .custom-table th {
            background-color: #0C6EFB;
            color: white;
            /* Cambia el color del texto si lo deseas */
        }

        body {
            padding: 0px;
            margin: 0px;

        }

        .table {
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
        }

        .table th,
        .table td {
            padding: 0.75rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
        }

        .table tbody+tbody {
            border-top: 2px solid #dee2e6;
        }

        .table-sm th,
        .table-sm td {
            padding: 0.3rem;
        }

        .table-bordered {
            border: 1px solid #dee2e6;
        }

        .table-bordered th,
        .table-bordered td {
            border: 1px solid #dee2e6;
        }

        .table-bordered thead th,
        .table-bordered thead td {
            border-bottom-width: 2px;
        }

        .img-thumbnail {
            max-width: 100px;
            max-height: 100px;
            border: 1px solid #dee2e6;
            border-radius: 0.25rem;
        }

        .btn-row {
            margin-bottom: 20px;
        }
    </style>
</head>

<body>
    <?php 
    session_start();
    $idUser=$_SESSION["iduser"]
    ?>
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
                        <a class="nav-link" href="panelEmpleado.php">Inicio</a>
                    </li>


                  
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <h3 class="mt-3 mb-4">Historial de reportes para el area de sistemas</h3>
        <div class="table-responsive">
            <table class="table table-bordered table-striped custom-table">

                <thead class=" ">
                    <tr>
                        <th>Titulo</th>
                        <th>Descripcion</th>
                        <th>Jefe de departamento</th>
                        <th>Lugar</th>
                        <th>Fecha de solicitud</th>
                        <th>Fecha de Termino</th>
                        <th>Estado</th>
                        <th>Responsable Asignado</th>

                      




                    </tr>
                </thead>
                <tbody>

                </tbody>


                <?php
                $enlace = mysqli_connect("127.0.0.1", "root", "", "bdtecnologico");

                if (!$enlace) {
                    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
                    echo "errno de depuracion: " . mysqli_connect_errno() . PHP_EOL;
                    echo "error de depuracion: " . mysqli_connect_error() . PHP_EOL;
                    exit;
                }
                //Titulo	Descripcion	Jefe de departamento	Edificio	Fotografia	Fecha de solicitud	Estado	Asignar responsab

                $query = "SELECT  r.Titulo, r.Descripcion,CONCAT( j.Nombre,' ',j.Apellido) AS nombre , r.Lugar, r.FechaReporte,r.estado,r.fechaTermino, CONCAT(e.nombre,' ',e.Apellido) AS responsable
      FROM reportes AS r
      INNER JOIN usersjefes AS j ON j.idJefe = r.IdJefe INNER JOIN usersempleados AS e on r.idEmpleado=e.idEmpleados WHERE r.idEmpleado='$idUser' ORDER BY r.FechaReporte DESC";

                $results = mysqli_query($enlace, $query) or die(mysqli_error($enlace));

                if (mysqli_num_rows($results) > 0) {
                    $modalIndex = 0; // Variable para generar identificadores únicos para los modales
                    while ($consulta = mysqli_fetch_array($results)) {
                        extract($consulta);

                        $descripcionFragmento = substr($consulta[1], 0, 50); // Cambia 50 según tus necesidades
                        echo "<tr>
                      <td>" . $consulta[0] . "</td> 
                      <td><a href='#descripcionModal$modalIndex' data-bs-toggle='modal'>$descripcionFragmento... (Click para expandir)</a></td>

                      <td>" . $consulta[2] . "</td>
                      <td>" . $consulta[3] . "</td>
                      <td>" . $consulta[4] . "</td>
                      <td>" . $consulta[6] . "</td>    
                      <td>" . $consulta[5] . "</td>
                      <td>" . $consulta[7] . "</td>

                               
                     </tr>";
                        echo "<div class='modal fade' id='descripcionModal$modalIndex' tabindex='-1' aria-labelledby='descripcionModalLabel$modalIndex' aria-hidden='true'>
                        <div class='modal-dialog'>
                            <div class='modal-content'>
                                <div class='modal-header'>
                                    <h5 class='modal-title' id='descripcionModalLabel$modalIndex'>Descripción Completa</h5>
                                    <button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Cerrar'></button>
                                </div>
                                <div class='modal-body'>
                                    <h4 class='mb-3'>$consulta[0]</h4> <!-- Título -->
                                    <p class='mb-2'><strong>Descripción:</strong></p>
                                    <p class='mb-4'>$consulta[1]</p> <!-- Descripción -->
                                    <p class='mb-2'><strong>Responsable:</strong></p>
                                    <p class='mb-4'>$consulta[2]</p> <!-- Responsable -->
                                    <p class='mb-2'><strong>Lugar:</strong></p>
                                    <p class='mb-0'>$consulta[3]</p> <!-- Lugar -->
                                </div>
                                <div class='modal-footer'>
                                    <button type='button' class='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>";

                        $modalIndex++; //  Incrementar el índice del modal
 



                    }
                } else {
                    echo "<tr>
            <td colspan='8' class='text-center'>No hay reportes pendientes por asignar.</td>
          </tr>";
                }


                ?>

            </table>

        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>


</body>

</html>