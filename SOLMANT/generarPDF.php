<?php
require('fpdf.php');
$idreportes=$_POST['idReporte'];
$enlace = new mysqli("127.0.0.1", "root", "", "bdtecnologico");
$enlace->set_charset('utf8');

if (!$enlace) {
    echo "Error: No se pudo conectar a MySQL." . PHP_EOL;
    echo "errno de depuracion: " . mysqli_connect_errno() . PHP_EOL;
    echo "error de depuracion: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$sql = "SELECT  `Titulo`, `Descripcion`, r.Lugar ,`FechaReporte`, `FechaTermino`,CONCAT(j.Nombre,' ',J.Apellido) as NombreJefe ,CONCAT(E.Nombre,' ',E.Apellido) as nombeEmpleado, CONCAT(A.Nombre,' ',A.Apellido) AS nombreAdmin ,r.idAdmin,j.Departamento FROM `reportes` AS r  INNER JOIN usersjefes AS j on r.IdJefe=j.idJefe INNER JOIN usersempleados e on r.idEmpleado=e.idEmpleados INNER JOIN usersadmin a on a.idAdmin=r.idAdmin WHERE r.idreportes=$idreportes;";
$results = mysqli_query($enlace, $sql) or die(mysqli_error($enlace));
$consulta=mysqli_fetch_array($results); 



$titulo = $consulta[0];
$descripcion = $consulta[1];
$lugar=$consulta[2];
$fechaSolicitud = $consulta[3];
$fechaTermino = $consulta[4];
$NombreJefeArea = $consulta[5];
$PuestoJefeArea = $consulta[9];
$responsable = $consulta[6];
$NombreAdmin = $consulta[7];
$idAdmin=$consulta[8];
$areaDestino;
$puestoAdmin;
if($idAdmin==1){
    $puestoAdmin="Jefe del Centro de computo";
    $areaDestino="Centro de computo";
}
else
{
    $puestoAdmin="Jefe del Dtp. de Mantenimiento de equipo";
    $areaDestino="Mantenimiento de Equipo";

}
class PDF extends FPDF {
    private $lineHeight = 1.0;
    function MultiCell($w, $h, $txt, $border = 0, $align = 'J', $fill = false) {
        $oldLineWidth = $this->LineWidth;
        $this->SetLineWidth(0);
        parent::MultiCell($w, $h * $this->lineHeight, $txt, $border, $align, $fill);
        $this->SetLineWidth($oldLineWidth);
    }
    function setLineHeight($value) {
        $this->lineHeight = $value;
    }
    function Header() { 
    $this->Image('tecnmLogo.png', 10, 5, 20);
    $this->SetFont('Arial', 'B', 14);
    $this->SetXY(80, 15); 
    $this->Cell(50, 5, 'SOLICITUD DE TRABAJO DE MANTENIMIENTO', 0, 1, 'C');
    $this->Image('itcclogo.png', 180, 5, 20);
    $this->Ln(8);   
        $this->SetDrawColor(0, 0, 0); 
        $this->Line(10, $this->GetY() + 5, 200, $this->GetY() + 5); 
        $this->Ln(11);
    }
    function Footer() {
    }
    function CreateTable($header, $data) {
        $this->SetFont('Arial', '', 8);
        $this->SetTextColor(0); 
        for ($i = 0; $i < count($header); $i++) {
            if ($i == 0) {
                $this->SetFillColor(192); 
            } else {
                $this->SetFillColor(255); 
            }
            $this->Cell(50, 5, $header[$i], 1, 0, 'C', true);
        }
        $this->Ln();
        $this->SetFont('Arial', '', 8);
        foreach ($data as $row) {
            foreach ($row as $colIndex => $col) {
                if ($colIndex == 0) {
                    $this->SetFillColor(192); 
                    $this->SetFillColor(255); 
                }
                $this->Cell(50, 5, $col, 1, 0, 'C', true);
            }
            $this->Ln();
        }
    }

    function CreateTable2($header2, $data2) {
        $this->SetFont('Arial', '', 8);
        $this->SetTextColor(0); 
        for ($i = 0; $i < count($header2); $i++) {
            if ($i == 0) {
                $this->SetFillColor(192); 
                $this->SetFillColor(255); 
            }
            if ($i == 1) {
                $this->Cell(50, 5, $header2[$i], 1, 0, 'C', true); 
            } else {
                $this->Cell(50, 5, $header2[$i], 1, 0, 'C', true);
            }
        }
        $this->Ln();
        $this->SetFont('Arial', '', 8);
        foreach ($data2 as $row) {
            foreach ($row as $colIndex => $col) {
                if ($colIndex == 0) {
                    $this->SetFillColor(192); 
                    $this->SetFillColor(255); 
                }
                if ($colIndex == 1) {
                    $this->Cell(50, 5, $col, 1, 0, 'C', true); 
                } else {
                    $this->Cell(50, 5, $col, 1, 0, 'C', true);
                }
            }
            $this->Ln();
        }
    }
}
$pdf = new PDF();
$pdf->AddPage();
$header = array('Fecha de solicitud', $fechaSolicitud);
$data = array(
    array('Fecha de termino', $fechaTermino),
    array('Area que va dirigida la solicitud', $areaDestino),
    array('Nombre del solicitante',$NombreJefeArea),
    array('Departamento del solicitante',$PuestoJefeArea),
);

$pdf->CreateTable($header, $data);
$yPos = $pdf->GetY()-10;
$xPos=$pdf->GetX();
$pdf->SetFont('Arial', '', 10);
$pdf->SetTextColor(0); 
$lineHeight = 0.5; 
$pdf->setLineHeight($lineHeight);
$pdf->SetFillColor(192); 
$pdf->Rect(10, 90, $pdf->GetPageWidth() - 20, 5, 'F'); 
$pdf->SetXY(10, 90); 
$pdf->MultiCell(0, 10, 'Titulo de la falla y/o servicio solicitado', 1, 'L', false);
$pdf->SetXY(10, 95); 
$pdf->MultiCell(0, 10, $titulo, 1, 'L',false); 
$pdf->SetFillColor(192); 
$pdf->Rect(10, 100, $pdf->GetPageWidth() - 20, 5, 'F'); 
$pdf->SetXY(10, 100); 
$pdf->MultiCell(0, 10, 'Descripcion de la falla y/o servicio solicitado', 1, 'L', false);
$pdf->SetXY(10, 105); 
$pdf->MultiCell(0, 10, $descripcion, 1, 'L',false); 
$pdf->SetFillColor(192); 
$pdf->Rect(10, 80, $pdf->GetPageWidth() - 20, 5, 'F'); 
$pdf->SetXY(10, 80); 
$pdf->MultiCell(0, 10, 'Nombre de la persona asignada a realizar el reporte', 1, 'L', false);
$pdf->SetXY(10, 85); 
$pdf->MultiCell(0, 10, $responsable, 1, 'L',false);
$pdf->SetFillColor(192); 
$pdf->Rect(10, 70, $pdf->GetPageWidth() - 20, 5, 'F'); 
$pdf->SetXY(10, 70); 
$pdf->MultiCell(0, 10, 'Lugar de la falla o servicio solicitado', 1, 'L', false);
$pdf->SetXY(10, 75); 
$pdf->MultiCell(0, 10, $lugar, 1, 'L',false); 
$pdf->Ln(20);
$columnWidth = $pdf->GetPageWidth() / 3;
$currentY = $pdf->GetY()+150;
$pdf->SetXY(10, $currentY);
$pdf->SetX(10);
$pdf->Cell($columnWidth, 5, $NombreAdmin, 0, 1, 'C');
$pdf->SetX(10);
$pdf->Cell($columnWidth, 5, $puestoAdmin, 0, 1, 'C');
$pdf->Line(10, $pdf->GetY()-10, $columnWidth + 7, $pdf->GetY()-10);
$pdf->SetXY(10 + $columnWidth, $currentY);
$pdf->SetX(10 + $columnWidth);
$pdf->Cell($columnWidth, 5, $NombreJefeArea, 0, 1, 'C');
$pdf->SetX(10 + $columnWidth);
$pdf->Cell($columnWidth, 5, $PuestoJefeArea, 0, 1, 'C');
$pdf->Line(10 + $columnWidth, $pdf->GetY()-10, $columnWidth * 2 + 7, $pdf->GetY()-10);
$pdf->SetXY(10 + $columnWidth * 2+8, $currentY);
$pdf->SetX(10 + $columnWidth * 2+14);
$pdf->Cell($columnWidth, 5, $responsable, 0, 1, 'L');
$pdf->SetX(10 + $columnWidth * 2);
$pdf->Cell($columnWidth, 5, 'Responsable Asigano al Reporte', 0, 1, 'L');
$pdf->Line(10 + $columnWidth * 2, $pdf->GetY()-10, $columnWidth * 3 -5, $pdf->GetY()-10);
$pdf->Output();
?>