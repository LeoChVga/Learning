<?php
$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');

$idEmpleado= $_POST["idEmpleados"];

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuracion: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuracion: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$sql=$enlace->query("DELETE FROM usersempleados WHERE idEmpleados='$idEmpleado'");

if ($sql == 1) {
    
  header("Location: ../vistas/crud_empleados.php?mensaje=Usuario%20Mdodificado%20correctamente");
    exit;
}
else {echo '<div class="alert alert-success">registro incorrecto</div>';}