# Script de Creación de Base de Datos - TechSolutions

## Descripción
Este script crea la base de datos **TechSolutionsDB** con todas las tablas, relaciones, constraints y índices necesarios para el sistema de gestión empresarial TechSolutions.

## Instrucciones de Ejecución
1. Abrir SQL Server Management Studio (SSMS)
2. Conectarse al servidor SQL Server
3. Copiar y ejecutar el siguiente script completo
4. Verificar que todas las tablas se hayan creado correctamente

---

## Script SQL

```sql
-- =============================================
-- Script de Creación de Base de Datos
-- Sistema: TechSolutions
-- Versión: 1.0
-- Fecha: 2024
-- =============================================

-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TechSolutionsDB')
BEGIN
    CREATE DATABASE TechSolutionsDB;
    PRINT 'Base de datos TechSolutionsDB creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos TechSolutionsDB ya existe.';
END
GO

-- Usar la base de datos
USE TechSolutionsDB;
GO

-- =============================================
-- ELIMINAR TABLAS SI EXISTEN (para recrear)
-- =============================================
IF OBJECT_ID('DetalleVenta', 'U') IS NOT NULL DROP TABLE DetalleVenta;
IF OBJECT_ID('TransaccionStock', 'U') IS NOT NULL DROP TABLE TransaccionStock;
IF OBJECT_ID('Venta', 'U') IS NOT NULL DROP TABLE Venta;
IF OBJECT_ID('Producto', 'U') IS NOT NULL DROP TABLE Producto;
IF OBJECT_ID('Categoria', 'U') IS NOT NULL DROP TABLE Categoria;
IF OBJECT_ID('Proveedor', 'U') IS NOT NULL DROP TABLE Proveedor;
IF OBJECT_ID('Cliente', 'U') IS NOT NULL DROP TABLE Cliente;
IF OBJECT_ID('Usuario', 'U') IS NOT NULL DROP TABLE Usuario;
IF OBJECT_ID('Rol', 'U') IS NOT NULL DROP TABLE Rol;
IF OBJECT_ID('TipoMovimiento', 'U') IS NOT NULL DROP TABLE TipoMovimiento;
GO

PRINT 'Tablas anteriores eliminadas (si existían).';
GO

-- =============================================
-- TABLA: Rol
-- =============================================
CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200) NULL,
    CONSTRAINT CK_Rol_NombreRol CHECK (LEN(NombreRol) > 0)
);
GO

PRINT 'Tabla Rol creada.';
GO

-- =============================================
-- TABLA: Usuario
-- =============================================
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    ContrasenaHash VARBINARY(MAX) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol(IdRol),
    CONSTRAINT CK_Usuario_NombreUsuario CHECK (LEN(NombreUsuario) >= 3)
);
GO

PRINT 'Tabla Usuario creada.';
GO

-- =============================================
-- TABLA: Cliente
-- =============================================
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NULL,
    Telefono NVARCHAR(20) NULL,
    Direccion NVARCHAR(200) NULL,
    CONSTRAINT CK_Cliente_Nombre CHECK (LEN(Nombre) > 0),
    CONSTRAINT CK_Cliente_Apellido CHECK (LEN(Apellido) > 0)
);
GO

PRINT 'Tabla Cliente creada.';
GO

-- =============================================
-- TABLA: Proveedor
-- =============================================
CREATE TABLE Proveedor (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),
    NombreProveedor NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Direccion NVARCHAR(200) NULL,
    CONSTRAINT CK_Proveedor_Nombre CHECK (LEN(NombreProveedor) > 0)
);
GO

PRINT 'Tabla Proveedor creada.';
GO

-- =============================================
-- TABLA: Categoria
-- =============================================
CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    NombreCategoria NVARCHAR(100) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200) NULL,
    CONSTRAINT CK_Categoria_Nombre CHECK (LEN(NombreCategoria) > 0)
);
GO

PRINT 'Tabla Categoria creada.';
GO

-- =============================================
-- TABLA: Producto
-- =============================================
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(300) NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    IdCategoria INT NOT NULL,
    IdProveedor INT NULL,
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    CONSTRAINT FK_Producto_Proveedor FOREIGN KEY (IdProveedor) REFERENCES Proveedor(IdProveedor),
    CONSTRAINT CK_Producto_Nombre CHECK (LEN(Nombre) > 0),
    CONSTRAINT CK_Producto_Precio CHECK (Precio > 0),
    CONSTRAINT CK_Producto_Stock CHECK (Stock >= 0)
);
GO

PRINT 'Tabla Producto creada.';
GO

-- =============================================
-- TABLA: Venta
-- =============================================
CREATE TABLE Venta (
    IdVenta INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    IdCliente INT NOT NULL,
    IdUsuario INT NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    CONSTRAINT FK_Venta_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    CONSTRAINT CK_Venta_Total CHECK (Total >= 0)
);
GO

PRINT 'Tabla Venta creada.';
GO

-- =============================================
-- TABLA: DetalleVenta
-- =============================================
CREATE TABLE DetalleVenta (
    IdDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_DetalleVenta_Venta FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVenta_Producto FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto),
    CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleVenta_PrecioUnitario CHECK (PrecioUnitario > 0),
    CONSTRAINT CK_DetalleVenta_Subtotal CHECK (Subtotal >= 0)
);
GO

PRINT 'Tabla DetalleVenta creada.';
GO

-- =============================================
-- TABLA: TipoMovimiento
-- =============================================
CREATE TABLE TipoMovimiento (
    IdTipoMovimiento INT PRIMARY KEY IDENTITY(1,1),
    NombreMovimiento NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT CK_TipoMovimiento_Nombre CHECK (LEN(NombreMovimiento) > 0)
);
GO

PRINT 'Tabla TipoMovimiento creada.';
GO

-- =============================================
-- TABLA: TransaccionStock
-- =============================================
CREATE TABLE TransaccionStock (
    IdTransaccion INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT NOT NULL,
    IdTipoMovimiento INT NOT NULL,
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Observacion NVARCHAR(200) NULL,
    CONSTRAINT FK_TransaccionStock_Producto FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto),
    CONSTRAINT FK_TransaccionStock_TipoMovimiento FOREIGN KEY (IdTipoMovimiento) REFERENCES TipoMovimiento(IdTipoMovimiento),
    CONSTRAINT CK_TransaccionStock_Cantidad CHECK (Cantidad != 0)
);
GO

PRINT 'Tabla TransaccionStock creada.';
GO

-- =============================================
-- ÍNDICES PARA MEJORAR RENDIMIENTO
-- =============================================

-- Índices en Usuario
CREATE INDEX IX_Usuario_NombreUsuario ON Usuario(NombreUsuario);
CREATE INDEX IX_Usuario_IdRol ON Usuario(IdRol);
GO

-- Índices en Cliente
CREATE INDEX IX_Cliente_Nombre ON Cliente(Nombre, Apellido);
CREATE INDEX IX_Cliente_Email ON Cliente(Email);
GO

-- Índices en Producto
CREATE INDEX IX_Producto_Nombre ON Producto(Nombre);
CREATE INDEX IX_Producto_IdCategoria ON Producto(IdCategoria);
CREATE INDEX IX_Producto_IdProveedor ON Producto(IdProveedor);
CREATE INDEX IX_Producto_Stock ON Producto(Stock);
GO

-- Índices en Venta
CREATE INDEX IX_Venta_Fecha ON Venta(Fecha DESC);
CREATE INDEX IX_Venta_IdCliente ON Venta(IdCliente);
CREATE INDEX IX_Venta_IdUsuario ON Venta(IdUsuario);
GO

-- Índices en DetalleVenta
CREATE INDEX IX_DetalleVenta_IdVenta ON DetalleVenta(IdVenta);
CREATE INDEX IX_DetalleVenta_IdProducto ON DetalleVenta(IdProducto);
GO

-- Índices en TransaccionStock
CREATE INDEX IX_TransaccionStock_IdProducto ON TransaccionStock(IdProducto);
CREATE INDEX IX_TransaccionStock_FechaMovimiento ON TransaccionStock(FechaMovimiento DESC);
GO

PRINT 'Índices creados exitosamente.';
GO

-- =============================================
-- RESUMEN DE TABLAS CREADAS
-- =============================================
PRINT '';
PRINT '========================================';
PRINT 'BASE DE DATOS CREADA EXITOSAMENTE';
PRINT '========================================';
PRINT 'Tablas creadas:';
PRINT '  1. Rol';
PRINT '  2. Usuario';
PRINT '  3. Cliente';
PRINT '  4. Proveedor';
PRINT '  5. Categoria';
PRINT '  6. Producto';
PRINT '  7. Venta';
PRINT '  8. DetalleVenta';
PRINT '  9. TipoMovimiento';
PRINT ' 10. TransaccionStock';
PRINT '';
PRINT 'Total de tablas: 10';
PRINT 'Índices creados: 11';
PRINT '';
PRINT 'La base de datos está lista para recibir datos.';
PRINT 'Ejecute el script insert.md para cargar datos de prueba.';
PRINT '========================================';
GO
```

---

## Verificación

Después de ejecutar el script, verifica que todas las tablas se hayan creado correctamente con:

```sql
USE TechSolutionsDB;
GO

SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO
```

Deberías ver las 10 tablas listadas.

---

## Notas Importantes

1. **Servidor SQL**: Asegúrate de actualizar el nombre del servidor en `Conexion.cs` si es diferente a `DESKTOP-FFT69FN`
2. **Permisos**: El usuario de SQL Server debe tener permisos para crear bases de datos
3. **Backup**: Si ya existe una base de datos con el mismo nombre, este script la eliminará y recreará
4. **Constraints**: Todas las tablas tienen constraints para mantener la integridad de datos
5. **Índices**: Se han creado índices en las columnas más consultadas para mejorar el rendimiento

---

## Siguiente Paso

Una vez creada la base de datos, ejecuta el archivo **insert.md** para cargar los datos de prueba.
