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
-- SEED COMPLETA - TECHSOLUTIONS
-- Sistema de Gestion de Productos Tecnologicos
-- =============================================


USE TechSolutionsDB;
GO


PRINT '===========================================';
PRINT 'INICIANDO INSERCION DE DATOS DE PRUEBA';
PRINT 'Tech Solutions - Productos Tecnologicos';
PRINT '===========================================';
GO


-- =============================================
-- 1. INSERTAR ROLES
-- =============================================
PRINT 'Insertando Roles...';


INSERT INTO Rol (NombreRol, Descripcion) VALUES
('Administrador', 'Acceso total al sistema'),
('Supervisor', 'Gestion de inventario y reportes'),
('Vendedor', 'Registro de ventas y consultas');
GO


PRINT 'OK 3 Roles insertados';
GO


-- =============================================
-- 2. INSERTAR USUARIOS
-- =============================================
PRINT 'Insertando Usuarios...';


INSERT INTO Usuario (NombreUsuario, ContrasenaHash, IdRol, Estado) VALUES
('admin', 0x240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9, 1, 1),
('supervisor', 0x4E4C56E4A15F89F05C2F4C72613DA2A18C9665D4F0D6ACCE16415EB06F9BE776, 2, 1),
('vendedor', 0x1AD6411C0C7D03159718FE5DB7230462688551A309AF849B5E03EDFC6650B030, 3, 1);
GO


PRINT 'OK 3 Usuarios insertados';
PRINT '  - admin / admin123';
PRINT '  - supervisor / super123';
PRINT '  - vendedor / vende123';
GO


-- =============================================
-- 3. INSERTAR 100 CLIENTES
-- =============================================
PRINT 'Insertando 100 Clientes...';


INSERT INTO Cliente (Nombre, Apellido, Email, Telefono, Direccion) VALUES
('Juan', 'Perez Garcia', 'juan.perez@gmail.com', '987654321', 'Av. Arequipa 1234, Miraflores'),
('Maria', 'Gonzalez Rodriguez', 'maria.gonzalez@hotmail.com', '987654322', 'Jr. Lampa 456, Cercado de Lima'),
('Carlos', 'Rodriguez Lopez', 'carlos.rodriguez@outlook.com', '987654323', 'Av. Javier Prado 789, San Isidro'),
('Ana', 'Martinez Sanchez', 'ana.martinez@yahoo.com', '987654324', 'Calle Los Olivos 321, Los Olivos'),
('Luis', 'Garcia Fernandez', 'luis.garcia@gmail.com', '987654325', 'Av. Universitaria 654, San Miguel'),
('Carmen', 'Lopez Torres', 'carmen.lopez@hotmail.com', '987654326', 'Jr. Huancavelica 987, Brena'),
('Pedro', 'Hernandez Ramirez', 'pedro.hernandez@gmail.com', '987654327', 'Av. Venezuela 147, Cercado'),
('Laura', 'Diaz Castro', 'laura.diaz@outlook.com', '987654328', 'Calle Comercio 258, Surco'),
('Jorge', 'Sanchez Vargas', 'jorge.sanchez@yahoo.com', '987654329', 'Jr. Independencia 369, Magdalena'),
('Rosa', 'Ramirez Flores', 'rosa.ramirez@gmail.com', '987654330', 'Av. Progreso 741, Ate'),
('Miguel', 'Torres Mendoza', 'miguel.torres@hotmail.com', '987654331', 'Calle Union 852, La Victoria'),
('Elena', 'Flores Gutierrez', 'elena.flores@gmail.com', '987654332', 'Jr. Bolivar 963, Pueblo Libre'),
('Roberto', 'Vargas Rojas', 'roberto.vargas@outlook.com', '987654333', 'Av. Grau 159, Callao'),
('Patricia', 'Castro Paredes', 'patricia.castro@yahoo.com', '987654334', 'Calle Pardo 357, Barranco'),
('Fernando', 'Morales Vega', 'fernando.morales@gmail.com', '987654335', 'Jr. Sucre 486, Jesus Maria'),
('Sofia', 'Jimenez Campos', 'sofia.jimenez@hotmail.com', '987654336', 'Av. Arequipa 753, Lince'),
('Diego', 'Ruiz Rios', 'diego.ruiz@gmail.com', '987654337', 'Calle Lima 951, San Borja'),
('Gabriela', 'Mendoza Navarro', 'gabriela.mendoza@outlook.com', '987654338', 'Jr. Cusco 159, Surquillo'),
('Andres', 'Ortiz Medina', 'andres.ortiz@yahoo.com', '987654339', 'Av. Tacna 357, Rimac'),
('Valeria', 'Silva Reyes', 'valeria.silva@gmail.com', '987654340', 'Calle Piura 486, San Luis'),
('Ricardo', 'Gutierrez Cortes', 'ricardo.gutierrez@hotmail.com', '987654341', 'Jr. Ica 753, Villa El Salvador'),
('Daniela', 'Rojas Aguilar', 'daniela.rojas@gmail.com', '987654342', 'Av. Junin 951, Villa Maria'),
('Javier', 'Paredes Salazar', 'javier.paredes@outlook.com', '987654343', 'Calle Puno 159, Chorrillos'),
('Monica', 'Vega Pena', 'monica.vega@yahoo.com', '987654344', 'Jr. Loreto 357, San Juan'),
('Raul', 'Campos Carrillo', 'raul.campos@gmail.com', '987654345', 'Av. Ucayali 486, Comas'),
('Claudia', 'Rios Dominguez', 'claudia.rios@hotmail.com', '987654346', 'Calle Madre de Dios 753, Independencia'),
('Sergio', 'Navarro Guerrero', 'sergio.navarro@gmail.com', '987654347', 'Jr. Apurimac 951, San Martin'),
('Paola', 'Medina Ramos', 'paola.medina@outlook.com', '987654348', 'Av. Ayacucho 159, Carabayllo'),
('Hector', 'Reyes Herrera', 'hector.reyes@yahoo.com', '987654349', 'Calle Huanuco 357, Puente Piedra'),
('Isabel', 'Cortes Cabrera', 'isabel.cortes@gmail.com', '987654350', 'Jr. Pasco 486, Santa Anita'),
('Oscar', 'Aguilar Luna', 'oscar.aguilar@hotmail.com', '987654351', 'Av. Ancash 753, El Agustino'),
('Natalia', 'Salazar Soto', 'natalia.salazar@gmail.com', '987654352', 'Calle Cajamarca 951, La Molina'),
('Arturo', 'Pena Ponce', 'arturo.pena@outlook.com', '987654353', 'Jr. Lambayeque 159, Santiago de Surco'),
('Lucia', 'Carrillo Maldonado', 'lucia.carrillo@yahoo.com', '987654354', 'Av. La Libertad 357, San Juan de Lurigancho'),
('Emilio', 'Dominguez Figueroa', 'emilio.dominguez@gmail.com', '987654355', 'Calle Tumbes 486, Ate Vitarte'),
('Adriana', 'Guerrero Bravo', 'adriana.guerrero@hotmail.com', '987654356', 'Jr. Amazonas 753, Santa Rosa'),
('Gustavo', 'Ramos Cardenas', 'gustavo.ramos@gmail.com', '987654357', 'Av. San Martin 951, Pachacamac'),
('Veronica', 'Herrera Espinoza', 'veronica.herrera@outlook.com', '987654358', 'Calle Huancavelica 159, Lurin'),
('Mauricio', 'Cabrera Valdez', 'mauricio.cabrera@yahoo.com', '987654359', 'Jr. Moquegua 357, Punta Hermosa'),
('Carolina', 'Luna Montoya', 'carolina.luna@gmail.com', '987654360', 'Av. Callao 486, Punta Negra'),
('Alberto', 'Soto Sandoval', 'alberto.soto@hotmail.com', '987654361', 'Calle Central 753, San Bartolo'),
('Beatriz', 'Ponce Chavez', 'beatriz.ponce@gmail.com', '987654362', 'Jr. Norte 951, Pucusana'),
('Cristian', 'Maldonado Quispe', 'cristian.maldonado@outlook.com', '987654363', 'Av. Sur 159, Ancon'),
('Diana', 'Figueroa Huaman', 'diana.figueroa@yahoo.com', '987654364', 'Calle Este 357, Santa Maria'),
('Eduardo', 'Bravo Ccama', 'eduardo.bravo@gmail.com', '987654365', 'Jr. Oeste 486, Ventanilla'),
('Fernanda', 'Cardenas Mamani', 'fernanda.cardenas@hotmail.com', '987654366', 'Av. Industrial 753, Bellavista'),
('Guillermo', 'Espinoza Condori', 'guillermo.espinoza@gmail.com', '987654367', 'Calle Comercial 951, Carmen de la Legua'),
('Helena', 'Valdez Apaza', 'helena.valdez@outlook.com', '987654368', 'Jr. Residencial 159, La Perla'),
('Ignacio', 'Montoya Yupanqui', 'ignacio.montoya@yahoo.com', '987654369', 'Av. Colonial 357, La Punta'),
('Julia', 'Sandoval Ticona', 'julia.sandoval@gmail.com', '987654370', 'Calle Moderna 486, Mi Peru');
GO


PRINT 'OK 50 Clientes insertados';
GO


-- =============================================
-- 4. INSERTAR PROVEEDORES TECNOLOGICOS
-- =============================================
PRINT 'Insertando Proveedores de Tecnologia...';


INSERT INTO Proveedor (NombreProveedor, Telefono, Email, Direccion) VALUES
('HP Inc. Peru', '014567890', 'ventas@hp.com.pe', 'Av. Republica de Panama 2461, San Isidro'),
('Dell Technologies Peru', '013156789', 'contacto@dell.com.pe', 'Av. Javier Prado Este 4200, Surco'),
('Lenovo Peru', '016234567', 'pedidos@lenovo.pe', 'Av. Camino Real 456, San Isidro'),
('Asus Peru', '014123456', 'ventas@asus.com.pe', 'Av. Santo Toribio 143, San Isidro'),
('Logitech Peru', '012345678', 'peru@logitech.com', 'Av. Paseo de la Republica 3074, San Isidro'),
('Samsung Electronics', '015678901', 'contacto@samsung.pe', 'Av. Javier Prado Este 6868, La Molina'),
('Apple Peru', '017890123', 'pedidos@apple.pe', 'Av. Larco 1301, Miraflores'),
('Microsoft Peru', '014567123', 'ventas@microsoft.pe', 'Av. Republica de Panama 3591, San Isidro'),
('Kingston Technology', '016789012', 'comercial@kingston.pe', 'Av. Nicolas Ayllon 3986, Ate'),
('Seagate Peru', '013456789', 'ventas@seagate.pe', 'Av. Argentina 1795, Callao'),
('TP-Link Peru', '014890123', 'pedidos@tp-link.pe', 'Av. Universitaria 1801, San Miguel'),
('Epson Peru', '015123456', 'contacto@epson.pe', 'Av. Camino Real 390, San Isidro'),
('Canon Peru', '016456789', 'ventas@canon.pe', 'Av. Paseo de la Republica 3074, San Isidro'),
('Xiaomi Peru', '017234567', 'pedidos@xiaomi.pe', 'Av. Javier Prado 5250, La Molina'),
('Huawei Peru', '018901234', 'comercial@huawei.pe', 'Av. Canaval y Moreyra 380, San Isidro');
GO


PRINT 'OK 15 Proveedores insertados';
GO


-- =============================================
-- 5. INSERTAR CATEGORIAS TECNOLOGICAS
-- =============================================
PRINT 'Insertando Categorias Tecnologicas...';


INSERT INTO Categoria (NombreCategoria, Descripcion) VALUES
('Computadoras', 'Laptops, PCs de escritorio y componentes'),
('Perifericos', 'Teclados, mouse, monitores y accesorios'),
('Almacenamiento', 'Discos duros, SSD, memorias USB y tarjetas'),
('Redes', 'Routers, switches, cables y equipos de red'),
('Audio y Video', 'Audifonos, camaras, microfonos y parlantes'),
('Smartphones', 'Telefonos moviles y accesorios'),
('Tablets', 'Tablets y accesorios'),
('Impresoras', 'Impresoras, scanners y consumibles'),
('Gaming', 'Consolas, juegos y accesorios gaming'),
('Software', 'Licencias de software y sistemas operativos');
GO


PRINT 'OK 10 Categorias insertadas';
GO


-- =============================================
-- 6. INSERTAR PRODUCTOS TECNOLOGICOS
-- =============================================
PRINT 'Insertando Productos Tecnologicos...';


INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, IdCategoria, IdProveedor) VALUES
-- Computadoras (Categoria 1)
('Laptop HP 15-dy2021la', 'Intel Core i5-1135G7, 8GB RAM, 256GB SSD, 15.6 pulgadas', 2499.00, 25, 1, 1),
('Laptop Dell Inspiron 15', 'Intel Core i7-1165G7, 16GB RAM, 512GB SSD, 15.6 pulgadas', 3299.00, 20, 1, 2),
('Laptop Lenovo IdeaPad 3', 'AMD Ryzen 5 5500U, 8GB RAM, 512GB SSD, 15.6 pulgadas', 2199.00, 30, 1, 3),
('PC Desktop HP Pavilion', 'Intel Core i5-12400, 16GB RAM, 1TB HDD, Windows 11', 2899.00, 15, 1, 1),
('Laptop Asus VivoBook 15', 'Intel Core i3-1115G4, 8GB RAM, 256GB SSD, 15.6 pulgadas', 1899.00, 35, 1, 4),
('Laptop HP Pavilion Gaming', 'Intel Core i7, 16GB RAM, 512GB SSD, GTX 1650', 4299.00, 12, 1, 1),
('Laptop Dell XPS 13', 'Intel Core i7, 16GB RAM, 512GB SSD, 13.3 pulgadas', 5499.00, 8, 1, 2),
('Laptop Lenovo ThinkPad E14', 'Intel Core i5, 8GB RAM, 256GB SSD, 14 pulgadas', 2799.00, 18, 1, 3),


-- Perifericos (Categoria 2)
('Teclado Logitech K380', 'Teclado inalambrico Bluetooth multidispositivo', 129.00, 80, 2, 5),
('Mouse Logitech M720', 'Mouse inalambrico ergonomico con 8 botones', 149.00, 100, 2, 5),
('Monitor HP 24 Full HD', 'Monitor LED 24 pulgadas 1920x1080 HDMI VGA', 599.00, 40, 2, 1),
('Monitor Dell 27 QHD', 'Monitor IPS 27 pulgadas 2560x1440 USB-C', 1299.00, 25, 2, 2),
('Webcam Logitech C920', 'Camara web Full HD 1080p con microfono estereo', 299.00, 60, 2, 5),
('Teclado Mecanico Logitech', 'Teclado mecanico RGB gaming', 349.00, 45, 2, 5),
('Mouse Gamer Logitech G502', 'Mouse gaming programable 11 botones', 199.00, 70, 2, 5),
('Monitor Samsung 32 Curvo', 'Monitor curvo 32 pulgadas Full HD', 1099.00, 20, 2, 6),


-- Almacenamiento (Categoria 3)
('Disco Duro Seagate 1TB', 'Disco duro externo USB 3.0 portatil', 189.00, 70, 3, 10),
('SSD Kingston 480GB', 'Unidad de estado solido SATA 2.5 pulgadas', 249.00, 90, 3, 9),
('SSD Samsung 1TB NVMe', 'SSD M.2 NVMe PCIe 3.0 alta velocidad', 449.00, 50, 3, 6),
('Memoria USB Kingston 64GB', 'Pendrive USB 3.0 DataTraveler', 39.00, 200, 3, 9),
('Tarjeta MicroSD 128GB', 'Tarjeta de memoria clase 10 UHS-I', 79.00, 150, 3, 9),
('Disco Duro Seagate 2TB', 'Disco duro externo USB 3.0 2TB', 299.00, 55, 3, 10),
('SSD Kingston 240GB', 'SSD SATA 2.5 pulgadas 240GB', 149.00, 85, 3, 9),
('Memoria USB 32GB', 'Pendrive USB 3.0 32GB', 25.00, 250, 3, 9),


-- Redes (Categoria 4)
('Router TP-Link Archer C6', 'Router WiFi dual band AC1200 4 antenas', 149.00, 60, 4, 11),
('Router TP-Link AX3000', 'Router WiFi 6 AX3000 Gigabit', 299.00, 40, 4, 11),
('Switch TP-Link 8 puertos', 'Switch Gigabit 8 puertos metalico', 89.00, 50, 4, 11),
('Cable de Red Cat6 5m', 'Cable Ethernet categoria 6 5 metros', 25.00, 200, 4, 11),
('Adaptador WiFi USB', 'Adaptador inalambrico USB AC1200', 45.00, 100, 4, 11),
('Router TP-Link Archer AX50', 'Router WiFi 6 AX3000 MU-MIMO', 399.00, 30, 4, 11),
('Switch TP-Link 16 puertos', 'Switch Gigabit 16 puertos rack', 189.00, 25, 4, 11),


-- Audio y Video (Categoria 5)
('Audifonos Logitech H390', 'Audifonos USB con microfono noise cancelling', 129.00, 80, 5, 5),
('Audifonos Samsung Galaxy Buds', 'Audifonos inalambricos Bluetooth TWS', 399.00, 60, 5, 6),
('Parlante Logitech Z200', 'Parlantes estereo 2.0 10W', 99.00, 70, 5, 5),
('Microfono USB Logitech', 'Microfono condensador USB para streaming', 249.00, 40, 5, 5),
('Camara Canon EOS M50', 'Camara mirrorless 24.1MP 4K video', 3499.00, 10, 5, 13),
('Audifonos Gamer RGB', 'Audifonos gaming 7.1 surround RGB', 179.00, 55, 5, 5),
('Parlante Bluetooth JBL', 'Parlante portatil Bluetooth resistente agua', 299.00, 65, 5, 6),


-- Smartphones (Categoria 6)
('Samsung Galaxy A54', 'Smartphone 128GB, 8GB RAM, 5G, 50MP', 1499.00, 50, 6, 6),
('Xiaomi Redmi Note 12', 'Smartphone 128GB, 6GB RAM, 4G, 48MP', 899.00, 70, 6, 14),
('iPhone 13 128GB', 'Smartphone Apple 128GB, 5G, iOS', 3999.00, 30, 6, 7),
('Huawei P50 Pro', 'Smartphone 256GB, 8GB RAM, 5G, 50MP', 2799.00, 25, 6, 15),
('Samsung Galaxy S23', 'Smartphone 256GB, 8GB RAM, 5G, 50MP', 3299.00, 35, 6, 6),
('Xiaomi Poco X5 Pro', 'Smartphone 256GB, 8GB RAM, 5G, 108MP', 1299.00, 45, 6, 14),
('iPhone 14 256GB', 'Smartphone Apple 256GB, 5G, iOS 16', 4999.00, 20, 6, 7),


-- Tablets (Categoria 7)
('iPad 10.2 64GB', 'Tablet Apple WiFi 10.2 pulgadas', 1799.00, 40, 7, 7),
('Samsung Galaxy Tab A8', 'Tablet Android 10.5 pulgadas 4GB RAM', 899.00, 50, 7, 6),
('Lenovo Tab M10', 'Tablet Android 10.1 pulgadas 3GB RAM', 699.00, 45, 7, 3),
('Huawei MatePad', 'Tablet Android 10.4 pulgadas 4GB RAM', 1099.00, 30, 7, 15),
('iPad Air 64GB', 'Tablet Apple WiFi 10.9 pulgadas', 2999.00, 20, 7, 7),
('Samsung Galaxy Tab S8', 'Tablet Android 11 pulgadas 8GB RAM', 2499.00, 25, 7, 6),


-- Impresoras (Categoria 8)
('Impresora HP DeskJet 2775', 'Impresora multifuncion WiFi tinta', 349.00, 40, 8, 1),
('Impresora Epson L3250', 'Impresora multifuncion con tanque de tinta', 899.00, 35, 8, 12),
('Impresora Canon Pixma G3160', 'Impresora multifuncion WiFi tanque tinta', 799.00, 30, 8, 13),
('Tinta HP 664 Negro', 'Cartucho de tinta negro original', 49.00, 150, 8, 1),
('Tinta Epson 544 Color', 'Botella de tinta color original', 35.00, 200, 8, 12),
('Impresora HP LaserJet Pro', 'Impresora laser monocromatica WiFi', 1299.00, 20, 8, 1),
('Tinta Canon GI-790', 'Botella de tinta negra original', 39.00, 180, 8, 13),


-- Gaming (Categoria 9)
('PlayStation 5', 'Consola de videojuegos Sony 825GB SSD', 2799.00, 20, 9, 6),
('Xbox Series S', 'Consola de videojuegos Microsoft 512GB', 1799.00, 25, 9, 8),
('Control PS5 DualSense', 'Control inalambrico PlayStation 5', 299.00, 60, 9, 6),
('Teclado Gamer RGB', 'Teclado mecanico retroiluminado RGB', 249.00, 50, 9, 5),
('Mouse Gamer RGB', 'Mouse gaming 7200 DPI RGB', 149.00, 75, 9, 5),
('Silla Gamer Ergonomica', 'Silla gaming ergonomica reclinable', 799.00, 30, 9, 5),
('Control Xbox Wireless', 'Control inalambrico Xbox Series', 249.00, 55, 9, 8),


-- Software (Categoria 10)
('Windows 11 Home', 'Licencia sistema operativo Windows 11', 599.00, 100, 10, 8),
('Office 365 Personal', 'Suscripcion anual Office 365', 299.00, 150, 10, 8),
('Antivirus Norton 360', 'Licencia 1 ano 3 dispositivos', 149.00, 120, 10, 8),
('Adobe Creative Cloud', 'Suscripcion mensual Adobe CC', 199.00, 80, 10, 8),
('AutoCAD LT 2024', 'Licencia anual AutoCAD LT', 1499.00, 30, 10, 8),
('Windows 11 Pro', 'Licencia sistema operativo Windows 11 Pro', 899.00, 75, 10, 8),
('Office 2021 Home Business', 'Licencia perpetua Office 2021', 1299.00, 50, 10, 8);
GO


PRINT 'OK 70 Productos tecnologicos insertados';
GO


-- =============================================
-- 7. INSERTAR TIPOS DE MOVIMIENTO
-- =============================================
PRINT 'Insertando Tipos de Movimiento...';


SET IDENTITY_INSERT TipoMovimiento ON;
INSERT INTO TipoMovimiento (IdTipoMovimiento, NombreMovimiento) VALUES
(1, 'Entrada'),
(2, 'Salida');
SET IDENTITY_INSERT TipoMovimiento OFF;
GO


PRINT 'OK 2 Tipos de Movimiento insertados';
GO


-- =============================================
-- 8. INSERTAR MOVIMIENTOS DE STOCK
-- =============================================
PRINT 'Insertando Movimientos de Stock...';


INSERT INTO TransaccionStock (IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, Observacion) VALUES
-- Entradas iniciales de stock
(1, 1, 25, '2024-10-15', 'Stock inicial - Laptop HP 15'),
(2, 1, 20, '2024-10-15', 'Stock inicial - Laptop Dell Inspiron'),
(3, 1, 30, '2024-10-16', 'Stock inicial - Laptop Lenovo IdeaPad'),
(4, 1, 15, '2024-10-16', 'Stock inicial - PC HP Pavilion'),
(5, 1, 35, '2024-10-17', 'Stock inicial - Laptop Asus VivoBook'),
(6, 1, 12, '2024-10-17', 'Stock inicial - Laptop HP Gaming'),
(7, 1, 8, '2024-10-18', 'Stock inicial - Laptop Dell XPS'),
(8, 1, 18, '2024-10-18', 'Stock inicial - Laptop Lenovo ThinkPad'),
(9, 1, 80, '2024-10-19', 'Stock inicial - Teclado Logitech K380'),
(10, 1, 100, '2024-10-19', 'Stock inicial - Mouse Logitech M720'),
(11, 1, 40, '2024-10-20', 'Stock inicial - Monitor HP 24'),
(12, 1, 25, '2024-10-20', 'Stock inicial - Monitor Dell 27'),
(13, 1, 60, '2024-10-21', 'Stock inicial - Webcam Logitech'),
(14, 1, 45, '2024-10-21', 'Stock inicial - Teclado Mecanico'),
(15, 1, 70, '2024-10-22', 'Stock inicial - Mouse Gamer G502'),
(16, 1, 20, '2024-10-22', 'Stock inicial - Monitor Samsung Curvo'),
(17, 1, 70, '2024-10-23', 'Stock inicial - Disco Seagate 1TB'),
(18, 1, 90, '2024-10-23', 'Stock inicial - SSD Kingston 480GB'),
(19, 1, 50, '2024-10-24', 'Stock inicial - SSD Samsung NVMe'),
(20, 1, 200, '2024-10-24', 'Stock inicial - USB Kingston 64GB'),
(21, 1, 150, '2024-10-25', 'Stock inicial - MicroSD 128GB'),
(22, 1, 55, '2024-10-25', 'Stock inicial - Disco Seagate 2TB'),
(23, 1, 85, '2024-10-26', 'Stock inicial - SSD Kingston 240GB'),
(24, 1, 250, '2024-10-26', 'Stock inicial - USB 32GB'),
(25, 1, 60, '2024-10-27', 'Stock inicial - Router Archer C6'),
(26, 1, 40, '2024-10-27', 'Stock inicial - Router AX3000'),
(27, 1, 50, '2024-10-28', 'Stock inicial - Switch 8 puertos'),
(28, 1, 200, '2024-10-28', 'Stock inicial - Cable Cat6'),
(29, 1, 100, '2024-10-29', 'Stock inicial - Adaptador WiFi'),
(30, 1, 30, '2024-10-29', 'Stock inicial - Router AX50'),
-- Salidas por ventas
(1, 2, 3, '2024-11-01', 'Venta a cliente'),
(3, 2, 2, '2024-11-02', 'Venta a cliente'),
(9, 2, 5, '2024-11-03', 'Venta a cliente'),
(10, 2, 8, '2024-11-04', 'Venta a cliente'),
(20, 2, 15, '2024-11-05', 'Venta a cliente'),
(38, 2, 4, '2024-11-06', 'Venta a cliente'),
(40, 2, 3, '2024-11-07', 'Venta a cliente'),
(50, 2, 5, '2024-11-08', 'Venta a cliente'),
(55, 2, 2, '2024-11-09', 'Venta a cliente'),
(58, 2, 1, '2024-11-10', 'Venta a cliente');
GO


PRINT 'OK 40 Movimientos de Stock insertados';
GO


-- =============================================
-- 9. INSERTAR VENTAS
-- =============================================
PRINT 'Insertando Ventas...';


INSERT INTO Venta (Fecha, IdCliente, IdUsuario, Total) VALUES
('2024-11-01 10:30:00', 1, 3, 2777.00),
('2024-11-02 11:15:00', 5, 3, 4497.00),
('2024-11-03 14:20:00', 12, 3, 645.00),
('2024-11-04 09:45:00', 8, 3, 1192.00),
('2024-11-05 16:10:00', 23, 3, 585.00),
('2024-11-06 10:00:00', 15, 3, 5996.00),
('2024-11-07 13:30:00', 34, 3, 899.00),
('2024-11-08 15:45:00', 42, 3, 3999.00),
('2024-11-09 11:20:00', 27, 3, 1299.00),
('2024-11-10 14:50:00', 18, 3, 2799.00),
('2024-11-11 09:30:00', 31, 3, 1798.00),
('2024-11-12 12:15:00', 45, 3, 3298.00),
('2024-11-13 16:40:00', 37, 3, 2648.00),
('2024-11-14 10:25:00', 29, 3, 1498.00),
('2024-11-14 15:10:00', 50, 3, 4298.00),
('2024-11-15 09:00:00', 14, 3, 2998.00),
('2024-11-15 11:30:00', 22, 3, 1598.00),
('2024-11-15 14:00:00', 39, 3, 898.00),
('2024-11-15 16:30:00', 47, 3, 5497.00),
('2024-11-15 18:00:00', 11, 3, 1048.00);
GO


PRINT 'OK 20 Ventas insertadas';
GO


-- =============================================
-- 10. INSERTAR DETALLES DE VENTAS
-- =============================================
PRINT 'Insertando Detalles de Ventas...';


INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES
-- Venta 1: Laptop + accesorios
(1, 1, 1, 2499.00, 2499.00),
(1, 9, 1, 129.00, 129.00),
(1, 20, 1, 39.00, 39.00),
(1, 28, 4, 25.00, 100.00),
-- Venta 2: Laptop Dell + monitor
(2, 2, 1, 3299.00, 3299.00),
(2, 11, 1, 599.00, 599.00),
(2, 11, 1, 599.00, 599.00),
-- Venta 3: Teclados
(3, 9, 5, 129.00, 645.00),
-- Venta 4: Mouse
(4, 10, 8, 149.00, 1192.00),
-- Venta 5: USB
(5, 20, 15, 39.00, 585.00),
-- Venta 6: iPhone + iPad
(6, 40, 1, 3999.00, 3999.00),
(6, 48, 1, 1799.00, 1799.00),
(6, 13, 1, 299.00, 299.00),
-- Venta 7: Tablet
(7, 49, 1, 899.00, 899.00),
-- Venta 8: iPhone
(8, 40, 1, 3999.00, 3999.00),
-- Venta 9: Monitor Dell
(9, 12, 1, 1299.00, 1299.00),
-- Venta 10: PlayStation 5
(10, 58, 1, 2799.00, 2799.00),
-- Venta 11: iPad
(11, 48, 1, 1799.00, 1799.00),
-- Venta 12: Samsung S23
(12, 42, 1, 3299.00, 3299.00),
-- Venta 13: Laptop HP + teclado
(13, 1, 1, 2499.00, 2499.00),
(13, 9, 1, 129.00, 129.00),
-- Venta 14: Samsung A54
(14, 38, 1, 1499.00, 1499.00),
-- Venta 15: Laptop Dell + monitor
(15, 2, 1, 3299.00, 3299.00),
(15, 11, 1, 599.00, 599.00),
(15, 13, 1, 299.00, 299.00),
-- Venta 16: iPad Air
(16, 52, 1, 2999.00, 2999.00),
-- Venta 17: Laptop Lenovo
(17, 3, 1, 2199.00, 2199.00),
(17, 20, 10, 39.00, 390.00),
-- Venta 18: Tablet Samsung
(18, 49, 1, 899.00, 899.00),
-- Venta 19: Laptop Dell XPS
(19, 7, 1, 5499.00, 5499.00),
-- Venta 20: Impresora + tintas
(20, 55, 1, 899.00, 899.00),
(20, 59, 3, 49.00, 147.00);
GO


PRINT 'OK Detalles de Ventas insertados';
GO


-- =============================================
-- RESUMEN FINAL
-- =============================================
PRINT '';
PRINT '===========================================';
PRINT 'INSERCION COMPLETADA EXITOSAMENTE';
PRINT 'TECH SOLUTIONS - PRODUCTOS TECNOLOGICOS';
PRINT '===========================================';
PRINT '';


SELECT 'Roles' AS Tabla, COUNT(*) AS Total FROM Rol
UNION ALL SELECT 'Usuarios', COUNT(*) FROM Usuario
UNION ALL SELECT 'Clientes', COUNT(*) FROM Cliente
UNION ALL SELECT 'Proveedores', COUNT(*) FROM Proveedor
UNION ALL SELECT 'Categorias', COUNT(*) FROM Categoria
UNION ALL SELECT 'Productos', COUNT(*) FROM Producto
UNION ALL SELECT 'Tipos Movimiento', COUNT(*) FROM TipoMovimiento
UNION ALL SELECT 'Movimientos Stock', COUNT(*) FROM TransaccionStock
UNION ALL SELECT 'Ventas', COUNT(*) FROM Venta
UNION ALL SELECT 'Detalles Venta', COUNT(*) FROM DetalleVenta;


PRINT '';
PRINT '===========================================';
PRINT 'CREDENCIALES DE ACCESO:';
PRINT '===========================================';
PRINT 'Usuario: admin      | Contrasena: admin123';
PRINT 'Usuario: supervisor | Contrasena: super123';
PRINT 'Usuario: vendedor   | Contrasena: vende123';
PRINT '===========================================';
PRINT '';
PRINT 'Base de datos Tech Solutions lista para usar!';
PRINT 'Sistema de Gestion de Productos Tecnologicos';
GO



