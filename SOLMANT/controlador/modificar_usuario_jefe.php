<?php
$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');

$idJefe= $_POST["idJefe"];
$nombre=$_POST["nombre"];
$apellido=$_POST["apellido"];
$usuario=$_POST["usuario"];
$password=$_POST["password"];
$departamento=$_POST["departamento"];

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuracion: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuracion: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$sql =("UPDATE usersjefes SET Nombre='$nombre', Apellido='$apellido', Usuario='$usuario', Password='$password', Departamento='$departamento' WHERE idJefe='$idJefe'");

 $query=mysqli_query($enlace,$sql);
if ($query) {
    
  header("Location: ../vistas/crud_jefes.php?mensaje=Usuario%20Mdodificado%20correctamente");
    exit;
}
else {echo '<div class="alert alert-success">registro incorrecto</div>';}
?>