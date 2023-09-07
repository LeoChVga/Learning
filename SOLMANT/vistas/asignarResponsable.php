<?php
$responsable = $_POST["responsable"];
$nombreApellido=explode(' ',$responsable);
$idReporte=$_POST["idReporte"];
$enlace = mysqli_connect("127.0.0.1", "root", "", "bdtecnologico");

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuracion: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuracion: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$IdEmpleadoQuery = "SELECT idEmpleados FROM `usersempleados` WHERE Nombre='$nombreApellido[0]' and Apellido='$nombreApellido[1]'";
$idEmpleadoResult = mysqli_query($enlace, $IdEmpleadoQuery) or die(mysqli_error($enlace));

// Verifica si se obtuvieron resultados antes de usarlos
if ($idEmpleadoResult) {
    $idEmpleadoRow = mysqli_fetch_assoc($idEmpleadoResult);
    $idEmpleado = $idEmpleadoRow['idEmpleados'];
    
    $query = "UPDATE `reportes` SET `idEmpleado`='$idEmpleado', `estado`='Se ha asignado un responsable' WHERE idreportes='$idReporte'";
    $results = mysqli_query($enlace, $query) or die(mysqli_error($enlace));
    echo '<script language="javascript">alert("Se ha asignado correctamente el reporte a '.$responsable.'");</script>';
    header("Location: solicitudesPendientes.php?success=1");
    exit();
    
} else {
    echo "Error al obtener el ID del empleado.";
}

?>