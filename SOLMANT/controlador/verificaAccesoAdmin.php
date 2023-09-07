<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Documento sin t&iacute;tulo</title>
</head>

<body>
<?php
$user=$_POST['txtusuario_admin'];
$pass=$_POST['txtcontra_admin'];

//require ('conecta.php');
$enlace = mysqli_connect("127.0.0.1", "root", "", "bdTecnologico");

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuraci�n: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuraci�n: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

 $sqlAdmin = "SELECT `idAdmin`, `Usuario`, `Password`,CONCAT( `Nombre`,`Apellido`) AS `Nombre`, `Area`,`tipoUsuario` FROM `usersadmin` WHERE Usuario='$user' AND Password='$pass'";
 
 $res = mysqli_query($enlace,$sqlAdmin) or die (mysqli_error($enlace));
 
 if ($res!="")
 {
 $consulta=mysqli_fetch_array($res); 
if (!is_null($consulta))
 {
	session_start();
	$_SESSION["tipouser"]=$consulta[5];
	$_SESSION["iduser"]=$consulta[0];
	$_SESSION["nombreuser"]=$consulta[3];
	
	
	mysqli_close($enlace);
	
	if ($_SESSION["tipouser"]=="administrador")
	{
		$men="Bienvenido ".$_SESSION["nombreuser"];
		echo "<script> alert('".$men."');document.location.href='../vistas/panelAdmin.php';</script>";
	}
	//if ($_SESSION["tipouser"]>"1")
	//{
	//	$men="Bienvenido ".$_SESSION["nombreuser"];
	//	echo "<script> alert('".$men."');document.location.href='panel_cliente.php';</script>";
	//}
	
 } 
 else
 {
 
 	mysqli_close($enlace);
 	$men="Usuario o Contraseña Incorrectos";
	echo "<script> alert('".$men."');document.location.href='login.php';</script>";
 }

}



?>

</body>
</html>