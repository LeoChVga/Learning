<?php
    

$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');

    $nombre=$_POST["nombre"];
    $apellido=$_POST["apellido"];
    $usuario=$_POST["usuario"];
    $password=$_POST["password"];
    $departamento=$_POST["departamento"];
    $tipo="jefeDepartamento";

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuración: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuración: " . mysqli_connect_error() . PHP_EOL;
    exit;
}


$sql=$enlace->query("INSERT INTO usersjefes (Nombre, Apellido, Usuario,Password,Departamento,tipoUsuario) VALUES ('$nombre','$apellido','$usuario','$password','$departamento','$tipo')");

if ($sql == 1) {
    
    header("Location: ../vistas/crud_jefes.php?mensaje=Usuario%20guardado%20correctamente");
    exit;
}
else {echo '<div class="alert alert-success">registro incorrecto</div>';}


     
?>