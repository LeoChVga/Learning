<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HISTORIAL JEFE</title>
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
    require("../controlador/validaJefe.php");
    $idJefe=$_SESSION["iduser"];
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
                        <a class="nav-link" href="panelJefe.php">Inicio</a>
                    </li>


                    <li class="nav-item dropdown">

                        <a class="nav-link dropdown-toggle" href="#" id="usuarioDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Usuario

                        </a>
                        <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="usuarioDropdown">

                            <li><a class="dropdown-item" href="#">Cerrar Sesión</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <h3 class="mt-3 mb-4">Historial de Reportes</h3>
        <div class="table-responsive">
            <table class="table table-bordered table-striped custom-table">

                <thead class=" ">
                    <tr>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Jefe de departamento</th>
                    
                    <th>Lugar</th>

             
                    <th>Fecha de solicitud</th>
                    <th>Fecha de termino</th>

                    <th>Estado</th>
                  


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
      //Titulo	Descripcion	Jefe de departamento	Edificio	Fecha de solicitud	Estado	Asignar responsab
      
      $query = "SELECT  r.Titulo, r.Descripcion,CONCAT( j.Nombre,' ',j.Apellido) AS nombre , r.Lugar, r.FechaReporte,r.FechaTermino,r.idReportes,r.estado
      FROM reportes AS r
      INNER JOIN usersjefes AS j ON j.idJefe = r.IdJefe WHERE r.idjefe=$idJefe ORDER BY r.FechaReporte DESC";
      
      $results = mysqli_query($enlace, $query) or die(mysqli_error($enlace));
      
      if (mysqli_num_rows($results) > 0) {
          while ($consulta = mysqli_fetch_array($results)) {
              extract($consulta);
              echo "<tr>
                      <td>".$consulta[0]."</td> 
                      <td>".$consulta[1]."</td>
                      <td>".$consulta[2]."</td>
                      <td>".$consulta[3]."</td>
                      <td>".$consulta[4]."</td>

                      
                      <td>".$consulta[5]."</td>
                      <td>".$consulta[7]."</td>

             
                     </tr>";
              echo "</form>";
          }
          
      }
      



                 
                 
              
          else {
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