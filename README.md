[README.md](https://github.com/user-attachments/files/20970699/README.md)# Sistema CRUD de Roles y Usuarios

Este proyecto es una aplicación de escritorio desarrollada en C# con Windows Forms (.NET Framework) y conexión a MySQL usando XAMPP. Permite gestionar el ciclo completo CRUD (Crear, Leer, Actualizar, Eliminar) de usuarios y roles, siguiendo buenas prácticas y arquitectura en capas.

## Estructura del Proyecto

```
Roles_y_Usuarios_Semana5/
│
├── Modelo/              # Clases modelo: Usuario, Rol
├── Datos/               # Lógica de conexión y acceso a datos (DAO)
├── Vista/               # Formularios WinForms (Roles, Usuarios, Inicio)
├── Program.cs           # Punto de entrada (abre el menú principal)
└── README.md            # Documentación del proyecto
```

## Funcionalidades

### Usuarios
- Registrar nuevo usuario
- Editar y eliminar usuarios existentes
- Asignar roles a usuarios
- Ver estado (activo/inactivo)

### Roles
- Crear nuevos roles
- Editar o eliminar roles no asignados
- Ver lista completa de roles activos

### Vista integrada
- Usa la vista v_usuarios_completa para mostrar roles asignados
- Consulta segura con parámetros para evitar inyecciones SQL
- Procedimientos y funciones opcionales desde base de datos

## Tecnologías utilizadas

| Tecnología     | Descripción                             |
|----------------|-----------------------------------------|
| C#             | Lógica de aplicación (WinForms .NET Framework) |
| MySQL          | Base de datos relacional                |
| XAMPP          | Servidor local de base de datos         |
| Windows Forms  | Interfaz gráfica de escritorio          |
| MVC            | Arquitectura en capas (Modelo - Datos - Vista) |

## Requisitos

- Visual Studio 2019 o superior (.NET Framework)
- XAMPP con MySQL (activo)
- Paquete NuGet: MySql.Data

## Base de Datos

Usa el script:  
roles_usuarios_semana5.sql

Incluye:

- Tabla roles
- Tabla usuarios
- Vista v_usuarios_completa
- Procedimiento: sp_puede_eliminar_rol
- Función: fn_contar_usuarios_rol

## Cómo ejecutar

1. Clonar o descargar el repositorio
2. Importar el archivo SQL en phpMyAdmin
3. Abrir el proyecto en Visual Studio
4. Asegurarse de tener agregado MySql.Data desde NuGet
5. Ejecutar la solución (Ctrl + F5)
6. Elegir desde el menú: Gestión de Roles o Gestión de Usuarios

## Autor

Josué Alejandro Ballesteros Navas

## Licencia

Este proyecto es solo con fines educativos y académicos.

