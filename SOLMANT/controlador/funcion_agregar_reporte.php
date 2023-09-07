<?php
session_start();

$enlace =new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');


$tituloReporte=$_POST["tituloReporte"];
$descripcionReporte=$_POST["descripcionReporte"];
$fechaReporte=$_POST["fechaReporte"];
$edificioReporte=$_POST["edificioReporte"];
$tipoFalla=$_POST["tipoFalla"];
$estado="Eviado al administrador";
$idJefe=$_SESSION["iduser"];

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuración: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuración: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

    if ($tipoFalla == 'Depto. de Mantenimiento de Equipo')
    {
             $idAdmin = '2' ;
    }
    else if ($tipoFalla == 'Centro de Computo')
    {
             $idAdmin = '1' ;
    }

   # $idAdmin = ($tipo_Falla === 'Falla_Fisica') ? 1 : 2;

    $guarda = "INSERT INTO  reportes (Titulo,Descripcion,FechaReporte,IdJefe,idAdmin,Lugar,estado) VALUES ('$tituloReporte','$descripcionReporte','$fechaReporte','$idJefe','$idAdmin','$edificioReporte','$estado');";

    if ($enlace->query($guarda) === TRUE) {
        header("Location: ../vistas/panelJefe.php?mensaje=Usuario%20guardado%20correctamente");
        exit;
    } else {
        echo "Error: " . $guarda . "<br>" . $enlace->error;
    }

    
$enlace->close();
?>