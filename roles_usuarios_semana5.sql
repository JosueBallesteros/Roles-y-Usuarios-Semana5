-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-06-2025 a las 01:43:55
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `roles_usuarios_semana5`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_puede_eliminar_rol` (IN `rol_id` INT, OUT `puede_eliminar` BOOLEAN)   BEGIN
    DECLARE usuario_count INT DEFAULT 0;
    
    SELECT COUNT(*) INTO usuario_count
    FROM usuarios 
    WHERE RolesId = rol_id AND Activo = 1;
    
    SET puede_eliminar = (usuario_count = 0);
END$$

--
-- Funciones
--
CREATE DEFINER=`root`@`localhost` FUNCTION `fn_contar_usuarios_rol` (`rol_id` INT) RETURNS INT(11) DETERMINISTIC READS SQL DATA BEGIN
    DECLARE usuario_count INT DEFAULT 0;
    
    SELECT COUNT(*) INTO usuario_count
    FROM usuarios 
    WHERE RolesId = rol_id AND Activo = 1;
    
    RETURN usuario_count;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `RolesId` int(11) NOT NULL,
  `Detalle` varchar(255) NOT NULL,
  `FechaCreacion` timestamp NOT NULL DEFAULT current_timestamp(),
  `Activo` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`RolesId`, `Detalle`, `FechaCreacion`, `Activo`) VALUES
(1, 'Administrador', '2025-06-29 22:57:22', 1),
(2, 'Usuario', '2025-06-29 22:57:22', 1),
(3, 'Moderador', '2025-06-29 22:57:22', 1),
(4, 'Manager', '2025-06-29 22:57:22', 1),
(5, 'Invitado', '2025-06-29 22:57:22', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `UsuarioId` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `correo` varchar(150) NOT NULL,
  `password` varchar(255) NOT NULL,
  `RolesId` int(11) DEFAULT NULL,
  `FechaCreacion` timestamp NOT NULL DEFAULT current_timestamp(),
  `FechaModificacion` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Activo` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`UsuarioId`, `Nombre`, `correo`, `password`, `RolesId`, `FechaCreacion`, `FechaModificacion`, `Activo`) VALUES
(1, 'Juan Pérez', 'juan.perez@email.com', 'password123', 1, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(2, 'María González', 'maria.gonzalez@email.com', 'password456', 2, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(3, 'Carlos Rodriguez', 'carlos.rodriguez@email.com', 'password789', 2, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(4, 'Ana López', 'ana.lopez@email.com', 'password321', 3, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(5, 'Luis Martínez', 'luis.martinez@email.com', 'password654', 4, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(6, 'Laura Sánchez', 'laura.sanchez@email.com', 'password987', 2, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(7, 'Pedro García', 'pedro.garcia@email.com', 'password147', NULL, '2025-06-29 22:57:22', '2025-06-29 22:57:22', 1),
(8, 'Josué Ballesteros', 'locomen.bn@hotmail.com', 'popololoko1', 3, '2025-06-29 23:37:35', '2025-06-29 23:37:35', 1);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `v_usuarios_completa`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `v_usuarios_completa` (
`UsuarioId` int(11)
,`Nombre` varchar(100)
,`correo` varchar(150)
,`RolesId` int(11)
,`RoleDetalle` varchar(255)
,`FechaCreacion` timestamp
,`FechaModificacion` timestamp
,`Activo` tinyint(1)
);

-- --------------------------------------------------------

--
-- Estructura para la vista `v_usuarios_completa`
--
DROP TABLE IF EXISTS `v_usuarios_completa`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_usuarios_completa`  AS SELECT `u`.`UsuarioId` AS `UsuarioId`, `u`.`Nombre` AS `Nombre`, `u`.`correo` AS `correo`, `u`.`RolesId` AS `RolesId`, coalesce(`r`.`Detalle`,'Sin Rol') AS `RoleDetalle`, `u`.`FechaCreacion` AS `FechaCreacion`, `u`.`FechaModificacion` AS `FechaModificacion`, `u`.`Activo` AS `Activo` FROM (`usuarios` `u` left join `roles` `r` on(`u`.`RolesId` = `r`.`RolesId`)) ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`RolesId`),
  ADD UNIQUE KEY `uk_roles_detalle` (`Detalle`),
  ADD KEY `idx_roles_activo` (`Activo`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`UsuarioId`),
  ADD UNIQUE KEY `uk_usuarios_correo` (`correo`),
  ADD KEY `usuarios_roles` (`RolesId`),
  ADD KEY `idx_usuarios_nombre` (`Nombre`),
  ADD KEY `idx_usuarios_activo` (`Activo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `RolesId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `UsuarioId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_roles` FOREIGN KEY (`RolesId`) REFERENCES `roles` (`RolesId`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
