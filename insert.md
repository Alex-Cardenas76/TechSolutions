# Script de Inserción de Datos de Prueba - TechSolutions

## Descripción
Este script inserta datos de prueba en la base de datos **TechSolutionsDB** para poder probar todas las funcionalidades del sistema.

## Datos que se insertarán:
- 3 Roles (Admin, Supervisor, Vendedor)
- 3 Usuarios (uno por cada rol)
- 50 Clientes
- 10 Proveedores
- 8 Categorías
- 40 Productos
- 2 Tipos de Movimiento (Entrada, Salida)
- Transacciones de stock iniciales

## Instrucciones
1. Asegúrate de haber ejecutado primero el script **scriptBD.md**
2. Copia y ejecuta este script completo en SQL Server Management Studio
3. Las contraseñas de los usuarios son: **admin123**, **super123**, **vende123**

---

## Script SQL

```sql
-- =============================================
-- Script de Inserción de Datos de Prueba
-- Sistema: TechSolutions
-- =============================================

USE TechSolutionsDB;
GO

PRINT 'Iniciando inserción de datos de prueba...';
GO

-- =============================================
-- 1. INSERTAR ROLES
-- =============================================
INSERT INTO Rol (NombreRol, Descripcion) VALUES
('Administrador', 'Acceso total al sistema'),
('Supervisor', 'Gestión de inventario y reportes'),
('Vendedor', 'Registro de ventas y consultas');
GO

PRINT '✓ 3 Roles insertados';
GO

-- =============================================
-- 2. INSERTAR USUARIOS
-- Contraseñas: admin123, super123, vende123
-- Hash SHA-256 generado correctamente
-- =============================================
INSERT INTO Usuario (NombreUsuario, ContrasenaHash, IdRol, Estado) VALUES
('admin', 0x240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9, 1, 1),
('supervisor', 0x4E4C56E4A15F89F05C2F4C72613DA2A18C9665D4F0D6ACCE16415EB06F9BE776, 2, 1),
('vendedor', 0x1AD6411C0C7D03159718FE5DB7230462688551A309AF849B5E03EDFC6650B030, 3, 1);
GO

PRINT '✓ 3 Usuarios insertados (admin, supervisor, vendedor)';
PRINT '  Contraseñas: admin123, super123, vende123';
GO

-- =============================================
-- 3. INSERTAR 50 CLIENTES
-- =============================================
INSERT INTO Cliente (Nombre, Apellido, Email, Telefono, Direccion) VALUES
('Juan', 'Pérez', 'juan.perez@email.com', '555-0101', 'Av. Principal 123'),
('María', 'González', 'maria.gonzalez@email.com', '555-0102', 'Calle Secundaria 456'),
('Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', '555-0103', 'Jr. Los Olivos 789'),
('Ana', 'Martínez', 'ana.martinez@email.com', '555-0104', 'Av. Los Pinos 321'),
('Luis', 'García', 'luis.garcia@email.com', '555-0105', 'Calle Las Flores 654'),
('Carmen', 'López', 'carmen.lopez@email.com', '555-0106', 'Jr. San Martín 987'),
('Pedro', 'Hernández', 'pedro.hernandez@email.com', '555-0107', 'Av. Libertad 147'),
('Laura', 'Díaz', 'laura.diaz@email.com', '555-0108', 'Calle Comercio 258'),
('Jorge', 'Sánchez', 'jorge.sanchez@email.com', '555-0109', 'Jr. Independencia 369'),
('Rosa', 'Ramírez', 'rosa.ramirez@email.com', '555-0110', 'Av. Progreso 741'),
('Miguel', 'Torres', 'miguel.torres@email.com', '555-0111', 'Calle Unión 852'),
('Elena', 'Flores', 'elena.flores@email.com', '555-0112', 'Jr. Bolívar 963'),
('Roberto', 'Vargas', 'roberto.vargas@email.com', '555-0113', 'Av. Grau 159'),
('Patricia', 'Castro', 'patricia.castro@email.com', '555-0114', 'Calle Pardo 357'),
('Fernando', 'Morales', 'fernando.morales@email.com', '555-0115', 'Jr. Sucre 486'),
('Sofía', 'Jiménez', 'sofia.jimenez@email.com', '555-0116', 'Av. Arequipa 753'),
('Diego', 'Ruiz', 'diego.ruiz@email.com', '555-0117', 'Calle Lima 951'),
('Gabriela', 'Mendoza', 'gabriela.mendoza@email.com', '555-0118', 'Jr. Cusco 159'),
('Andrés', 'Ortiz', 'andres.ortiz@email.com', '555-0119', 'Av. Tacna 357'),
('Valeria', 'Silva', 'valeria.silva@email.com', '555-0120', 'Calle Piura 486');
GO

INSERT INTO Cliente (Nombre, Apellido, Email, Telefono, Direccion) VALUES
('Ricardo', 'Gutiérrez', 'ricardo.gutierrez@email.com', '555-0121', 'Jr. Ica 753'),
('Daniela', 'Rojas', 'daniela.rojas@email.com', '555-0122', 'Av. Junín 951'),
('Javier', 'Paredes', 'javier.paredes@email.com', '555-0123', 'Calle Puno 159'),
('Mónica', 'Vega', 'monica.vega@email.com', '555-0124', 'Jr. Loreto 357'),
('Raúl', 'Campos', 'raul.campos@email.com', '555-0125', 'Av. Ucayali 486'),
('Claudia', 'Ríos', 'claudia.rios@email.com', '555-0126', 'Calle Madre de Dios 753'),
('Sergio', 'Navarro', 'sergio.navarro@email.com', '555-0127', 'Jr. Apurímac 951'),
('Paola', 'Medina', 'paola.medina@email.com', '555-0128', 'Av. Ayacucho 159'),
('Héctor', 'Reyes', 'hector.reyes@email.com', '555-0129', 'Calle Huánuco 357'),
('Isabel', 'Cortés', 'isabel.cortes@email.com', '555-0130', 'Jr. Pasco 486'),
('Óscar', 'Aguilar', 'oscar.aguilar@email.com', '555-0131', 'Av. Ancash 753'),
('Natalia', 'Salazar', 'natalia.salazar@email.com', '555-0132', 'Calle Cajamarca 951'),
('Arturo', 'Peña', 'arturo.pena@email.com', '555-0133', 'Jr. Lambayeque 159'),
('Lucía', 'Carrillo', 'lucia.carrillo@email.com', '555-0134', 'Av. La Libertad 357'),
('Emilio', 'Domínguez', 'emilio.dominguez@email.com', '555-0135', 'Calle Tumbes 486'),
('Adriana', 'Guerrero', 'adriana.guerrero@email.com', '555-0136', 'Jr. Amazonas 753'),
('Gustavo', 'Ramos', 'gustavo.ramos@email.com', '555-0137', 'Av. San Martín 951'),
('Verónica', 'Herrera', 'veronica.herrera@email.com', '555-0138', 'Calle Huancavelica 159'),
('Mauricio', 'Cabrera', 'mauricio.cabrera@email.com', '555-0139', 'Jr. Moquegua 357'),
('Carolina', 'Luna', 'carolina.luna@email.com', '555-0140', 'Av. Callao 486');
GO

INSERT INTO Cliente (Nombre, Apellido, Email, Telefono, Direccion) VALUES
('Alberto', 'Soto', 'alberto.soto@email.com', '555-0141', 'Calle Central 753'),
('Beatriz', 'Ponce', 'beatriz.ponce@email.com', '555-0142', 'Jr. Norte 951'),
('Cristian', 'Maldonado', 'cristian.maldonado@email.com', '555-0143', 'Av. Sur 159'),
('Diana', 'Figueroa', 'diana.figueroa@email.com', '555-0144', 'Calle Este 357'),
('Eduardo', 'Bravo', 'eduardo.bravo@email.com', '555-0145', 'Jr. Oeste 486'),
('Fernanda', 'Cárdenas', 'fernanda.cardenas@email.com', '555-0146', 'Av. Industrial 753'),
('Guillermo', 'Espinoza', 'guillermo.espinoza@email.com', '555-0147', 'Calle Comercial 951'),
('Helena', 'Valdez', 'helena.valdez@email.com', '555-0148', 'Jr. Residencial 159'),
('Ignacio', 'Montoya', 'ignacio.montoya@email.com', '555-0149', 'Av. Colonial 357'),
('Julia', 'Sandoval', 'julia.sandoval@email.com', '555-0150', 'Calle Moderna 486');
GO

PRINT '✓ 50 Clientes insertados';
GO

-- =============================================
-- 4. INSERTAR 10 PROVEEDORES
-- =============================================
