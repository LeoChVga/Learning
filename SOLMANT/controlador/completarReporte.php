<?php 
$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');
$idReporte=$_POST["idReporte"];
date_default_timezone_set("America/Mexico_City");
$fechaActual = date("Y-m-d");

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuración: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuración: " . mysqli_connect_error() . PHP_EOL;
    exit;
}


$sql=$enlace->query("UPDATE `reportes` SET `estado`='El reporte ha sido completado', `FechaTermino`='$fechaActual'  WHERE idreportes='$idReporte'");
    
if ($sql == 1) {
    echo '<div class="alert alert-success">idReportes = $idReporte</div>';
    header("Location: ../vistas/solicitudesPendientesEmpleados.php?mensaje=Reporte%20guardado%20correctamente");
    exit;
}
else {echo '<div class="alert alert-success">registro incorrecto</div>';}


     
?>