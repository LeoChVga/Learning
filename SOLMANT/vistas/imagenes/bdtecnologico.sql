-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-08-2023 a las 10:41:10
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdtecnologico`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reportes`
--

CREATE TABLE `reportes` (
  `idreportes` int(30) NOT NULL,
  `Titulo` varchar(50) NOT NULL,
  `Descripcion` varchar(1000) NOT NULL,
  `FechaReporte` date NOT NULL,
  `FechaTermino` date DEFAULT NULL,
  `IdJefe` int(50) NOT NULL,
  `idAdmin` int(50) NOT NULL,
  `idEmpleado` int(50) DEFAULT NULL,
  `Lugar` varchar(30) DEFAULT NULL,
  `estado` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `reportes`
--

INSERT INTO `reportes` (`idreportes`, `Titulo`, `Descripcion`, `FechaReporte`, `FechaTermino`, `IdJefe`, `idAdmin`, `idEmpleado`, `Lugar`, `estado`) VALUES
(1, 'Falla', 'Descripcion de falla', '2023-11-22', '0000-00-00', 1, 1, 1, NULL, 'El reporte ha sido completado'),
(3, 'Falla 2', 'falla 2 descripcion', '2023-04-22', '0000-00-00', 1, 1, 2, 'Edificio a', 'Se ha asignado un responsable'),
(23, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 1, 'eDIFICIO MATERIALES', 'El reporte ha sido completado'),
(33, 'falla 3', 'fallaaa', '2022-02-12', '0000-00-00', 1, 1, 2, 'salas', 'Se ha asignado un responsable'),
(40, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '2023-08-11', 1, 1, 1, 'eDIFICIO MATERIALES', 'El reporte ha sido completado'),
(41, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 1, 'eDIFICIO MATERIALES', 'El reporte ha sido completado'),
(42, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 1, 'eDIFICIO MATERIALES', 'El reporte ha sido completado'),
(43, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 1, 'eDIFICIO MATERIALES', 'El reporte ha sido completado'),
(45, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 2, 'eDIFICIO MATERIALES', 'Se ha asignado un responsable'),
(46, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 2, 'eDIFICIO MATERIALES', 'Se ha asignado un responsable'),
(100, 'Prubea rerporte', 'descripciooooooon', '2022-02-22', '0000-00-00', 1, 1, 2, 'Parte tracera eificio 1', 'Se ha asignado un responsable'),
(200, 'otro repote', 'otra descripcion', '2022-02-22', '0000-00-00', 1, 1, 1, 'otro edificio', 'El reporte ha sido completado'),
(223, 'AAAAAAAAAAAAA', 'DESCRIPCION', '2022-03-23', '0000-00-00', 1, 1, 2, 'eDIFICIO MATERIALES', 'Se ha asignado un responsable');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usersadmin`
--

CREATE TABLE `usersadmin` (
  `idAdmin` int(20) NOT NULL,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Apellido` varchar(20) NOT NULL,
  `Area` varchar(20) NOT NULL,
  `tipoUsuario` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usersadmin`
--

INSERT INTO `usersadmin` (`idAdmin`, `Usuario`, `Password`, `Nombre`, `Apellido`, `Area`, `tipoUsuario`) VALUES
(0, 'Edgar', '123', 'Edgar', 'Carreon', 'Sistemas', 'administrador');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usersempleados`
--

CREATE TABLE `usersempleados` (
  `idEmpleados` int(20) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Apellido` varchar(30) NOT NULL,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(200) NOT NULL,
  `IdAdmin` int(20) NOT NULL,
  `Area` varchar(30) NOT NULL,
  `tipo` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usersempleados`
--

INSERT INTO `usersempleados` (`idEmpleados`, `Nombre`, `Apellido`, `Usuario`, `Password`, `IdAdmin`, `Area`, `tipo`) VALUES
(1, 'Carlos', 'Santoyo', 'santoyo', '123', 1, 'sistemas', 'empleado'),
(2, 'Leonel', 'Garcia', 'LeoGarcia', '123', 1, 'sistemas', 'empleado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usersjefes`
--

CREATE TABLE `usersjefes` (
  `idJefe` int(20) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Apellido` varchar(30) NOT NULL,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Departamento` varchar(20) NOT NULL,
  `tipoUsuario` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usersjefes`
--

INSERT INTO `usersjefes` (`idJefe`, `Nombre`, `Apellido`, `Usuario`, `Password`, `Departamento`, `tipoUsuario`) VALUES
(1, 'Brenda', 'Avitia', 'Brenda', '123', 'Jefatura de sistemas', 'jefeDepartamento');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `reportes`
--
ALTER TABLE `reportes`
  ADD PRIMARY KEY (`idreportes`);

--
-- Indices de la tabla `usersadmin`
--
ALTER TABLE `usersadmin`
  ADD PRIMARY KEY (`idAdmin`);

--
-- Indices de la tabla `usersempleados`
--
ALTER TABLE `usersempleados`
  ADD PRIMARY KEY (`idEmpleados`);

--
-- Indices de la tabla `usersjefes`
--
ALTER TABLE `usersjefes`
  ADD PRIMARY KEY (`idJefe`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `usersempleados`
--
ALTER TABLE `usersempleados`
  MODIFY `idEmpleados` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `usersjefes`
--
ALTER TABLE `usersjefes`
  MODIFY `idJefe` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
