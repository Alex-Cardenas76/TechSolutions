# 📊 Documentación de Diagramas - TechSolutions

## 📘 Proyecto Final: Sistema de Gestión Empresarial

**Institución:** PDSD-437_TRABAJOFINAL  
**Empresa:** Tech Solutions  
**Plataforma:** Microsoft Visual Studio .NET  
**Arquitectura:** N-Capas con Patrón Singleton  
**Base de Datos:** SQL Server  

---

## 📑 Tabla de Contenidos

1. [Introducción](#-introducción)
2. [Diagrama de Arquitectura N-Capas](#-1-diagrama-de-arquitectura-n-capas)
3. [Diagrama de Componentes](#-2-diagrama-de-componentes--packages)
4. [Diagrama de Clases](#-3-diagrama-de-clases)
5. [Diagrama Entidad-Relación](#-4-diagrama-entidad-relación--esquema-de-base-de-datos)
6. [Diagramas de Secuencia](#-5-diagramas-de-secuencia)
7. [Diagrama de Actividad](#-6-diagrama-de-actividad--flujo-de-trabajo)
8. [Diagrama de Despliegue](#-7-diagrama-de-despliegue)
9. [Mockups / Wireframes](#-8-mockups--wireframes)
10. [Conclusiones](#-conclusiones)

---

## 🎯 Introducción

Este documento presenta la documentación completa de los diagramas UML y técnicos del sistema **TechSolutions**, una aplicación empresarial desarrollada en .NET que implementa:

- ✅ Arquitectura N-Capas (Presentación, Negocio, Datos, Entidad)
- ✅ Patrón Singleton para gestión de conexiones
- ✅ Autenticación y autorización por roles
- ✅ Transacciones con Commit/Rollback
- ✅ Consultas LINQ para reportes
- ✅ Interfaz Windows Forms
- ✅ Manejo de hilos y timers
- ✅ Generación de reportes con parámetros
- ✅ Proyecto de instalación

---

## 🏗 1. Diagrama de Arquitectura N-Capas

### Descripción

El sistema TechSolutions está construido siguiendo el patrón de arquitectura N-Capas, que separa las responsabilidades en capas independientes y reutilizables.

### Estructura de Capas

```
┌─────────────────────────────────────────────────────────┐
│         CAPA DE PRESENTACIÓN (Windows Forms)            │
│  - Login.cs, MenuPrincipal.cs                          │
│  - ClientesForm, ProductosForm, VentasForm             │
│  - ReportesForm, MovimientosStockForm                  │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│         CAPA DE NEGOCIO (BLL - Business Logic)          │
│  - ClienteBLL, ProductoBLL, VentaBLL                   │
│  - UsuarioBLL, ReporteBLL                              │
│  - PermisosPorRol, PasswordHasher                      │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│         CAPA DE DATOS (DAL - Data Access Layer)         │
│  - ClienteDAL, ProductoDAL, VentaDAL                   │
│  - Conexion.cs (Singleton Pattern)                     │
│  - Transacciones SQL con Commit/Rollback               │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│              CAPA DE ENTIDAD (Models)                   │
│  - Cliente, Producto, Venta, Usuario                   │
│  - DetalleVenta, TransaccionStock                      │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│              BASE DE DATOS (SQL Server)                 │
│  - TechSolutionsDB                                     │
│  - Tablas, Relaciones, Índices, Constraints            │
└─────────────────────────────────────────────────────────┘
```

### Tecnologías por Capa


| Capa | Tecnología | Responsabilidad |
|------|-----------|-----------------|
| **Presentación** | Windows Forms, C# | Interfaz gráfica, validaciones visuales, eventos |
| **Negocio** | C#, LINQ | Lógica empresarial, validaciones, reglas de negocio |
| **Datos** | ADO.NET, SqlConnection | Acceso a BD, CRUD, transacciones |
| **Entidad** | C# (POCOs) | Modelos de datos, DTOs |
| **Base de Datos** | SQL Server | Almacenamiento, integridad referencial |

### Patrón Singleton Implementado

**Clase:** `Conexion.cs` (CapaDatos/Database)

```csharp
public class Conexion
{
    private static Conexion _instancia = null;
    private string _cadenaConexion;
    
    private Conexion()
    {
        _cadenaConexion = ConfigurationManager.ConnectionStrings["TechSolutionsDB"].ConnectionString;
    }
    
    public static Conexion Instancia
    {
        get
        {
            if (_instancia == null)
                _instancia = new Conexion();
            return _instancia;
        }
    }
    
    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_cadenaConexion);
    }
}
```

### Flujo de Comunicación

1. **Usuario interactúa** con la interfaz (Presentación)
2. **Presentación llama** a métodos de la capa de Negocio (BLL)
3. **Negocio valida** y aplica reglas empresariales
4. **Negocio llama** a la capa de Datos (DAL)
5. **Datos ejecuta** consultas SQL usando Singleton
6. **Datos retorna** objetos de Entidad
7. **Negocio procesa** con LINQ si es necesario
8. **Presentación muestra** resultados al usuario



### Proyectos de la Solución

```
TechSolutions.sln
├── CapaEntidad.csproj          (Modelos de datos)
├── CapaDatos.csproj            (Acceso a datos)
├── CapaNegocio.csproj          (Lógica de negocio)
├── Capa_Presentacion1.csproj   (Interfaz Windows Forms)
└── Instalador.vdproj           (Setup Project)
```

---

## 🧩 2. Diagrama de Componentes / Packages

### Descripción

Este diagrama muestra los componentes principales del sistema y sus dependencias.

### Componentes Principales

```
┌─────────────────────────────────────────────────────────┐
│                    UI COMPONENTS                        │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐             │
│  │  Login   │  │  Menú    │  │  Forms   │             │
│  │  Form    │  │Principal │  │  CRUD    │             │
│  └──────────┘  └──────────┘  └──────────┘             │
│  ┌──────────┐  ┌──────────┐                           │
│  │ Ventas   │  │ Reportes │                           │
│  │  Form    │  │  Form    │                           │
│  └──────────┘  └──────────┘                           │
└─────────────────────────────────────────────────────────┘
                    ↓ usa
┌─────────────────────────────────────────────────────────┐
│              BUSINESS LOGIC COMPONENTS                  │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐             │
│  │Cliente   │  │Producto  │  │  Venta   │             │
│  │  BLL     │  │   BLL    │  │   BLL    │             │
│  └──────────┘  └──────────┘  └──────────┘             │
│  ┌──────────┐  ┌──────────┐                           │
│  │Usuario   │  │ Reporte  │                           │
│  │  BLL     │  │   BLL    │                           │
│  └──────────┘  └──────────┘                           │
│  ┌──────────────────────────┐                         │
│  │   PermisosPorRol.cs      │                         │
│  │   PasswordHasher.cs      │                         │
│  └──────────────────────────┘                         │
└─────────────────────────────────────────────────────────┘
                    ↓ usa
┌─────────────────────────────────────────────────────────┐
│              DATA ACCESS COMPONENTS                     │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐             │
│  │Cliente   │  │Producto  │  │  Venta   │             │
│  │  DAL     │  │   DAL    │  │   DAL    │             │
│  └──────────┘  └──────────┘  └──────────┘             │
│  ┌──────────────────────────┐                         │
│  │   Conexion.cs            │ ← Singleton             │
│  │   (Singleton Pattern)    │                         │
│  └──────────────────────────┘                         │
└─────────────────────────────────────────────────────────┘
                    ↓ usa
┌─────────────────────────────────────────────────────────┐
│                  ENTITY MODELS                          │
│  Cliente, Producto, Venta, Usuario, DetalleVenta       │
│  Categoria, Proveedor, TransaccionStock, Rol           │
└─────────────────────────────────────────────────────────┘
```


### Dependencias entre Componentes

| Componente | Depende de | Tipo de Dependencia |
|-----------|-----------|---------------------|
| **UI Forms** | BLL + Entidad | Uso directo |
| **BLL** | DAL + Entidad | Uso directo |
| **DAL** | Entidad | Uso directo |
| **Entidad** | Ninguno | Independiente |
| **Instalador** | Todos los proyectos | Empaquetado |

### Componentes Especiales

**Seguridad:**
- `PermisosPorRol.cs` - Control de acceso basado en roles
- `PasswordHasher.cs` - Hash de contraseñas con SHA256

**Reportes:**
- `ReporteBLL.cs` - Lógica de generación de reportes
- `ReporteDAL.cs` - Consultas SQL para reportes
- Archivos RDLC en carpeta Reportes/

**Instalador:**
- `Instalador.vdproj` - Setup Project para distribución

---

## 📦 3. Diagrama de Clases

### Descripción

Diagrama de clases principales del sistema con sus atributos, métodos y relaciones.

### Modelos de Entidad (CapaEntidad)

#### Clase: Rol
```csharp
public class Rol
{
    // Atributos
    + IdRol: int [PK]
    + NombreRol: string [Unique]
    + Descripcion: string
    
    // Relaciones
    + Usuarios: ICollection<Usuario>
}
```

#### Clase: Usuario
```csharp
public class Usuario
{
    // Atributos
    + IdUsuario: int [PK]
    + NombreUsuario: string [Unique]
    + ContrasenaHash: byte[]
    + IdRol: int [FK]
    + Estado: bool
    
    // Relaciones
    + Rol: Rol
    + Ventas: ICollection<Venta>
}
```

#### Clase: Cliente
```csharp
public class Cliente
{
    // Atributos
    + IdCliente: int [PK]
    + Nombre: string
    + Apellido: string
    + Email: string
    + Telefono: string
    + Direccion: string
    
    // Relaciones
    + Ventas: ICollection<Venta>
}
```


#### Clase: Proveedor
```csharp
public class Proveedor
{
    // Atributos
    + IdProveedor: int [PK]
    + NombreProveedor: string
    + Telefono: string
    + Email: string
    + Direccion: string
    
    // Relaciones
    + Productos: ICollection<Producto>
}
```

#### Clase: Categoria
```csharp
public class Categoria
{
    // Atributos
    + IdCategoria: int [PK]
    + NombreCategoria: string [Unique]
    + Descripcion: string
    
    // Relaciones
    + Productos: ICollection<Producto>
}
```

#### Clase: Producto
```csharp
public class Producto
{
    // Atributos
    + IdProducto: int [PK]
    + Nombre: string
    + Descripcion: string
    + Precio: decimal
    + Stock: int
    + IdCategoria: int [FK]
    + IdProveedor: int? [FK, Nullable]
    
    // Relaciones
    + Categoria: Categoria
    + Proveedor: Proveedor
    + DetalleVentas: ICollection<DetalleVenta>
    + TransaccionesStock: ICollection<TransaccionStock>
}
```

#### Clase: Venta
```csharp
public class Venta
{
    // Atributos
    + IdVenta: int [PK]
    + Fecha: DateTime
    + IdCliente: int [FK]
    + IdUsuario: int [FK]
    + Total: decimal
    
    // Relaciones
    + Cliente: Cliente
    + Usuario: Usuario
    + DetalleVentas: ICollection<DetalleVenta>
}
```

#### Clase: DetalleVenta
```csharp
public class DetalleVenta
{
    // Atributos
    + IdDetalleVenta: int [PK]
    + IdVenta: int [FK]
    + IdProducto: int [FK]
    + Cantidad: int
    + PrecioUnitario: decimal
    + Subtotal: decimal
    
    // Relaciones
    + Venta: Venta
    + Producto: Producto
}
```


#### Clase: TipoMovimiento
```csharp
public class TipoMovimiento
{
    // Atributos
    + IdTipoMovimiento: int [PK]
    + NombreMovimiento: string [Unique]
    
    // Relaciones
    + TransaccionesStock: ICollection<TransaccionStock>
}
```

#### Clase: TransaccionStock
```csharp
public class TransaccionStock
{
    // Atributos
    + IdTransaccion: int [PK]
    + IdProducto: int [FK]
    + IdTipoMovimiento: int [FK]
    + Cantidad: int
    + FechaMovimiento: DateTime
    + Observacion: string
    
    // Relaciones
    + Producto: Producto
    + TipoMovimiento: TipoMovimiento
}
```

### Clases de Lógica de Negocio (CapaNegocio)

#### Clase: ClienteBLL
```csharp
public class ClienteBLL
{
    // Métodos
    + ObtenerTodos(): List<Cliente>
    + ObtenerPorId(int id): Cliente
    + Insertar(Cliente cliente): bool
    + Actualizar(Cliente cliente): bool
    + Eliminar(int id): bool
    + BuscarPorNombre(string nombre): List<Cliente>
}
```

#### Clase: ProductoBLL
```csharp
public class ProductoBLL
{
    // Métodos
    + ObtenerTodos(): List<Producto>
    + ObtenerPorId(int id): Producto
    + Insertar(Producto producto): bool
    + Actualizar(Producto producto): bool
    + Eliminar(int id): bool
    + ValidarStock(int idProducto, int cantidad): bool
    + ObtenerPorCategoria(int idCategoria): List<Producto>
    + BuscarPorNombre(string nombre): List<Producto>
}
```

#### Clase: VentaBLL
```csharp
public class VentaBLL
{
    // Métodos
    + RegistrarVenta(Venta venta, List<DetalleVenta> detalles): bool
    + ObtenerTodas(): List<Venta>
    + ObtenerPorId(int id): Venta
    + ObtenerPorFecha(DateTime inicio, DateTime fin): List<Venta>
    + CalcularTotal(List<DetalleVenta> detalles): decimal
    + ValidarVenta(Venta venta, List<DetalleVenta> detalles): bool
}
```


#### Clase: PermisosPorRol
```csharp
public static class PermisosPorRol
{
    // Métodos estáticos
    + PuedeGestionarClientes(int idRol): bool
    + PuedeGestionarProveedores(int idRol): bool
    + PuedeGestionarCategorias(int idRol): bool
    + PuedeGestionarProductos(int idRol): bool
    + PuedeRegistrarVentas(int idRol): bool
    + PuedeGestionarMovimientosStock(int idRol): bool
    + PuedeVerReportes(int idRol): bool
    + PuedeGestionarUsuarios(int idRol): bool
    + PuedeModificarPrecios(int idRol): bool
    + PuedeEliminarVentas(int idRol): bool
    + ObtenerNombreRol(int idRol): string
}
```

### Relaciones entre Clases

```
Rol (1) ──────< (N) Usuario
Usuario (1) ──────< (N) Venta
Cliente (1) ──────< (N) Venta
Venta (1) ──────< (N) DetalleVenta
Producto (1) ──────< (N) DetalleVenta
Categoria (1) ──────< (N) Producto
Proveedor (1) ──────< (N) Producto
Producto (1) ──────< (N) TransaccionStock
TipoMovimiento (1) ──────< (N) TransaccionStock
```

**Leyenda:**
- `(1) ──────< (N)` = Relación Uno a Muchos
- `[PK]` = Primary Key
- `[FK]` = Foreign Key
- `[Unique]` = Valor único

---

## 🗄 4. Diagrama Entidad-Relación / Esquema de Base de Datos

### Descripción

Esquema completo de la base de datos TechSolutionsDB con tablas, relaciones y constraints.

### Tablas Principales

#### Tabla: Rol
```sql
CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200) NULL,
    CONSTRAINT CK_Rol_NombreRol CHECK (LEN(NombreRol) > 0)
);
```

#### Tabla: Usuario
```sql
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    ContrasenaHash VARBINARY(MAX) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol(IdRol),
    CONSTRAINT CK_Usuario_NombreUsuario CHECK (LEN(NombreUsuario) >= 3)
);
```


#### Tabla: Cliente
```sql
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
```

#### Tabla: Proveedor
```sql
CREATE TABLE Proveedor (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),
    NombreProveedor NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Direccion NVARCHAR(200) NULL,
    CONSTRAINT CK_Proveedor_Nombre CHECK (LEN(NombreProveedor) > 0)
);
```

#### Tabla: Categoria
```sql
CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    NombreCategoria NVARCHAR(100) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200) NULL,
    CONSTRAINT CK_Categoria_Nombre CHECK (LEN(NombreCategoria) > 0)
);
```

#### Tabla: Producto
```sql
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
```

#### Tabla: Venta
```sql
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
```
