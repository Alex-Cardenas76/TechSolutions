# 📄 Modelos de Entidad C#

Este documento describe los modelos de C# con sus atributos, tipos de datos, claves y relaciones, presentados en formato Markdown.

---

## Modelos Maestros

### Clase: Rol

*   IdRol: int (*PK* - Clave Primaria)
*   NombreRol: string (*Único*)
*   Descripcion: string
*   *Relación:* ICollection<Usuario> **Usuarios** (Muchos Usuarios)

### Clase: Usuario

*   IdUsuario: int (*PK* - Clave Primaria)
*   NombreUsuario: string (*Único*)
*   ContrasenaHash: byte[]
*   IdRol: int (*FK* - Clave Foránea)
*   Estado: bool
*   *Relación:* Rol **Rol** (Un Rol)
*   *Relación:* ICollection<Venta> **Ventas** (Muchas Ventas)

### Clase: Cliente

*   IdCliente: int (*PK* - Clave Primaria)
*   Nombre: string
*   Apellido: string
*   Email: string
*   Telefono: string
*   Direccion: string
*   *Relación:* ICollection<Venta> **Ventas** (Muchas Ventas)

### Clase: Proveedor

*   IdProveedor: int (*PK* - Clave Primaria)
*   NombreProveedor: string
*   Telefono: string
*   Email: string
*   Direccion: string
*   *Relación:* ICollection<Producto> **Productos** (Muchos Productos)

### Clase: Categoria

*   IdCategoria: int (*PK* - Clave Primaria)
*   NombreCategoria: string (*Único*)
*   Descripcion: string
*   *Relación:* ICollection<Producto> **Productos** (Muchos Productos)

### Clase: Producto

*   IdProducto: int (*PK* - Clave Primaria)
*   Nombre: string
*   Descripcion: string
*   Precio: decimal
*   Stock: int
*   IdCategoria: int (*FK* - Clave Foránea)
*   IdProveedor: int? (*FK* - Clave Foránea, Nullable)
*   *Relación:* Categoria **Categoria** (Una Categoría)
*   *Relación:* Proveedor **Proveedor** (Un Proveedor, puede ser nulo)
*   *Relación:* ICollection<DetalleVenta> **DetalleVentas** (Muchos Detalles de Venta)
*   *Relación:* ICollection<TransaccionStock> **TransaccionesStock** (Muchas Transacciones de Stock)

---

## Modelos de Movimiento y Transaccionales

### Clase: TipoMovimiento

*   IdTipoMovimiento: int (*PK* - Clave Primaria)
*   NombreMovimiento: string (*Único*)
*   *Relación:* ICollection<TransaccionStock> **TransaccionesStock** (Muchas Transacciones de Stock)

### Clase: Venta

*   IdVenta: int (*PK* - Clave Primaria)
*   Fecha: DateTime
*   IdCliente: int (*FK* - Clave Foránea)
*   IdUsuario: int (*FK* - Clave Foránea)
*   Total: decimal
*   *Relación:* Cliente **Cliente** (Un Cliente)
*   *Relación:* Usuario **Usuario** (Un Usuario)
*   *Relación:* ICollection<DetalleVenta> **DetalleVentas** (Muchos Detalles de Venta)

### Clase: DetalleVenta

*   IdDetalleVenta: int (*PK* - Clave Primaria)
*   IdVenta: int (*FK* - Clave Foránea)
*   IdProducto: int (*FK* - Clave Foránea)
*   Cantidad: int
*   PrecioUnitario: decimal
*   Subtotal: decimal
*   *Relación:* Venta **Venta** (Una Venta)
*   *Relación:* Producto **Producto** (Un Producto)

### Clase: TransaccionStock

*   IdTransaccion: int (*PK* - Clave Primaria)
*   IdProducto: int (*FK* - Clave Foránea)
*   IdTipoMovimiento: int (*FK* - Clave Foránea)
*   Cantidad: int
*   FechaMovimiento: DateTime
*   Observacion: string
*   *Relación:* Producto **Producto** (Un Producto)
*   *Relación:* TipoMovimiento **TipoMovimiento** (Un Tipo de Movimiento)

---

## Modelo DTO (Transferencia de Datos)

### Clase: DetalleVentaParametro

*   IdProducto: int
*   Cantidad: int

---
