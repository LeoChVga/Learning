<?php
    
    
$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
 
session_start();
    require('../controlador/validaAdmin.php');
    $idAdmin=$_SESSION["iduser"];


    $nombre=$_POST["nombre"];
    $apellido=$_POST["apellido"];
    $usuario=$_POST["usuario"];
    $password=$_POST["password"];
    $area=$_POST["area"];
    $tipo="empleado";

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuración: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuración: " . mysqli_connect_error() . PHP_EOL;
    exit;
}


$sql=$enlace->query("INSERT INTO usersempleados (Nombre, Apellido, Usuario,Password,idAdmin,Area,tipo) VALUES ('$nombre','$apellido','$usuario','$password','$idAdmin','$area','$tipo')");

if ($sql == 1) {
    
    header("Location: ../vistas/crud_empleados.php?mensaje=Usuario%20guardado%20correctamente");
    exit;
}
else {echo '<div class="alert alert-success">registro incorrecto</div>';}


     
?>